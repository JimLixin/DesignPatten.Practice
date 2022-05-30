using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatten.Practice.Behavioral.Strategy
{
    public interface ISortStrategy
    {
        int[] Sort(int[] nums);
    }

    public class AscSortStrategy : ISortStrategy
    {
        public int[] Sort(int[] nums)
        {
            return nums.OrderBy(i => i).ToArray();
        }
    }
    public class DescSortStrategy : ISortStrategy
    {
        public int[] Sort(int[] nums)
        {
            return nums.OrderByDescending(i => i).ToArray();
        }
    }

    public class Context
    {
        private ISortStrategy _strategy;
        public Context(ISortStrategy strategy)
        {
            this._strategy = strategy;
        }

        public void SetStrategy(ISortStrategy strategy)
        {
            this._strategy = strategy;
        }

        public int[] DoSort(int[] nums)
        {
            return this._strategy.Sort(nums);
        }
    }

    public class Example1Client
    {
        public static void Test()
        {
            int[] data = new int[] { 3,1,0, 21, 5,9,4, 6,12,10};
            AscSortStrategy asc = new AscSortStrategy();
            DescSortStrategy desc = new DescSortStrategy();
            Context context = new Context(asc);
            var resAsc = context.DoSort(data);
            PrintArray(resAsc);
            context.SetStrategy(desc);
            var resDesc = context.DoSort(data);
            PrintArray(resDesc);
        }

        private static void PrintArray(int[] array)
        {
            Console.WriteLine();
            foreach (var i in array)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }
    }
}
