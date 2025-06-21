// Завдання 1: Singleton Logger
public sealed class Logger
{
    private static readonly Logger _instance = new Logger();

    // Приватний конструктор, щоб не створювати екземпляри ззовні
    private Logger() { }

    public static Logger Instance => _instance;

    public void Log(string msg)
    {
        Console.WriteLine($"[{DateTime.Now}] {msg}");
    }
}

// Завдання 2: Factory Method для Notification
public interface INotification
{
    void Send(string message);
}

public class EmailNotification : INotification
{
    public void Send(string message) => Console.WriteLine($"Email: {message}");
}

public class SMSNotification : INotification
{
    public void Send(string message) => Console.WriteLine($"SMS: {message}");
}

public class PushNotification : INotification
{
    public void Send(string message) => Console.WriteLine($"Push: {message}");
}

public static class NotificationFactory
{
    public static INotification Create(string type)
    {
        return type.ToLower() switch
        {
            "email" => new EmailNotification(),
            "sms" => new SMSNotification(),
            "push" => new PushNotification(),
            _ => throw new ArgumentException("Невідомий тип повідомлення")
        };
    }
}

// Завдання 3: Builder для Computer
public class Computer
{
    public string CPU { get; set; }
    public string GPU { get; set; }
    public int RAM { get; set; } // в ГБ
    public int SSD { get; set; } // в ГБ

    public override string ToString()
    {
        return $"CPU: {CPU}, GPU: {GPU}, RAM: {RAM}GB, SSD: {SSD}GB";
    }
}

public class ComputerBuilder
{
    private Computer _computer = new Computer();

    public ComputerBuilder SetCPU(string cpu)
    {
        _computer.CPU = cpu;
        return this;
    }

    public ComputerBuilder SetGPU(string gpu)
    {
        _computer.GPU = gpu;
        return this;
    }

    public ComputerBuilder SetRAM(int ram)
    {
        _computer.RAM = ram;
        return this;
    }

    public ComputerBuilder SetSSD(int ssd)
    {
        _computer.SSD = ssd;
        return this;
    }

    public Computer Build()
    {
        return _computer;
    }
}

// Тестування у Main
class Program
{
    static void Main()
    {
        // Тест Singleton Logger
        var logger1 = Logger.Instance;
        var logger2 = Logger.Instance;
        logger1.Log("Перший лог");
        logger2.Log("Другий лог");

        Console.WriteLine($"Чи однакові екземпляри: {ReferenceEquals(logger1, logger2)}");
        Console.WriteLine();

        // Тест Factory Method
        Console.Write("Введіть тип повідомлення (email/sms/push): ");
        string type = Console.ReadLine();
        try
        {
            INotification notification = NotificationFactory.Create(type);
            notification.Send("Привіт, користувачу!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine();

        // Тест Builder
        Computer gamingPC = new ComputerBuilder()
            .SetCPU("Intel i9")
            .SetGPU("NVIDIA RTX 4090")
            .SetRAM(32)
            .SetSSD(2000)
            .Build();

        Computer officePC = new ComputerBuilder()
            .SetCPU("Intel i5")
            .SetGPU("Integrated")
            .SetRAM(8)
            .SetSSD(512)
            .Build();

        Console.WriteLine("Gaming PC: " + gamingPC);
        Console.WriteLine("Office PC: " + officePC);
    }
}
