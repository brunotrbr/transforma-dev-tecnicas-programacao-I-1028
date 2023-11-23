using Microsoft.AspNetCore.Builder;
using System;

namespace WebApplication3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");
            Console.WriteLine("Teste");
            app.Run();
        }
    }
}
