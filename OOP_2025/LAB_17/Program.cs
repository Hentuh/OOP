public class Student
{
    private string name;
    private int age;

    public string Name
    {
        get => name;
        set => name = value;
    }

    public int Age
    {
        get => age;
        set
        {
            if (value >= 0 && value <= 120)
            {
                age = value;
            }
            else
            {
                Console.WriteLine("Некоректний вік. Вік має бути від 0 до 120.");
            }
        }
    }
}

public class Car
{
    private int speed;

    // Властивість лише для читання
    public int Speed => speed;

    // Додає швидкість
    public void Accelerate(int amount)
    {
        if (amount > 0)
        {
            speed += amount;
            Console.WriteLine($"Автомобіль розігнався на {amount} км/год. Поточна швидкість: {speed} км/год.");
        }
    }

    // Зменшує швидкість, не допускаючи менше 0
    public void Brake(int amount)
    {
        if (amount > 0)
        {
            speed -= amount;
            if (speed < 0)
            {
                speed = 0;
            }
            Console.WriteLine($"Автомобіль загальмував на {amount} км/год. Поточна швидкість: {speed} км/год.");
        }
    }
}

class Program
{
    static void Main()
    {
        // Тестування Student
        Console.WriteLine("=== Тестування класу Student ===");
        Student student = new Student();
        student.Name = "Андрій";
        student.Age = 25;
        Console.WriteLine($"Ім'я: {student.Name}, Вік: {student.Age}");
        student.Age = -5; // некоректний вік

        Console.WriteLine();

        // Тестування Car
        Console.WriteLine("=== Тестування класу Car ===");
        Car car = new Car();
        car.Accelerate(50);
        car.Accelerate(30);
        car.Brake(20);
        car.Brake(70); // неправильне гальмування, швидкість не має стати від'ємною
        Console.WriteLine($"Фінальна швидкість: {car.Speed} км/год");
    }
}
