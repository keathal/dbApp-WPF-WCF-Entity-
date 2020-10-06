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
    /// Логика взаимодействия для Report.xaml
    /// </summary>
    public partial class Report : Window
    {
        ServiceReference1.Service1Client cli = new ServiceReference1.Service1Client();
        public Report()
        {
            InitializeComponent();

            cli.selectReportCompleted += Cli_selectReportCompleted;
            cli.selectReportAsync();
        }

        private void Cli_selectReportCompleted(object sender, ServiceReference1.selectReportCompletedEventArgs e)
        {
            dgMain.ItemsSource = e.Result;
        }
    }
}
