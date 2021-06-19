using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using OrdersBook.Models;

namespace OrdersBook
{
    public class AppContext : DbContext
    {

        public DbSet<Order> Orders { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Department> Departments { get; set; }

        public AppContext() : base("DefaultConnection")
        {
        }

        public void LinkOrders()
        {
            foreach(Order ord in Orders)
            {
                if(ord.Worker != 0)
                    ord.worker_l = Workers.Find(ord.Worker);
            }
        }

        public void LinkDepartments()
        {
            foreach (Department dep in Departments)
            {
                if (dep.Head != 0)
                    dep.head_l = Workers.Find(dep.Head);
            }
        }

        public void LinkWorkers()
        {
            foreach (Worker worker in Workers)
            {
                if (worker.Department !=0)
                    worker.dep_l = Departments.Find(worker.Department);
            }
        }
    }
}
