// Завдання 1: IAnimal та реалізації Dog, Cat
public interface IAnimal
{
    void Speak();
    void Eat();
}

public class Dog : IAnimal
{
    public void Speak()
    {
        Console.WriteLine("Собака гавкає: Гав-гав!");
    }

    public void Eat()
    {
        Console.WriteLine("Собака їсть корм.");
    }
}

public class Cat : IAnimal
{
    public void Speak()
    {
        Console.WriteLine("Кіт нявкає: Мяу!");
    }

    public void Eat()
    {
        Console.WriteLine("Кіт їсть рибу.");
    }
}

// Завдання 2: IPaymentMethod і оплати

public interface IPaymentMethod
{
    void Pay(decimal amount);
}

public class CreditCard : IPaymentMethod
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Оплата кредитною карткою: {amount} грн");
    }
}

public class PayPal : IPaymentMethod
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Оплата через PayPal: {amount} грн");
    }
}

public class ApplePay : IPaymentMethod
{
    public void Pay(decimal amount)
    {
        Console.WriteLine($"Оплата через ApplePay: {amount} грн");
    }
}

public class Order
{
    public IPaymentMethod PaymentMethod { get; set; }

    public Order(IPaymentMethod paymentMethod)
    {
        PaymentMethod = paymentMethod;
    }

    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine("Обробка платежу...");
        PaymentMethod.Pay(amount);
        Console.WriteLine("Платіж завершено.\n");
    }
}

class Program
{
    static void Main()
    {
        // Тестування завдання 1: список тварин
        Console.WriteLine("=== Завдання 1: Тварини ===");
        List<IAnimal> animals = new List<IAnimal> { new Dog(), new Cat() };
        foreach (var animal in animals)
        {
            animal.Speak();
            animal.Eat();
            Console.WriteLine();
        }

        // Тестування завдання 2: різні способи оплати
        Console.WriteLine("=== Завдання 2: Платіжна система ===");
        Order order1 = new Order(new CreditCard());
        order1.ProcessPayment(500);

        Order order2 = new Order(new PayPal());
        order2.ProcessPayment(250);

        Order order3 = new Order(new ApplePay());
        order3.ProcessPayment(300);
    }
}
