using OrdersBook.Models;
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

namespace OrdersBook.Dialogs
{
    /// <summary>
    /// Логика взаимодействия для OrderWinow.xaml
    /// </summary>
    public partial class OrderWinow : Window
    {
        public Order o { get; set; }

        public AppContext db;

        public bool new_mode;

        public MainWindow win;
        public OrderWinow(Order o, AppContext db, bool new_mode, MainWindow win)
        {
            this.o = o;
            this.db = db;
            this.new_mode = new_mode;
            this.win = win;

            InitializeComponent();

            contagent.Text = o.Contragent;

            List<ListBoxItem> lis = new List<ListBoxItem>();
            int index = -1;
            int ind = 0;

            foreach (Worker worker in db.Workers)
            {
                var elem = new ListBoxItem();
                elem.Uid = worker.id.ToString();
                elem.Content = worker.Surname;
                if (String.Compare(worker.Surname, o.ShownWorker) == 0)
                    index = ind;
                lis.Add(elem);
                ind++;
            }

            author.ItemsSource = lis;
            if (index > -1)
                author.SelectedItem = lis[index];
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            o.Contragent = contagent.Text;

            if (author.SelectedItem != null)
                o.Worker = int.Parse(((ListBoxItem)author.SelectedItem).Uid.ToString());

            if (new_mode == true)
            {
                db.Orders.Add(o);
            }

            db.SaveChanges();

            win.My_Refresh();
            this.Close();
        }
    }
}
