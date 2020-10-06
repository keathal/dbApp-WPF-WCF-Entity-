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
using System.Windows.Shapes;

namespace EntityDB
{
    /// <summary>
    /// Логика взаимодействия для Chat.xaml
    /// </summary>
    public partial class Chat : Window
    {
        public bool isConnected = false;
        public int user_id = 0;
        List<ServiceReference1.T_Reader> users = new List<ServiceReference1.T_Reader>();
        ServiceReference1.Service1Client cli = new ServiceReference1.Service1Client();
        List<string> messages = new List<string>();
        int currentMessage = 0;

        public Chat()
        {
            InitializeComponent();

            cli.selectAllReaderCompleted += Cli_selectAllReaderCompleted;
            cli.selectAllReaderAsync();

            cli.sendMessageCompleted += Cli_sendMessageCompleted;

            cli.checkForMessageCompleted += Cli_checkForMessageCompleted;
            //cli.checkForMessageAsync(messages.Count, currentMessage);

            cli.currentMsgCompleted += Cli_currentMsgCompleted;
            cli.currentMsgAsync();

        }

        private void Cli_currentMsgCompleted(object sender, ServiceReference1.currentMsgCompletedEventArgs e)
        {
            currentMessage = e.Result;
            cli.checkForMessageAsync(messages.Count, currentMessage);
        }

        private void Cli_checkForMessageCompleted(object sender, ServiceReference1.checkForMessageCompletedEventArgs e)
        {
            List<string> msg = new List<string>();
            msg.AddRange(e.Result);
            foreach (string item in msg)
            {
                lbChat.Items.Add(item);
                messages.Add(item);
                currentMessage++;
            }

            cli.checkForMessageAsync(messages.Count, currentMessage);
        }

        private void Cli_sendMessageCompleted(object sender, ServiceReference1.sendMessageCompletedEventArgs e)
        {
            messages.Add(e.Result);
            //lbChat.Items.Add(e.Result);
        }

        private void Cli_selectAllReaderCompleted(object sender, ServiceReference1.selectAllReaderCompletedEventArgs e)
        {
            users.Clear();
            users.AddRange(e.Result);
        }

        private void btn_send_Click(object sender, RoutedEventArgs e)
        {
            if(t_msg.Text!="")
            {
                //lbChat.Items.Add(DateTime.Now.ToShortTimeString() +": " + t_msg.Text);
                cli.sendMessageAsync(t_msg.Text, user_id);
                t_msg.Text ="";
            }
        }

        private void t_msg_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Enter)
            {
                if (t_msg.Text != "")
                {
                    //lbChat.Items.Add(DateTime.Now.ToShortTimeString() +": " + t_msg.Text);
                    cli.sendMessageAsync(t_msg.Text, user_id);
                    t_msg.Text = "";
                }
            }
        }
    }
}
