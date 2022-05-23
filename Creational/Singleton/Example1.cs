using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatten.Practice.Creational.Singleton
{
    public class Singleton
    {
        private Guid _threadId;
        private static Singleton _instance = null;
        private Singleton()
        {
            _threadId = Guid.NewGuid();
        }
        
        public Guid ThreadId
        {
            get { return _threadId; }
        }

        public static Singleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Singleton();
            }
            return _instance;
        }
    }

    public class ThreadSafeSingleton
    {
        private Guid _threadId;
        private static ThreadSafeSingleton _instance = null;
        private static readonly object _lock = new object();
        private ThreadSafeSingleton()
        {
            _threadId = Guid.NewGuid();
        }

        public static ThreadSafeSingleton GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new ThreadSafeSingleton();
                }
                return _instance;
            }
            else
                return _instance;
        }
    }

    public class Example1Client
    {
        public void Test()
        {
            Console.WriteLine("<======================= Basic Singleton =========================>");
            TestSingleton();
            TestSingleton();
            TestSingleton();
            Console.WriteLine("<======================= Thread Safe Singleton =========================>");
            TestMultiThread();
        }

        public void TestMultiThread()
        {
            Thread process1 = new Thread(() =>
            {
                TestThreadSafeSingleton();
            });
            Thread process2 = new Thread(() =>
            {
                TestThreadSafeSingleton();
            });

            process1.Start();
            process2.Start();

            process1.Join();
            process2.Join();
        }

        private void TestSingleton()
        {
            Singleton instance = Singleton.GetInstance();
            Console.WriteLine($"Instance: {instance.ThreadId}.");
        }

        private void TestThreadSafeSingleton()
        {
            Singleton instance = Singleton.GetInstance();
            Console.WriteLine($"Instance: {instance.ThreadId}.");
        }
    }
}
