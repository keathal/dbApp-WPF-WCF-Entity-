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
    public partial class Add_journal : Window
    {
        ServiceReference1.Service1Client cli = new ServiceReference1.Service1Client();
        public Add_journal()
        {
            InitializeComponent();

            cli.resetBooksAsync(0);
            cli.resetBooksCompleted += Cli_resetBooksCompleted;

            cli.selectAllReaderCompleted += Cli_selectAllReaderCompleted;
            cli.selectAllReaderAsync();
        }

        private void Cli_resetBooksCompleted(object sender, ServiceReference1.resetBooksCompletedEventArgs e)
        {
            c_book.ItemsSource = e.Result;
        }

        private void Cli_selectAllReaderCompleted(object sender, ServiceReference1.selectAllReaderCompletedEventArgs e)
        {
            c_reader.ItemsSource = e.Result;
        }

        private void b_edit_Click(object sender, RoutedEventArgs e)
        {
            cli.editJournalCompleted += Cli_editJournalCompleted;
            int book_id = (c_book.SelectedItem as ServiceReference1.T_Book).ID_book;
            int reader_id = (c_reader.SelectedItem as ServiceReference1.T_Reader).ID_reader;
            cli.editJournalAsync((int)c_reader.Tag, book_id, reader_id);
        }

        private void Cli_editJournalCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            this.Close();
        }

        private void b_add_Click(object sender, RoutedEventArgs e)
        {
            cli.addJournalCompleted += Cli_addJournalCompleted;
            int book_id = (c_book.SelectedItem as ServiceReference1.T_Book).ID_book;
            int reader_id = (c_reader.SelectedItem as ServiceReference1.T_Reader).ID_reader;
            cli.addJournalAsync(book_id, reader_id);
        }

        private void Cli_addJournalCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            this.Close();
        }
    }
}
