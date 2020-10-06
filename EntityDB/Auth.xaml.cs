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
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
        ServiceReference1.Service1Client cli = new ServiceReference1.Service1Client();
        public int id_user;

        public Auth()
        {
            InitializeComponent();

            cli.logInCompleted += Cli_logInCompleted;
        }

        private void b_enter_Click(object sender, RoutedEventArgs e)
        {
            cli.logInAsync(t_login.Text, t_pas.Password.ToString());
        }

        private void Cli_logInCompleted(object sender, ServiceReference1.logInCompletedEventArgs e)
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
                    MessageBox.Show("Пользователь не найден");
                    break;
                case -4:
                    MessageBox.Show("Неверный пароль");
                    break;
                default:
                    id_user = e.Result;
                    //MessageBox.Show("Success. User id: " + id_user);
                    this.Close();
                    break;
            }
        }

        private void b_save_Click(object sender, RoutedEventArgs e)
        {
            Add_reader form = new Add_reader();
            form.b_edit.Visibility = Visibility.Hidden;
            form.ShowDialog();
            id_user = form.user_id;
            this.Close();
        }

    }
}
