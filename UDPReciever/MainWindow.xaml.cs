/*
 * Author: Waleed Maqsood
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace UDPReciever
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        UdpClient client = null;
        bool done = false;
        int CountUdpPackets = 0;
        public String IpAddress { get; set; }
        public String PortNumber { get; set; }


        public MainWindow()
        {

            InitializeComponent();

            DispatcherTimer LiveTime = new DispatcherTimer();
            LiveTime.Interval = TimeSpan.FromSeconds(1);
            LiveTime.Tick += timer_Tick;
            LiveTime.Start();

        }
        private void mnu_StartDataExtraction_Click(object sender, EventArgs e)
        {

            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".txt"; // Default file extension
            dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                String filename = dlg.FileName;
                this.Title = "UDP Utility " + dlg.FileName;

                updateButtonsAndLabels_StartExtraction();

                int listenPort = Int32.Parse(PortNumber);
                String IpAdressText = IpAddress;
                Task.Run(() =>
                {

                    try
                    {
                        using (client = new UdpClient(listenPort))
                        {
                           
                            IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Parse(IpAdressText), listenPort);
                            while (!done)
                            {

                                try
                                {
                                    byte[] receivedData = client.Receive(ref RemoteIpEndPoint);


                                    CountUdpPackets++;
                                    this.Dispatcher.Invoke(() =>
                                    {
                                        lbl_PacketCount.Content = CountUdpPackets;
                                    });

                                    try
                                    {
                                        using BinaryWriter binWriter = new BinaryWriter(new FileStream(dlg.FileName, FileMode.Append));
                                        binWriter.Write(receivedData);
                                    }
                                    catch (IOException e)
                                    {
                                        MessageBox.Show(e.Message,"Message", MessageBoxButton.OK, MessageBoxImage.Information);

                                    }
                                }
                                catch (SocketException)
                                {
                                    this.Dispatcher.Invoke(() =>
                                    {
                                        MessageBox.Show(this, "Data extration stopped", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                                    });

                                }
                            }

                           
                            done = false;

                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message,"Message", MessageBoxButton.OK, MessageBoxImage.Warning);
                    
                    }
                });

            }
        }
        private void mnu_UDPacketinfo_Click(object sender, EventArgs e)
        {

            Window1 listbox = new Window1();
            listbox.ShowDialog();
            IpAddress = listbox.IpAdrress;
            PortNumber = listbox.PortNumber;
            if (IpAddress != null && PortNumber != null)
            {
                mnu_StartExtraction.IsEnabled = true;
            }

        }

        private void mnu_StopDataExtraction_Click(object sender, EventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Stop Data Extration ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);

            switch (result)
            {
                case MessageBoxResult.Yes:

                    client.Close();
                    done = true;
                    updateButtonsAndLabels_StopExtraction();
                    this.Title = "UDP Utility ";
                    break;
                case MessageBoxResult.No:
                    break;
            }

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lbl_Time.Content = DateTime.Now.ToString("HH:mm:ss");
        }

        private void mnu_Exit(object sender, EventArgs e)
        {

            this.Close();
        }
        public void updateButtonsAndLabels_StartExtraction()
        {
            mnu_StartExtraction.IsEnabled = false;
            mnu_StopExtraction.IsEnabled = true;
            mnu_UDPPacketinfo.IsEnabled = false;
            lbl_DataExtraction.Visibility = Visibility.Visible;
            lbl_IPAddress.Visibility = Visibility.Visible;
            lbl_PortNumber.Visibility = Visibility.Visible;
            lbl_IPAddress_Value.Visibility = Visibility.Visible;
            lbl_PortNumber_Value.Visibility = Visibility.Visible;
            lbl_IPAddress_Value.Content = IpAddress;
            lbl_PortNumber_Value.Content = PortNumber;
        }

        public void updateButtonsAndLabels_StopExtraction()
        {

            mnu_StopExtraction.IsEnabled = false;
            mnu_StartExtraction.IsEnabled = false;
            mnu_StopExtraction.IsEnabled = false;
            mnu_UDPPacketinfo.IsEnabled = true;
            lbl_DataExtraction.Visibility = Visibility.Hidden;
            lbl_IPAddress.Visibility = Visibility.Hidden;
            lbl_PortNumber.Visibility = Visibility.Hidden;
            lbl_IPAddress_Value.Visibility = Visibility.Hidden;
            lbl_PortNumber_Value.Visibility = Visibility.Hidden;
            CountUdpPackets = 0;
            lbl_PacketCount.Content = CountUdpPackets;
        }




    }
}



