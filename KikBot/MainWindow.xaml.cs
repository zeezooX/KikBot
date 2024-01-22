using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Diagnostics;
using System.IO;
using WindowsInput;

namespace KikBot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        bool bs;
        bool IsRunning;
        private bool _shutdown;
        F1 f1 = new F1();
        F2 f2 = new F2();
        F7 f3 = new F7();
        F4 f4 = new F4();
        F5 f5 = new F5();

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            string output = bs ? "Bluestacks has been detected running." : "Bluestacks is not running. KiK Bot will try to execute it now.";
            MetroDialogSettings st = null;
            await this.ShowMessageAsync("KiK Bot for Plasa Emanuel", output, MessageDialogStyle.Affirmative, st);
            if (bs == false)
                if (File.Exists("C:/ProgramData/BlueStacksGameManager/BlueStacks.exe"))
                {
                    Process.Start("C:/ProgramData/BlueStacksGameManager/BlueStacks.exe");
                    button.Content = "Bluestacks is running";
                    bs = true;
                    buttone.IsEnabled = true;
                }
                else
                {
                    await this.ShowMessageAsync("KiK Bot for Plasa Emanuel", "Could not start Bluestacks. Please start it manually.", MessageDialogStyle.Affirmative, st);
                }
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void button_s_Click(object sender, RoutedEventArgs e)
        {
            var flyout = Flyouts.Items[0] as Flyout;
            flyout.IsOpen = !flyout.IsOpen;
            var flyout1 = Flyouts.Items[1] as Flyout;
            flyout1.IsOpen = false;
            var flyout2 = Flyouts.Items[2] as Flyout;
            flyout2.IsOpen = false;
        }

        private void button_h_Click(object sender, RoutedEventArgs e)
        {
            var flyout = Flyouts.Items[1] as Flyout;
            flyout.IsOpen = !flyout.IsOpen;
            var flyout1 = Flyouts.Items[0] as Flyout;
            flyout1.IsOpen = false;
            var flyout2 = Flyouts.Items[2] as Flyout;
            flyout2.IsOpen = false;
        }

        private void button_a_Click(object sender, RoutedEventArgs e)
        {
            var flyout = Flyouts.Items[2] as Flyout;
            flyout.IsOpen = !flyout.IsOpen;
            var flyout1 = Flyouts.Items[0] as Flyout;
            flyout1.IsOpen = false;
            var flyout2 = Flyouts.Items[1] as Flyout;
            flyout2.IsOpen = false;
        }

        private async void toggleButton_Checked(object sender, RoutedEventArgs e)
        {
            if (bs == true)
            {
                label.Content = "Stop Service";
                IsRunning = true;
                f1.Show();
                f2.Show();
                f3.Show();
                f4.Show();
                f5.Show();
            }
            else
            {
                toggleButton.IsChecked = false;
                MetroDialogSettings st = null;
                await this.ShowMessageAsync("KiK Bot for Plasa Emanuel", "Bluestacks not running!", MessageDialogStyle.Affirmative, st);
            }
        }

        private void toggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            label.Content = "Start Service";
            IsRunning = false;
            f1.Close();
            f2.Close();
            f3.Close();
            f4.Close();
            f5.Close();
        }
        private void buttona_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://www.freelancer.com/u/zeezoox");
        }

        private async void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !_shutdown && IsRunning;
            if (_shutdown) return;

            var mySettings = new MetroDialogSettings()
            {
                AffirmativeButtonText = "Quit",
                NegativeButtonText = "Cancel",
                AnimateShow = true,
                AnimateHide = false
            };

            var result = await this.ShowMessageAsync("Quit application?",
                "The service is still running. Do you still want to quit?",
                MessageDialogStyle.AffirmativeAndNegative, mySettings);

            _shutdown = result == MessageDialogResult.Affirmative;

            if (_shutdown)
                Application.Current.Shutdown();
        }

        private void button_b_Click(object sender, RoutedEventArgs e)
        {
            var flyout = Flyouts.Items[3] as Flyout;
            flyout.IsOpen = !flyout.IsOpen;
            var flyout1 = Flyouts.Items[1] as Flyout;
            flyout1.IsOpen = false;
            var flyout2 = Flyouts.Items[2] as Flyout;
            flyout2.IsOpen = false;
            var flyout3 = Flyouts.Items[0] as Flyout;
            flyout3.IsOpen = false;
        }

        private void buttonr_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void Refresh()
        {
            Process []
            processname = Process.GetProcessesByName("bluestacks");
            if (processname.Length == 0)
            {
                button.Content = "Bluestacks is not running";
                bs = false;
                buttone.IsEnabled = false;
            }
            else
            {
                button.Content = "Bluestacks is running";
                bs = true;
                buttone.IsEnabled = true;
            }
        }

        private void buttone_Click(object sender, RoutedEventArgs e)
        {
            Process[]
            processname = Process.GetProcessesByName("bluestacks");
            if (processname.Length != 0)
            {
                foreach (Process proc in Process.GetProcessesByName("bluestacks"))
                {
                    proc.Kill();
                }
                button.Content = "Bluestacks is not running";
                bs = false;
                buttone.IsEnabled = false;
            }
        }
    }
}
