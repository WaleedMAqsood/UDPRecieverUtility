/*
 * Author: Waleed Maqsood
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UDPReciever
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {

        public Window2()
        {
            InitializeComponent();

        }

        public static readonly DependencyProperty ipAddressProperty = DependencyProperty.Register("IpAddress", typeof(string), typeof(Window2), new UIPropertyMetadata(String.Empty));
        public string IpAddress
        {
            get { return (string)GetValue(ipAddressProperty); }
            set { SetValue(ipAddressProperty, value); }
        }

        public static readonly DependencyProperty portNumberProperty = DependencyProperty.Register("PortNumber", typeof(string), typeof(Window2), new UIPropertyMetadata(String.Empty));
        public string PortNumber
        {
            get { return (string)GetValue(portNumberProperty); }
            set { SetValue(portNumberProperty, value); }
        }

        private void IPaddressInputValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(("[^0-9.]"));
            e.Handled = regex.IsMatch(e.Text);
        }
        private void PortinputValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(("[^0-9]"));
            e.Handled = regex.IsMatch(e.Text);
        }

        private void mnu_OkayButton(object sender, RoutedEventArgs e)
        {


            if (txtfield_IpAddress.Text.Length != 0 && txtfield_Port.Text.Length != 0)
            {

                string checkDupliateIp = txtfield_IpAddress.Text;
                string checkDuplicatePort = txtfield_Port.Text;
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Please enter Both fields", "Message", MessageBoxButton.OK, MessageBoxImage.Information);

            }

        }
        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();

        }
    }
}
