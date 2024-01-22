using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hotkeys;
using WindowsInput;
using System.Runtime.InteropServices;

namespace KikBot
{
    public partial class F1 : Form
    {
        [DllImport("user32.dll")]
        public static extern void mouse_event(uint dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        [DllImport("user32.dll")]
        public static extern void SetCursorPos(int x, int y);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        private GlobalHotkey ghk;

        public F1()
        {
            InitializeComponent();
            ghk = new GlobalHotkey(Constants.NOMOD, Keys.F1, this);
        }

        private void HandleHotkey()
        {
            InputSimulator.SimulateKeyDown(VirtualKeyCode.SHIFT);
            System.Threading.Thread.Sleep(1);
            InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_H);
            System.Threading.Thread.Sleep(1);
            InputSimulator.SimulateKeyUp(VirtualKeyCode.SHIFT);
            System.Threading.Thread.Sleep(1);
            InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_I);
            System.Threading.Thread.Sleep(1);
            int X = Screen.PrimaryScreen.Bounds.Width - 48;
            int Y = Screen.PrimaryScreen.Bounds.Height - 23;
            SetCursorPos(X, Y);
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Constants.WM_HOTKEY_MSG_ID)
                HandleHotkey();
            base.WndProc(ref m);
        }

        private void Shortcuts_Load(object sender, EventArgs e)
        {
            ghk.Register();
        }

        private void Shortcuts_FormClosing(object sender, FormClosingEventArgs e)
        {
            ghk.Unregiser();
        }
    }
}
