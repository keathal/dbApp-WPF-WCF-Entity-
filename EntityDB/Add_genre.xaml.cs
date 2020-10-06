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
    /// Логика взаимодействия для Add_genre.xaml
    /// </summary>
    public partial class Add_genre : Window
    {
        public ServiceReference1.Service1Client cli = new ServiceReference1.Service1Client();
        public Add_genre()
        {
            InitializeComponent();
        }

        private void b_add_Click(object sender, RoutedEventArgs e)
        {
            cli.addGenreCompleted += Cli_addGenreCompleted;
            cli.addGenreAsync(t_genrename_edit.Text, t_color_edit.Text);
        }

        private void Cli_addGenreCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            this.Close();
        }

        private void b_edit_Click(object sender, RoutedEventArgs e)
        {
            cli.editGenreCompleted += Cli_editGenreCompleted;
            cli.editGenreAsync((int)t_genrename_edit.Tag, t_genrename_edit.Text, t_color_edit.Text);
        }

        private void Cli_editGenreCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            this.Close();
        }
    }
}
