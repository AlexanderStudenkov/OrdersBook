using OrdersBook.Dialogs;
using OrdersBook.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace OrdersBook
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public AppContext db;

        public MainWindow()
        {
            InitializeComponent();
            My_Refresh();   
        }

        public void My_Refresh()
        {
            db = new AppContext();

            List<Order> orders = db.Orders.ToList();
            List<Worker> workers = db.Workers.ToList();
            List<Department> departmens = db.Departments.ToList();

            db.LinkOrders();
            db.LinkDepartments();
            db.LinkWorkers();


            list_of_orders.ItemsSource = orders;
            list_of_workes.ItemsSource = workers;
            list_of_departments.ItemsSource = departmens;
        }

        private void Create_w(object sender, RoutedEventArgs e)
        {
            WorkerWindow win = new WorkerWindow(new Worker(), db, true, this);
            win.Show();
            //this.Hide();
        }
        
        private void Update_w(object sender, RoutedEventArgs e)
        {
            WorkerWindow win = new WorkerWindow(list_of_workes.SelectedItem as Worker, db, false, this);
            win.Show();
        }

        private void Delete_w(object sender, RoutedEventArgs e)
        {
            db.Workers.Remove(list_of_workes.SelectedItem as Worker);
            db.SaveChanges();
            My_Refresh();
        }

        private void Create_d(object sender, RoutedEventArgs e)
        {
            DepartmentWindow win = new DepartmentWindow(new Department(), db, true, this);
            win.Show();
        }

        private void Update_d(object sender, RoutedEventArgs e)
        {
            DepartmentWindow win = new DepartmentWindow(list_of_departments.SelectedItem as Department, db, false, this);
            win.Show();
        }

        private void Delete_d(object sender, RoutedEventArgs e)
        {
            db.Departments.Remove(list_of_departments.SelectedItem as Department);
            db.SaveChanges();
            My_Refresh();
        }

        private void Create_o(object sender, RoutedEventArgs e)
        {
            OrderWinow win = new OrderWinow(new Order(), db, true, this);
            win.Show();
        }

        private void Update_o(object sender, RoutedEventArgs e)
        {
            OrderWinow win = new OrderWinow(list_of_orders.SelectedItem as Order, db, false, this);
            win.Show();
        }

        private void Delete_o(object sender, RoutedEventArgs e)
        {
            db.Orders.Remove(list_of_orders.SelectedItem as Order);
            db.SaveChanges();
            My_Refresh();
        }
    }
}
