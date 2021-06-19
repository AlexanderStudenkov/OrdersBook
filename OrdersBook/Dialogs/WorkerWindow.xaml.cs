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
    /// Логика взаимодействия для WorkerWindow.xaml
    /// </summary>
    public partial class WorkerWindow : Window
    {
        public Worker w { get; set; }

        public AppContext db;

        public bool new_mode;

        public MainWindow win;
        public WorkerWindow(Worker w, AppContext db, bool new_mode, MainWindow win)
        {
            this.w = w;
            this.db = db;
            this.new_mode = new_mode;
            this.win = win;

            InitializeComponent();

            surname.Text = w.Surname;
            name.Text = w.Name;

            patronomyc.Text = w.Patranomyc;
            if(w.Birth_date != null && w.Birth_date.Length > 0)
            {
                birth_date.SelectedDate = DateTime.Parse(w.Birth_date);
            }
                

            List<string> genders = new List<string>();
            genders.Add("Мужской");
            genders.Add("Женский");

            gender.ItemsSource = genders;

            gender.SelectedItem = w.ShownGender;

            List<ListBoxItem> lis = new List<ListBoxItem>();

            int index = -1;
            int ind = 0;

            foreach (Department dep in db.Departments)
            {
                var elem = new ListBoxItem();
                elem.Uid = dep.id.ToString();
                elem.Content = dep.Title;
                if (String.Compare(dep.Title,w.ShownDepartment) == 0)
                    index = ind;
                lis.Add(elem);
                ind++;
            }

            department.ItemsSource = lis;
            if (index > -1)
                department.SelectedItem = lis[index];
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            w.Surname = surname.Text;
            w.Name = name.Text;
            w.Patranomyc = patronomyc.Text;
            w.Birth_date = birth_date.SelectedDate.ToString();
            w.Gender = gender.SelectedIndex + 1;
           if(department.SelectedItem != null)
                w.Department = int.Parse(((ListBoxItem)department.SelectedItem).Uid.ToString());

            if (new_mode == true)
            {
                db.Workers.Add(w);
            }    
                
            db.SaveChanges();

            win.My_Refresh();
            this.Close();
        }
    }
}
