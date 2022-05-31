using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatten.Practice.Structural.Adapter
{
    //Adapter is a structural design pattern, which allows incompatible objects to collaborate.
    //The Adapter acts as a wrapper between two objects.
    ////It catches calls for one object and transforms them to format and interface recognizable by the second object.
    public interface IStringDate
    {
        string GetDate();
    }

    //Target Service
    public class DateGenerator
    {
        public DateTime GetDate()
        {
            return DateTime.Now;
        }
    }

    //Adapter
    public class StringDateAdapter: IStringDate
    {
        private DateGenerator _dateGenerator;
        public StringDateAdapter(DateGenerator dateGenerator)
        {
            this._dateGenerator = dateGenerator;
        }
        public string GetDate()
        {
            return this._dateGenerator.GetDate().ToString("yyyy-MM-dd hh:mm:ss");
        }
    }

    //Client
    public class Example1Client
    {
        public static void Test()
        {
            DateGenerator generator = new DateGenerator();
            StringDateAdapter client = new StringDateAdapter(generator);
            Console.WriteLine(client.GetDate());
        }
    }
}
