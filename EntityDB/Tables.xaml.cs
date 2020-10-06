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
    /// Логика взаимодействия для Tables.xaml
    /// </summary>
    public partial class Tables : Window
    {
        public ServiceReference1.Service1Client cli = new ServiceReference1.Service1Client();
        public Preloader preloader = new Preloader();
        public Tables()
        {
            InitializeComponent();

            preloader.Show();

            cli.selectAllAuthorCompleted += Cli_selectAllAuthorCompleted;
            cli.selectAllAuthorAsync();

            cli.selectAllGenreCompleted += Cli_selectAllGenreCompleted;
            cli.selectAllGenreAsync();

            cli.selectAllJournalCompleted += Cli_selectAllJournalCompleted;
            cli.selectAllJournalAsync();

            cli.selectAllReaderCompleted += Cli_selectAllReaderCompleted;
            cli.selectAllReaderAsync();

            cli.deleteAuthorCompleted += Cli_deleteAuthorCompleted;
            cli.deleteGenreCompleted += Cli_deleteGenreCompleted;
            cli.deleteJournalCompleted += Cli_deleteJournalCompleted;
            cli.deleteReaderCompleted += Cli_deleteReaderCompleted;
        }

        private void Cli_deleteReaderCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            cli.selectAllReaderAsync();
        }

        private void Cli_deleteJournalCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            cli.selectAllJournalAsync();
        }

        private void Cli_deleteGenreCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            cli.selectAllGenreAsync();
        }

        private void Cli_deleteBookCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
        }

        private void Cli_deleteAuthorCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            cli.selectAllAuthorAsync();
        }

        private void Cli_selectAllReaderCompleted(object sender, ServiceReference1.selectAllReaderCompletedEventArgs e)
        {
            dgReader.ItemsSource = e.Result;
            preloader.Close();
            TablesForm.IsEnabled = true;
        }

        private void Cli_selectAllJournalCompleted(object sender, ServiceReference1.selectAllJournalCompletedEventArgs e)
        {
            dgJournal.ItemsSource = e.Result;
        }

        private void Cli_selectAllGenreCompleted(object sender, ServiceReference1.selectAllGenreCompletedEventArgs e)
        {
            dgGenre.ItemsSource = e.Result;
        }

        private void Cli_selectAllAuthorCompleted(object sender, ServiceReference1.selectAllAuthorCompletedEventArgs e)
        {
            dgAuthor.ItemsSource = e.Result;
        }

        private void b_reader_delete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены??", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Button b_delete = (Button)sender;
                cli.deleteReaderAsync((int)b_delete.Tag);
                dgReader.Items.Refresh();
            }
        }

        private void b_refresh_Click(object sender, RoutedEventArgs e)
        {
            cli.selectAllAuthorAsync();
            cli.selectAllGenreAsync();
            cli.selectAllJournalAsync();
            cli.selectAllReaderAsync();
        }

        private void b_author_delete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены??", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Button b_delete = (Button)sender;
                cli.deleteAuthorAsync((int)b_delete.Tag);
            }
        }


        private void b_genre_delete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены??", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Button b_delete = (Button)sender;
                cli.deleteGenreAsync((int)b_delete.Tag);
            }
        }

        private void b_journal_delete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены??", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Button b_delete = (Button)sender;
                cli.deleteJournalAsync((int)b_delete.Tag);
            }
        }

        private void b_edit_genre_Click(object sender, RoutedEventArgs e)
        {
            Add_genre EditGenreForm = new Add_genre();

            Button b_edit = (Button)sender;
            int ID_genre = (int)b_edit.Tag;
            EditGenreForm.SetValue(TagProperty, ID_genre);
            EditGenreForm.t_genrename_edit.Tag = ID_genre;

            for (int i = 0; i < dgGenre.Items.Count; i++)
            {
                if((dgGenre.Items[i] as ServiceReference1.T_Genre).ID_genre==ID_genre)
                {
                    EditGenreForm.t_genrename_edit.Text = (dgGenre.Items[i] as ServiceReference1.T_Genre).Genre_name;
                    EditGenreForm.t_color_edit.Text = (dgGenre.Items[i] as ServiceReference1.T_Genre).Color;
                    break;
                }
            }
            EditGenreForm.ShowDialog();
            cli.selectAllGenreAsync();
        }

        private void b_add_genre_Click(object sender, RoutedEventArgs e)
        {
            Add_genre AddGenreForm = new Add_genre();
            AddGenreForm.ShowDialog();
            cli.selectAllGenreAsync();
        }

        private void b_edit_author_Click(object sender, RoutedEventArgs e)
        {
            Add_author EditAuthorForm = new Add_author();

            Button b_edit = (Button)sender;
            int ID_author = (int)b_edit.Tag;
            
            EditAuthorForm.SetValue(TagProperty, ID_author);
            EditAuthorForm.t_authorname_edit.Tag = ID_author;

            for (int i = 0; i < dgAuthor.Items.Count; i++)
            {
                if((dgAuthor.Items[i] as ServiceReference1.T_Author).ID_author==ID_author)
                {
                    EditAuthorForm.t_authorname_edit.Text = (dgAuthor.Items[i] as ServiceReference1.T_Author).A_name;
                    EditAuthorForm.t_authorsname_edit.Text = (dgAuthor.Items[i] as ServiceReference1.T_Author).A_surname;
                    break;
                }
            }
            EditAuthorForm.ShowDialog();
            cli.selectAllAuthorAsync();
        }

        private void b_edit_reader_Click(object sender, RoutedEventArgs e)
        {
            Add_reader EditReaderForm = new Add_reader();

            Button b_edit = (Button)sender;
            int ID_reader = (int)b_edit.Tag;
            EditReaderForm.SetValue(TagProperty, ID_reader);
            EditReaderForm.t_readername_edit.Tag = ID_reader;

            for (int i = 0; i < dgReader.Items.Count; i++)
            {
                if((dgReader.Items[i] as ServiceReference1.T_Reader).ID_reader == ID_reader)
                {
                    EditReaderForm.t_readername_edit.Text = (dgReader.Items[i] as ServiceReference1.T_Reader).R_name;
                    EditReaderForm.t_readersname_edit.Text = (dgReader.Items[i] as ServiceReference1.T_Reader).R_surname;
                    break;
                }
            }
            EditReaderForm.ShowDialog();
            cli.selectAllReaderAsync();
        }

        private void b_edit_journal_Click(object sender, RoutedEventArgs e)
        {
            Add_journal EditJournalForm = new Add_journal();

            Button b_edit = (Button)sender;
            int ID_journal = (int)b_edit.Tag;
            
            EditJournalForm.SetValue(TagProperty, ID_journal);
            EditJournalForm.c_reader.Tag = ID_journal;

            for (int i = 0; i < dgJournal.Items.Count; i++)
            {
                if((dgJournal.Items[i] as ServiceReference1.T_Journal).ID_journal == ID_journal)
                {
                    for (int a = 0; a < dgReader.Items.Count; a++)
                    {
                        if ((dgJournal.Items[i] as ServiceReference1.T_Journal).T_Reader.R_surname == (dgReader.Items[a] as ServiceReference1.T_Reader).R_surname)
                        {
                            EditJournalForm.c_reader.SelectedIndex = a;
                            break;
                        }
                    }
                    for (int b = 0; b < MainWindow.books.Count; b++)
                    {
                        if ((dgJournal.Items[i] as ServiceReference1.T_Journal).T_Book.Book_name == (MainWindow.books[b] as ServiceReference1.T_Book).Book_name)
                        {
                            EditJournalForm.c_book.SelectedIndex = b;
                            break;
                        }
                    }
                    break;
                }
            }
            EditJournalForm.ShowDialog();
            cli.selectAllJournalAsync();
        }

        private void b_add_author_Click(object sender, RoutedEventArgs e)
        {
            Add_author AddAuthorForm = new Add_author();
            AddAuthorForm.ShowDialog();
            cli.selectAllAuthorAsync();
        }

        private void b_add_journal_Click(object sender, RoutedEventArgs e)
        {
            Add_journal AddJournalForm = new Add_journal();
            AddJournalForm.ShowDialog();
            cli.selectAllJournalAsync();
        }

        private void b_add_reader_Click(object sender, RoutedEventArgs e)
        {
            Add_reader AddReaderForm = new Add_reader();
            AddReaderForm.ShowDialog();
            cli.selectAllReaderAsync();
        }
    }
}
