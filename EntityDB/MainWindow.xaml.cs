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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace EntityDB
{
    public partial class MainWindow : Window
    {
        public static List<object> books = new List<object>();
        List<ServiceReference1.T_Reader> readers = new List<ServiceReference1.T_Reader>();
        ServiceReference1.Service1Client cli = new ServiceReference1.Service1Client();
        public Preloader preloader = new Preloader();
        public int user_id=1;

        public MainWindow()
        {
            InitializeComponent();

            preloader.Show();

            cli.selectAllGenreCompleted += Cli_selectAllGenreCompleted;
            cli.selectAllGenreAsync();

            cli.selectAllAuthorCompleted += Cli_selectAllAuthorCompleted;
            cli.selectAllAuthorAsync();

            cli.selectAllReaderCompleted += Cli_selectAllReaderCompleted;
            cli.selectAllReaderAsync();

            Auth authForm = new Auth();
            authForm.ShowDialog();

            /*if (authForm.id_user != 0)
                user_id = authForm.id_user;
            else
                this.Close();*/

            if(user_id!=1)
            {
                b_tables.Visibility = Visibility.Hidden;
                create.Visibility = Visibility.Hidden;
            }

            c_all.IsChecked = true;

            cli.resetBooksCompleted += Cli_resetBooksCompleted;
            cli.resetBooksAsync(user_id);

            cli.selectAllBookCompleted += Cli_selectAllBookCompleted;

            cli.deleteAuthorCompleted += Cli_deleteAuthorCompleted;

            cli.addJournalCompleted += Cli_addJournalCompleted;
        }

        private void Cli_addJournalCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Книга забронирована успешно!");
        }

        private void Cli_selectAllReaderCompleted(object sender, ServiceReference1.selectAllReaderCompletedEventArgs e)
        {
            readers.AddRange(e.Result);
        }

        private void Cli_deleteAuthorCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            cli.resetBooksAsync(user_id);
            dgBooks.Items.Refresh();
        }

        private void Cli_resetBooksCompleted(object sender, ServiceReference1.resetBooksCompletedEventArgs e)
        {
            books.Clear();
            books.AddRange(e.Result);
            dgBooks.ItemsSource = e.Result;
            preloader.Close();
            MainForm.IsEnabled = true;
        }

        private void Cli_selectAllAuthorCompleted(object sender, ServiceReference1.selectAllAuthorCompletedEventArgs e)
        {
            var allAutors = e.Result.ToList();
            ServiceReference1.T_Author emptyAutor = new ServiceReference1.T_Author() { ID_author = -1, A_surname = "Выбрать всё" };
            allAutors.Add(emptyAutor);
            C_author.ItemsSource = allAutors;
            C_author.SelectedItem = emptyAutor;
        }

        private void Cli_selectAllGenreCompleted(object sender, ServiceReference1.selectAllGenreCompletedEventArgs e)
        {
            var allGenres = e.Result.ToList();
            ServiceReference1.T_Genre emptyGenre = new ServiceReference1.T_Genre() { ID_genre = -1, Genre_name = "Выбрать всё" };
            allGenres.Add(emptyGenre);
            C_genre.ItemsSource = allGenres;
            C_genre.SelectedItem = emptyGenre;
        }

        private void Cli_selectAllBookCompleted(object sender, ServiceReference1.selectAllBookCompletedEventArgs e)
        {
            dgBooks.ItemsSource = e.Result;
        }

        private void b_tables_Click(object sender, RoutedEventArgs e)
        {
            Tables TablesForm = new Tables();
            TablesForm.Show();
        }

        private void create_Click(object sender, RoutedEventArgs e)
        {
            Add_book AddBookForm = new Add_book();
            AddBookForm.ShowDialog();
            cli.resetBooksAsync(user_id);
        }

        private void b_edit1_Click(object sender, RoutedEventArgs e)
        {
            Add_book EditBookForm = new Add_book();

            Button b_edit1 = (Button)sender;
            int ID_book = (int)b_edit1.Tag;
            
            EditBookForm.SetValue(TagProperty, ID_book);
            EditBookForm.t_name.Tag = ID_book;

            for (int i = 0; i < dgBooks.Items.Count; i++)
            {
                if((dgBooks.Items[i] as ServiceReference1.T_Book).ID_book==ID_book)
                {
                    EditBookForm.t_name.Text = (dgBooks.Items[i] as ServiceReference1.T_Book).Book_name;
                    for (int a = 0; a < C_genre.Items.Count; a++)
                    {
                        if((dgBooks.Items[i] as ServiceReference1.T_Book).T_Genre.Genre_name == (C_genre.Items[a] as ServiceReference1.T_Genre).Genre_name)
                        {
                            EditBookForm.cGenre.SelectedIndex = a;
                            break;
                        }
                    }
                    for (int b = 0; b < C_author.Items.Count; b++)
                    {
                        if ((dgBooks.Items[i] as ServiceReference1.T_Book).T_Author.A_surname == (C_author.Items[b] as ServiceReference1.T_Author).A_surname)
                        {
                            EditBookForm.cAuthor.SelectedIndex = b;
                            break;
                        }
                    }

                    EditBookForm.c_available.IsChecked = Convert.ToBoolean((dgBooks.Items[i] as ServiceReference1.T_Book).Available);
                    break;
                }
            }
            EditBookForm.ShowDialog();
            cli.resetBooksAsync(user_id);
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cli.resetBooksAsync(user_id);
        }

        private void b_delete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены??", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Button b_delete = (Button)sender;
                cli.deleteBookAsync((int)b_delete.Tag);
                cli.resetBooksAsync(user_id);
            }
        }

        private void b_search_Click(object sender, RoutedEventArgs e)
        {
            string book_name = t_bookname.Text == "Название книги" || t_bookname.Text == "" ? "" : t_bookname.Text;
            int id_author = (C_author.SelectedItem as ServiceReference1.T_Author).ID_author;
            int id_genre = (C_genre.SelectedItem as ServiceReference1.T_Genre).ID_genre;
            cli.selectAllBookAsync(user_id, id_author, id_genre, book_name, c_available.IsChecked, Convert.ToBoolean(c_all.IsChecked));
        }

        private void b_book_Click(object sender, RoutedEventArgs e)
        {
            Button b_book =(Button)sender;
            int id = (int)b_book.Tag;
            int id_reader=0;
            string book_name="";

            for (int i = 0; i < books.Count; i++)
            {
                if((books[i] as ServiceReference1.T_Book_my).ID_book==id)
                {
                    book_name = (books[i] as ServiceReference1.T_Book_my).Book_name;
                    break;
                }
            }

            for (int i = 0; i < readers.Count; i++)
            {
                if((readers[i] as ServiceReference1.T_Reader).ID_reader==user_id)
                {
                    id_reader = (readers[i] as ServiceReference1.T_Reader).ID_reader;
                    break;
                }
            }

            if (MessageBox.Show("Забронировать книгу '" + book_name + "'", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                cli.addJournalAsync(id, id_reader);
            }
        }

        private void b_exit_Click(object sender, RoutedEventArgs e)
        {
            MainForm.IsEnabled = false;
            Auth authForm = new Auth();
            authForm.ShowDialog();
            if (authForm.id_user != 0)
            {
                user_id = authForm.id_user;
                cli.resetBooksAsync(user_id);
            }
            else
                this.Close();

            if (user_id != 1)
            {
                b_tables.Visibility = Visibility.Hidden;
                create.Visibility = Visibility.Hidden;
            }
            else
            {
                b_tables.Visibility = Visibility.Visible;
                create.Visibility = Visibility.Visible;
            }
        }

        private void btn_chat_Click(object sender, RoutedEventArgs e)
        {
            Chat chat = new Chat();
            chat.isConnected = true;
            chat.user_id = user_id;
            chat.Show();
        }

        private void b_report_Click(object sender, RoutedEventArgs e)
        {
            Report form = new Report();
            form.Show();
        }
    }
}
 