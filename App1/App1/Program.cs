using StackExchange.Redis;
using System;

namespace App1
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
                RedisChannel redisChannel = "warnings";
                const string key = "firstnumber";
                const string key1 = "secondnumber";
                if (db.KeyExists(key) && db.KeyExists(key1))
                {
                    int firstnumber = Convert.ToInt32(db.StringGet(key));
                    int secondnumber = Convert.ToInt32(db.StringGet(key1));
                    int result = firstnumber * secondnumber;
                    Console.WriteLine(result);
                }
                else Console.WriteLine("ключи не существуют");
                Console.WriteLine("Введите 'exit', чтобы закрыть приложение");
                close = Console.ReadLine();
                if (close == "exit") break;
            }
        }
    }
}
