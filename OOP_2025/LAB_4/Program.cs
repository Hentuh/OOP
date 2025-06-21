using System;

namespace LAB_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== Лабораторна робота №4 ===\n");

            Task1_Variables();
            Task2_TypeConversion();
            Task3_UserInput();
            Task4_SpeedCalculation();
            Task5_StringManipulation();
        }

        // Завдання 1: Оголошення змінних
        static void Task1_Variables()
        {
            int age = 25;
            double weight = 72.5;
            char grade = 'A';
            bool isStudent = true;
            string name = "Олександр";

            Console.WriteLine("=== Завдання 1 ===");
            Console.WriteLine($"Вік: {age}");
            Console.WriteLine($"Вага: {weight}");
            Console.WriteLine($"Оцінка: {grade}");
            Console.WriteLine($"Студент: {isStudent}");
            Console.WriteLine($"Ім'я: {name}\n");
        }

        // Завдання 2: Перетворення типів
        static void Task2_TypeConversion()
        {
            Console.WriteLine("=== Завдання 2 ===");
            Console.Write("Введіть число (типу double): ");
            string input = Console.ReadLine();
            double doubleValue = double.Parse(input);
            int intValue = (int)doubleValue;
            string stringValue = intValue.ToString();

            Console.WriteLine($"Double: {doubleValue}");
            Console.WriteLine($"Int: {intValue}");
            Console.WriteLine($"String: {stringValue}\n");
        }

        // Завдання 3: Консольний ввід/вивід
        static void Task3_UserInput()
        {
            Console.WriteLine("=== Завдання 3 ===");
            Console.Write("Введіть ваше ім'я: ");
            string name = Console.ReadLine();

            Console.Write("Введіть ваш вік: ");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine($"Привіт, {name}! Твій вік: {age} років.\n");
        }

        // Завдання 4: Арифметичні операції
        static void Task4_SpeedCalculation()
        {
            Console.WriteLine("=== Завдання 4 ===");
            Console.Write("Введіть відстань (км): ");
            double distance = double.Parse(Console.ReadLine());

            Console.Write("Введіть час (год): ");
            double time = double.Parse(Console.ReadLine());

            double speed = distance / time;
            Console.WriteLine($"Середня швидкість: {speed} км/год\n");
        }

        // Завдання 5: Робота з рядками
        static void Task5_StringManipulation()
        {
            Console.WriteLine("=== Завдання 5 ===");
            Console.Write("Введіть речення: ");
            string sentence = Console.ReadLine();

            Console.WriteLine($"Довжина: {sentence.Length} символів");
            Console.WriteLine($"Верхній регістр: {sentence.ToUpper()}");
            Console.WriteLine($"Замінені пробіли: {sentence.Replace(' ', '_')}");
            Console.WriteLine($"Перші 5 символів: {sentence.Substring(0, Math.Min(5, sentence.Length))}\n");
        }
    }
}
