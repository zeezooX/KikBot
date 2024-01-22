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
    public partial class F5 : Form
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

        public F5()
        {
            InitializeComponent();
            ghk = new GlobalHotkey(Constants.NOMOD, Keys.F5, this);
        }

        private void HandleHotkey()
        {
            timer1.Start();
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            int X = Screen.PrimaryScreen.Bounds.Width - 48;
            int Y = 84;
            SetCursorPos(X, Y);
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
            System.Threading.Thread.Sleep(500);
            SetCursorPos(X, Y);
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
            X = Screen.PrimaryScreen.Bounds.Width / 2;
            Y = (Screen.PrimaryScreen.Bounds.Height / 2) + 62;
            SetCursorPos(X, Y);
            System.Threading.Thread.Sleep(500);
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
            X = X + 128;
            Y = Y + 16;
            SetCursorPos(X, Y);
            System.Threading.Thread.Sleep(500);
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
            X = 48;
            Y = 84;
            SetCursorPos(X, Y);
            System.Threading.Thread.Sleep(500);
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
            timer1.Stop();
        }
    }
}
