// IGreetingService.cs
public interface IGreetingService
{
    void Greet(string name);
}

// GreetingService.cs
public class GreetingService : IGreetingService
{
    public void Greet(string name)
    {
        Console.WriteLine($"Привіт, {name}!");
    }
}

// App.cs
public class App
{
    private readonly IGreetingService _greetingService;

    public App(IGreetingService greetingService)
    {
        _greetingService = greetingService;
    }

    public void Run()
    {
        Console.Write("Введіть ім’я: ");
        string name = Console.ReadLine();
        _greetingService.Greet(name);
    }
}

// Program.cs
using System;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main(string[] args)
    {
        using IHost host = Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                services.AddTransient<IGreetingService, GreetingService>();
                services.AddTransient<App>();
            })
            .Build();

        var app = host.Services.GetRequiredService<App>();
        app.Run();
    }
}
