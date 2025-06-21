// --- Завдання 1. Adapter ---

// Новий інтерфейс
public interface INewPrinter
{
    void Print(string message);
}

// Старий клас зі старим методом
public class OldPrinter
{
    public void OldPrint(string message)
    {
        Console.WriteLine($"OldPrinter друкує: {message}");
    }
}

// Адаптер, що реалізує новий інтерфейс і використовує старий клас
public class PrinterAdapter : INewPrinter
{
    private readonly OldPrinter _oldPrinter;

    public PrinterAdapter(OldPrinter oldPrinter)
    {
        _oldPrinter = oldPrinter;
    }

    public void Print(string message)
    {
        _oldPrinter.OldPrint(message);
    }
}

// --- Завдання 2. Facade ---

public class Engine
{
    public void Start() => Console.WriteLine("Двигун запущено");
}

public class Battery
{
    public void Start() => Console.WriteLine("Акумулятор живий");
}

public class IgnitionSystem
{
    public void Start() => Console.WriteLine("Запалювання увімкнено");
}

public class CarFacade
{
    private readonly Engine _engine = new Engine();
    private readonly Battery _battery = new Battery();
    private readonly IgnitionSystem _ignition = new IgnitionSystem();

    public void StartCar()
    {
        _battery.Start();
        _ignition.Start();
        _engine.Start();
        Console.WriteLine("Автомобіль заведено");
    }
}

// --- Завдання 3. Decorator ---

public interface IWriter
{
    void Write(string text);
}

public class ConsoleWriter : IWriter
{
    public void Write(string text)
    {
        Console.WriteLine(text);
    }
}

public class TimestampWriter : IWriter
{
    private readonly IWriter _inner;

    public TimestampWriter(IWriter inner)
    {
        _inner = inner;
    }

    public void Write(string text)
    {
        string stamped = $"[{DateTime.Now:HH:mm:ss}] {text}";
        _inner.Write(stamped);
    }
}

// --- Main ---

class Program
{
    static void Main()
    {
        // Adapter
        Console.WriteLine("=== Adapter ===");
        OldPrinter oldPrinter = new OldPrinter();
        INewPrinter adapter = new PrinterAdapter(oldPrinter);
        adapter.Print("Привіт з адаптера!");

        Console.WriteLine();

        // Facade
        Console.WriteLine("=== Facade ===");
        CarFacade car = new CarFacade();
        car.StartCar();

        Console.WriteLine();

        // Decorator
        Console.WriteLine("=== Decorator ===");
        IWriter writer = new TimestampWriter(new ConsoleWriter());
        writer.Write("Привіт, світ!");
    }
}
