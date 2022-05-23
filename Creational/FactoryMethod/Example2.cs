using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatten.Practice.Creational.FactoryMethod
{
    public interface IGreetingBot
    {
        string Greeting();
    }

    public class ChineseGreetingBot: IGreetingBot
    {
        public string Greeting()
        {
            return "你好!";
        }
    }

    public class EnglishGreetingBot : IGreetingBot
    {
        public string Greeting()
        {
            return "Hello!";
        }
    }

    public abstract class GreetingBotFactory
    {
        protected abstract IGreetingBot GetBot();

        public string MakeGreeting()
        {
            var bot = GetBot();
            return bot.Greeting();
        }
    }

    public class ChineseBotFactory: GreetingBotFactory
    {
        protected override IGreetingBot GetBot()
        {
            return new ChineseGreetingBot();
        }
    }

    public class EnglishBotFactory : GreetingBotFactory
    {
        protected override IGreetingBot GetBot()
        {
            return new EnglishGreetingBot();
        }
    }

    public class Example2Client
    {
        public void Test()
        {
            ClientWork(new ChineseBotFactory());
            Console.WriteLine("");
            ClientWork(new EnglishBotFactory());
        }

        private void ClientWork(GreetingBotFactory factory)
        {
            Console.WriteLine("Client: I'm not aware of the creator's class, but it still works.\n" + factory.MakeGreeting());
        }
    }
}
