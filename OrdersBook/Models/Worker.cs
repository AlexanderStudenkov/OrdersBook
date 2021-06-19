using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersBook.Models
{
    public class Worker
    {
        public int id { get; set; }
        private string surname;
        private string name;
        private string patranomyc;
        private string birth_date;
        private int gender;
        private int department;

        public Department dep_l;

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Patranomyc
        {
            get { return patranomyc; }
            set { patranomyc = value; }
        }

        public string Birth_date
        {
            get { return birth_date; }
            set { birth_date = value; }
        }

        public int Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public int Department
        {
            get { return department; }
            set { department = value; }
        }

        public string ShownGender
        {
            get 
            {
                if(this.gender == 1)
                {
                    return "Мужской";
                }

                if (this.gender == 2)
                {
                    return "Женский";
                }

                return "Ошибка";
            }
            
        }

        public string ShownDepartment
        {
            get
            {
                if(dep_l == null)
                {
                    return "Не назначен.";
                }

                return dep_l.Title;
            }
        }

        public Worker() { }

        public Worker(string surname, string name, string patronomyc, string birth_date, int gender, int department=0)
        {
            this.surname = surname;
            this.name = name;
            this.patranomyc = patronomyc;
            this.birth_date = birth_date;
            this.gender = gender;
            
            if(department != 0)
            {
                this.department = department;
            }
        }
    }
}
