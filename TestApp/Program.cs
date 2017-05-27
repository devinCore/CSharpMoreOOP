using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TimeSpan time = TimeSpan.FromHours(1);

            Console.WriteLine($"time init: {time}");
            Console.WriteLine($"total hours: {time.TotalHours}");
            Console.WriteLine($"total days: {time.TotalDays}");
            Console.WriteLine($"total minutes: {time.TotalMinutes}");


            Console.ReadLine();
        }
    }
}
