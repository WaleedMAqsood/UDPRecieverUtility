/*
 * Author: Waleed Maqsood
 */
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace UDPReciever
{

    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>  


    public partial class Window1 : Window
    {
        public ObservableCollection<address> list = new ObservableCollection<address>();
        public String IpAdrress { get; private set; }
        public String PortNumber { get; private set; }

        static String FileFolder;
        static String FileName;

        public Window1()
        {
            InitializeComponent();

            FileFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "/UDPUtility";
            FileName = FileFolder + "/UDPUtilityData";

            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "/UDPUtility"))
                Directory.CreateDirectory(FileFolder);

            if (!File.Exists(FileName))
            {
                // Create a file to write to   
                try
                {
                    using StreamWriter sw = File.CreateText(FileName);
                }
                catch (Exception e)
                {

                    MessageBox.Show(e.ToString(), "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            // Open the file to read from.  
            try
            {
                using (StreamReader sr = File.OpenText(FileName))
                {

                    while (sr.Peek() >= 0)
                    {
                        string str;
                        string[] strArray;
                        str = sr.ReadLine();
                        strArray = str.Split(" ");
                        address d = new address();
                        d.IpAdrress = strArray[0];
                        d.PortNumber = strArray[1];
                        list.Add(d);
                    }

                }
            }
            catch (Exception e)
            {


                MessageBox.Show(e.ToString(), "Message", MessageBoxButton.OK, MessageBoxImage.Error);

            }

            listView.ItemsSource = list;
        }

        private void btn_AddButton_Click(object sender, RoutedEventArgs e)
        {
            Window2 add_Window = new Window2();

            if (add_Window.ShowDialog() == true)
            {
                bool flag = true;
                foreach (address x in list)
                {
                    if (x.IpAdrress.Equals(add_Window.IpAddress) && x.PortNumber.Equals(add_Window.PortNumber))
                    {
                        flag = false;
                    }
                }

                if (flag == false)
                {
                    MessageBox.Show("Duplicate entry, The value already exists", "Message", MessageBoxButton.OK, MessageBoxImage.Information);

                }

                else
                {
                    list.Add(new address() { IpAdrress = add_Window.IpAddress, PortNumber = add_Window.PortNumber });


                    using (var writer = new StreamWriter(FileName))
                    {
                        foreach (address item in list)
                        {
                            writer.WriteLine(item.IpAdrress + " " + item.PortNumber);
                        }
                    }
                }
            }
        }

        private void btn_Done_Click(object sender, RoutedEventArgs e)
        {

            if (listView.SelectedItem != null)
            {
                address listViewItems = (address)listView.SelectedItems[0];
                IpAdrress = listViewItems.IpAdrress;
                PortNumber = listViewItems.PortNumber;
            }

            Close();
        }

        private void btn_Delete_Click(object sender, RoutedEventArgs e)
        {

            btn_Done.IsEnabled = false;
            btn_Delete.IsEnabled = false;

            if (listView.SelectedIndex != -1)
            {
                list.RemoveAt(listView.SelectedIndex);
                using (var writer = new StreamWriter(FileName))
                    foreach (address item in list)
                    {
                        writer.WriteLine(item.IpAdrress + " " + item.PortNumber);
                    }
            }
        }

        private void On_Click(object sender, SelectionChangedEventArgs e)
        {
            if (listView.SelectedItem != null)
            {
                btn_Done.IsEnabled = true;
                btn_Delete.IsEnabled = true;
            }
        }


    }
}

