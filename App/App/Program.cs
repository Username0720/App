using System;
using StackExchange.Redis;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            var close = "";
            while (true)
            {
                var configuration = new ConfigurationOptions();
                configuration.EndPoints.Add("localhost", 6379);
                var redis = ConnectionMultiplexer.Connect(configuration);
                var db = redis.GetDatabase(7);
                const string key = "firstnumber";
                const string key1 = "secondnumber";
                db.KeyDelete(key);
                db.KeyDelete(key1);
                int n1 = 10;
                int n2 = 1;
                try
                {
                    n1 = Convert.ToInt32(Console.ReadLine());
                    n2 = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e) { Console.WriteLine(e.Message); }
                db.StringSet(key, n1);
                db.StringSet(key1, n2);
                Console.WriteLine("Введите 'exit', чтобы закрыть приложение");
                close = Console.ReadLine();
                if (close == "exit") break;
            }
        }
    }
}
