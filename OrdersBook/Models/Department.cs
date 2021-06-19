using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace OrdersBook.Models
{
    public class Department
    {
        public int id { get; set; }
        private string title;
        private int head;

        public Worker head_l;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public int Head
        {
            get { return head; }
            set { head = value; }
        }

        public string ShownHead
        {
            get
            {
                if(head_l == null)
                {
                    return "Не назначен.";
                }

                return head_l.Surname;
            }
        }

        public Department() { }

        public Department(string title, int head=0)
        {
            this.title = title;
            if(head != 0)
            {
                this.head = head;
            }
            
        }

    }
}
