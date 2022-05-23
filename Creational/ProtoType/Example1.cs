using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatten.Practice.Creational.ProtoType
{
    public class Person
    {
        public int Age;
        public DateTime BirthDate;
        public string Name;
        public IdInfo IdInfo;

        public Person ShallowCopy()
        {
            return this.MemberwiseClone() as Person;
        }

        public Person DeepCopy()
        {
            var copy = this.MemberwiseClone() as Person;
            copy.IdInfo = new IdInfo(this.IdInfo.IdNumber);
            //copy.Name = string.Copy(Name);
            return copy;
        }
    }

    public class IdInfo
    {
        public int IdNumber;

        public IdInfo(int idNumber)
        {
            this.IdNumber = idNumber;
        }
    }

    public class Example1Client
    {
        public void Test()
        {
            Person p1 = new Person();
            p1.Age = 42;
            p1.BirthDate = Convert.ToDateTime("1977-01-01");
            p1.Name = "Jack Daniels";
            p1.IdInfo = new IdInfo(666);
            DisplayValues(p1);

            Person p2 = p1.ShallowCopy();
            DisplayValues(p2);

            Person p3 = p1.DeepCopy();
            DisplayValues(p3);

            p1.Age = 37;
            p1.BirthDate = Convert.ToDateTime("1983-10-16");
            p1.IdInfo.IdNumber = 12345678;
            p1.Name = "Jim Li";
            Console.WriteLine("<================= after P1 change ==================>");
            DisplayValues(p1);
            DisplayValues(p2);
            DisplayValues(p3);
        }

        private void DisplayValues(Person p)
        {
            Console.WriteLine("      Name: {0:s}, Age: {1:d}, BirthDate: {2:MM/dd/yy}",
                p.Name, p.Age, p.BirthDate);
            Console.WriteLine("      ID#: {0:d}", p.IdInfo.IdNumber);
        }
    }
}
