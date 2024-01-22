using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace KikBot
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : UserControl
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.F3 = textBox3.Text;
            Properties.Settings.Default.F6 = textBox6.Text;
            Properties.Settings.Default.F8 = textBox8.Text;
            Properties.Settings.Default.F2 = textBox2.Text;
            Properties.Settings.Default.F4 = textBox4.Text;
            Properties.Settings.Default.Blacklist = textBoxb.Text;
            Properties.Settings.Default.Save();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            textBox3.Text = Properties.Settings.Default.F3;
            textBox6.Text = Properties.Settings.Default.F6;
            textBox8.Text = Properties.Settings.Default.F8;
            textBox2.Text = Properties.Settings.Default.F2;
            textBox4.Text = Properties.Settings.Default.F4;
            textBoxb.Text = Properties.Settings.Default.Blacklist;
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (openFileDialog.ShowDialog() == true)
                textBox3.Text = openFileDialog.FileName;
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (openFileDialog.ShowDialog() == true)
                textBox6.Text = openFileDialog.FileName;
        }

        private void button8_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (openFileDialog.ShowDialog() == true)
                textBox8.Text = openFileDialog.FileName;
        }

        private void buttonb_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Plain Text File (*.txt) | *.txt";
            if (openFileDialog.ShowDialog() == true)
                textBoxb.Text = openFileDialog.FileName;
        }
    }
}
