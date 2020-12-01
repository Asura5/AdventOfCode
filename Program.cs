using System;
using System.Net.Http;
using AdventOfCode_2020.Solutions;
using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode_2020
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var serviceProvider = new ServiceCollection()
                .AddSingleton<HttpClient>()
                .AddLogging();



        }
    }
}
