using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Interop;
using System.ComponentModel;
using System.Management;

namespace Autom8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void script_docs_btn_Click(object sender, RoutedEventArgs e)
        {
            string curDir = Directory.GetCurrentDirectory();
            Console.WriteLine("Directory: " + curDir);
            Process.Start(String.Format("file:///{0}/Documentation/scripting.html", curDir));
        }

        private void app_add_Click(object sender, RoutedEventArgs e)
        {
            InputBox inputBox = new InputBox("Enter a name:");
            if (inputBox.ShowDialog() == true)
                apps_list.Items.Add(inputBox.result);
        }

        private void web_add_btn_Click(object sender, RoutedEventArgs e)
        {
        }

        private void cmd_add_btn_Click(object sender, RoutedEventArgs e)
        {
        }

        private void scripts_add_btn_Click(object sender, RoutedEventArgs e)
        {
        }

        private void app_remove_Click(object sender, RoutedEventArgs e)
        {
            if (apps_list.SelectedItem != null)
            {
                apps_list.Items.RemoveAt(apps_list.Items.IndexOf(apps_list.SelectedItem));
            }
        }

        private void web_remove_btn_Click(object sender, RoutedEventArgs e)
        {
            if (signin_list.SelectedItem != null)
            {
                signin_list.Items.RemoveAt(signin_list.Items.IndexOf(signin_list.SelectedItem));
            }
        }

        private void cmd_remove_btn_Click(object sender, RoutedEventArgs e)
        {
            if (cmd_list.SelectedItem != null)
            {
                cmd_list.Items.RemoveAt(cmd_list.Items.IndexOf(cmd_list.SelectedItem));
            }
        }

        private void scripts_remove_btn_Click(object sender, RoutedEventArgs e)
        {
            if (script_list.SelectedItem != null)
            {
                script_list.Items.RemoveAt(script_list.Items.IndexOf(script_list.SelectedItem));
            }
            
        }

        private void OnClosing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

    }
}
   
