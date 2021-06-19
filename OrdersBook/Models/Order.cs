using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersBook.Models
{
    public class Order
    {
        public int id { get; set; }
        private string contragent;
        private int worker;

        public Worker worker_l;
        
        public string Contragent
        {
            get { return contragent; }
            set { contragent = value; }
        }

        public int Worker
        {
            get { return worker; }
            set { worker = value; }
        }

        public string ShownWorker
        {
            get
            { 
                if(worker_l != null)
                    return worker_l.Surname;

                return "Не назнвчен";
            }
        }

        public void LinkWorker()
        {

        }

        public Order() { }

        public Order(string contragent, int worker)
        {
            this.contragent = contragent;
            this.worker = worker;
        }
    }
}
