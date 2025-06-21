#region Strategy

public interface ICalculationStrategy
{
    int Calculate(int a, int b);
}

public class AddStrategy : ICalculationStrategy
{
    public int Calculate(int a, int b) => a + b;
}

public class SubtractStrategy : ICalculationStrategy
{
    public int Calculate(int a, int b) => a - b;
}

public class MultiplyStrategy : ICalculationStrategy
{
    public int Calculate(int a, int b) => a * b;
}

public class Calculator
{
    private ICalculationStrategy _strategy;

    public Calculator(ICalculationStrategy strategy)
    {
        _strategy = strategy;
    }

    public void SetStrategy(ICalculationStrategy strategy)
    {
        _strategy = strategy;
    }

    public int Execute(int a, int b) => _strategy.Calculate(a, b);
}

#endregion

#region Command

public interface ICommand
{
    void Execute();
}

public class OpenFileCommand : ICommand
{
    public void Execute() => Console.WriteLine("Файл відкрито");
}

public class SaveFileCommand : ICommand
{
    public void Execute() => Console.WriteLine("Файл збережено");
}

public class CloseFileCommand : ICommand
{
    public void Execute() => Console.WriteLine("Файл закрито");
}

public class Editor
{
    private readonly List<ICommand> _commands = new();

    public void AddCommand(ICommand command) => _commands.Add(command);

    public void ExecuteCommands()
    {
        foreach (var cmd in _commands)
        {
            cmd.Execute();
        }
        _commands.Clear();
    }
}

#endregion

#region Mediator

public interface IChatMediator
{
    void Register(User user);
    void SendMessage(string message, User sender);
}

public class ChatMediator : IChatMediator
{
    private readonly List<User> _users = new();

    public void Register(User user)
    {
        if (!_users.Contains(user))
        {
            _users.Add(user);
            user.SetMediator(this);
        }
    }

    public void SendMessage(string message, User sender)
    {
        foreach (var user in _users)
        {
            if (user != sender)
                user.Receive(message);
        }
    }
}

public class User
{
    private IChatMediator _mediator;
    public string Name { get; }

    public User(string name)
    {
        Name = name;
    }

    public void SetMediator(IChatMediator mediator)
    {
        _mediator = mediator;
    }

    public void Send(string message)
    {
        Console.WriteLine($"{Name} надсилає: {message}");
        _mediator?.SendMessage(message, this);
    }

    public void Receive(string message)
    {
        Console.WriteLine($"{Name} отримав: {message}");
    }
}

#endregion

#region Observer

public interface IObserver
{
    void Update(string message);
}

public interface IObservable
{
    void Subscribe(IObserver observer);
    void Unsubscribe(IObserver observer);
    void Notify(string message);
}

public class WeatherStation : IObservable
{
    private readonly List<IObserver> _observers = new();

    public void Subscribe(IObserver observer) => _observers.Add(observer);

    public void Unsubscribe(IObserver observer) => _observers.Remove(observer);

    public void Notify(string message)
    {
        foreach (var obs in _observers)
        {
            obs.Update(message);
        }
    }

    // Для імітації зміни погоди
    public void SetTemperature(int temp)
    {
        Notify($"Зміна погоди: +{temp}°C");
    }
}

public class PhoneApp : IObserver
{
    private readonly string _id;
    public PhoneApp(string id) => _id = id;
    public void Update(string message) => Console.WriteLine($"App {_id}: {message}");
}

public class Billboard : IObserver
{
    public void Update(string message) => Console.WriteLine($"Білборд: {message}");
}

#endregion

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Strategy ===");
        Calculator calc = new Calculator(new AddStrategy());
        Console.WriteLine($"10 + 5 = {calc.Execute(10, 5)}");
        calc.SetStrategy(new SubtractStrategy());
        Console.WriteLine($"10 - 5 = {calc.Execute(10, 5)}");
        calc.SetStrategy(new MultiplyStrategy());
        Console.WriteLine($"10 * 5 = {calc.Execute(10, 5)}");
        Console.WriteLine();

        Console.WriteLine("=== Command ===");
        Editor editor = new Editor();
        editor.AddCommand(new OpenFileCommand());
        editor.AddCommand(new SaveFileCommand());
        editor.AddCommand(new CloseFileCommand());
        editor.ExecuteCommands();
        Console.WriteLine();

        Console.WriteLine("=== Mediator ===");
        ChatMediator mediator = new ChatMediator();
        User alice = new User("Аліса");
        User bob = new User("Боб");
        User charlie = new User("Чарлі");
        mediator.Register(alice);
        mediator.Register(bob);
        mediator.Register(charlie);
        alice.Send("Привіт усім!");
        bob.Send("Привіт, Аліса!");
        Console.WriteLine();

        Console.WriteLine("=== Observer ===");
        WeatherStation station = new WeatherStation();
        PhoneApp app1 = new PhoneApp("UA001");
        PhoneApp app2 = new PhoneApp("UA002");
        Billboard board = new Billboard();
        station.Subscribe(app1);
        station.Subscribe(app2);
        station.Subscribe(board);
        station.SetTemperature(26);
    }
}
