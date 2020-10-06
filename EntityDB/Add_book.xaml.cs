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
    public partial class Add_book : Window
    {
        public ServiceReference1.Service1Client cli = new ServiceReference1.Service1Client();
        public Add_book()
        {
            InitializeComponent();

            cli.selectAllGenreCompleted += Cli_selectAllGenreCompleted;
            cli.selectAllGenreAsync();

            cli.selectAllAuthorCompleted += Cli_selectAllAuthorCompleted;
            cli.selectAllAuthorAsync();
        }

        private void Cli_selectAllAuthorCompleted(object sender, ServiceReference1.selectAllAuthorCompletedEventArgs e)
        {
            cAuthor.ItemsSource = e.Result;
        }

        private void Cli_selectAllGenreCompleted(object sender, ServiceReference1.selectAllGenreCompletedEventArgs e)
        {
            cGenre.ItemsSource = e.Result;
        }

        private void b_add_Click(object sender, RoutedEventArgs e)
        {
            int id_author = (cAuthor.SelectedItem as ServiceReference1.T_Author).ID_author;
            int id_genre = (cGenre.SelectedItem as ServiceReference1.T_Genre).ID_genre;
            cli.addBookCompleted += Cli_addBookCompleted;
            cli.addBookAsync(id_genre, id_author, t_name.Text, Convert.ToBoolean(c_available.IsChecked));
        }

        private void Cli_addBookCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            this.Close();
        }

        private void b_edit_Click(object sender, RoutedEventArgs e)
        {
            int id_author = (cAuthor.SelectedItem as ServiceReference1.T_Author).ID_author;
            int id_genre = (cGenre.SelectedItem as ServiceReference1.T_Genre).ID_genre;


            cli.editBookCompleted += Cli_editBookCompleted;
            cli.editBookAsync((int)t_name.Tag, id_author, id_genre, t_name.Text, Convert.ToBoolean(c_available.IsChecked));
        }

        private void Cli_editBookCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            this.Close();
        }
    }
}
