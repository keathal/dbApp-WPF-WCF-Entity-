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
    /// Логика взаимодействия для Add_reader.xaml
    /// </summary>
    public partial class Add_reader : Window
    {
        ServiceReference1.Service1Client cli = new ServiceReference1.Service1Client();
        public int user_id = 0;
        public Add_reader()
        {
            InitializeComponent();

            cli.saveUserCompleted += Cli_saveUserCompleted;
        }

        private void Cli_saveUserCompleted(object sender, ServiceReference1.saveUserCompletedEventArgs e)
        {
            switch (e.Result)
            {
                case -2:
                    MessageBox.Show("Введите пароль");
                    break;
                case -1:
                    MessageBox.Show("Введите логин");
                    break;
                case -3:
                    MessageBox.Show("Логин занят");
                    break;
                default:
                    user_id = e.Result;
                    MessageBox.Show("Вы зарегестрированы");
                    this.Close();
                    break;
            }
        }

        private void b_add_Click(object sender, RoutedEventArgs e)
        {
            cli.addReaderCompleted += Cli_addReaderCompleted;
            cli.addReaderAsync(t_readername_edit.Text, t_readersname_edit.Text);


            cli.saveUserAsync(t_readername_edit.Text, t_readersname_edit.Text, t_login.Text, t_password.Password);
        }

        private void Cli_addReaderCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            this.Close();
        }

        private void b_edit_Click(object sender, RoutedEventArgs e)
        {
            cli.editReaderCompleted += Cli_editReaderCompleted;
            cli.editReaderAsync((int)t_readername_edit.Tag, t_readername_edit.Text, t_readersname_edit.Text);
        }

        private void Cli_editReaderCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            this.Close();
        }
    }
}
