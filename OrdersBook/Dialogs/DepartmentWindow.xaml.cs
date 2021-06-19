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
    /// Логика взаимодействия для DepartmentWindow.xaml
    /// </summary>
    public partial class DepartmentWindow : Window
    {
        public Department d { get; set; }

        public AppContext db;

        public bool new_mode;

        public MainWindow win;
        public DepartmentWindow(Department d, AppContext db, bool new_mode, MainWindow win)
        {
            this.d = d;
            this.db = db;
            this.new_mode = new_mode;
            this.win = win;

            InitializeComponent();

            title.Text = d.Title;

            List<ListBoxItem> lis = new List<ListBoxItem>();
            int index = -1;
            int ind = 0;

            foreach(Worker worker in db.Workers)
            {
                var elem = new ListBoxItem();
                elem.Uid = worker.id.ToString();
                elem.Content = worker.Surname;
                if (String.Compare(worker.Surname, d.ShownHead) == 0)
                    index = ind;
                lis.Add(elem);
                ind++;
            }

            head.ItemsSource = lis;
            if (index > -1)
                head.SelectedItem = lis[index];
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            d.Title = title.Text;
            
            if (head.SelectedItem != null)
                d.Head = int.Parse(((ListBoxItem)head.SelectedItem).Uid.ToString());

            if (new_mode == true)
            {
                db.Departments.Add(d);
            }

            db.SaveChanges();

            win.My_Refresh();
            this.Close();
        }
    }
}
