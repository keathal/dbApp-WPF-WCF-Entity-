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
    /// Логика взаимодействия для Add_author.xaml
    /// </summary>
    public partial class Add_author : Window
    {
        ServiceReference1.Service1Client cli = new ServiceReference1.Service1Client();
        public Add_author()
        {
            InitializeComponent();
        }

        private void b_add_Click(object sender, RoutedEventArgs e)
        {
            cli.addAuthorCompleted += Cli_addAuthorCompleted;
            cli.addAuthorAsync(t_authorname_edit.Text, t_authorsname_edit.Text);
        }

        private void Cli_addAuthorCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            this.Close();
        }

        private void b_edit_Click(object sender, RoutedEventArgs e)
        {
            cli.editAuthorCompleted += Cli_editAuthorCompleted;
            cli.editAuthorAsync((int)t_authorname_edit.Tag, t_authorname_edit.Text, t_authorsname_edit.Text);
        }

        private void Cli_editAuthorCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            this.Close();
        }
    }
}
