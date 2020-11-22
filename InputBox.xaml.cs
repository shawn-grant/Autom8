using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Autom8
{
    /// <summary>
    /// Interaction logic for InputBox.xaml
    /// </summary>
    public partial class InputBox : Window
    {
        public String result;
        public InputBox(string question)
        {
            InitializeComponent();
            prompt.Text = question;
            result = "";
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            result = InputTextBox.Text;

            if (!result.Equals(""))
            {
                DialogResult = true;
            }
            else
            {
                System.Windows.MessageBox.Show("Please enter a value!");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

    }
}
