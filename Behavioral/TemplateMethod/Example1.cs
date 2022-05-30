using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatten.Practice.Behavioral.TemplateMethod
{
    //Template Method is a behavioral design pattern that allows you to defines a skeleton of an algorithm in a base class 
    //and let subclasses override the steps without changing the overall algorithm’s structure.
    public abstract class DataSorter
    {
        protected int[] nums;
        protected abstract void SortData();

        public void DoWork(int[] data)
        {
            SayHello();
            InitData(data);
            SortData();
            OutputData();
            SayGoodbye();
        }

        protected virtual void SayHello()
        {
            Console.WriteLine("Greeting from DataSorter!");
        }

        protected void InitData(int[] data)
        {
            this.nums = data;
        }

        protected void OutputData()
        {
            PrintArray(this.nums);
        }

        protected virtual void SayGoodbye()
        {
            Console.WriteLine("Goodbye from DataSorter!");
        }

        private void PrintArray(int[] array)
        {
            Console.WriteLine();
            foreach (var i in array)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }
    }

    public class AscDataSorter: DataSorter
    {
        protected override void SortData()
        {
            this.nums = this.nums.OrderBy(i => i).ToArray();
        }

        protected override void SayHello()
        {
            Console.WriteLine("Greeting from ASC DataSorter!");
        }

        protected override void SayGoodbye()
        {
            Console.WriteLine("Goodbye from ASC DataSorter!");
        }
    }

    public class DescDataSorter : DataSorter
    {
        protected override void SortData()
        {
            this.nums = this.nums.OrderByDescending(i => i).ToArray();
        }

        protected override void SayHello()
        {
            Console.WriteLine("Greeting from DESC DataSorter!");
        }

        protected override void SayGoodbye()
        {
            Console.WriteLine("Goodbye from DESC DataSorter!");
        }
    }

    public class Example1Client
    {
        public static void Test()
        {
            int[] data = new int[] { 18, 9, 2,4,1,0,14,22,6,3,7,11,32,10 };
            AscDataSorter asc = new AscDataSorter();
            DescDataSorter desc = new DescDataSorter();
            asc.DoWork(data);
            desc.DoWork(data);
        }

        private void SortData(int[] data, DataSorter sorter)
        {
            sorter.DoWork(data);
        }
    }
}
