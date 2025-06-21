namespace LAB_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Лабораторна робота №6 ===\n");

            // Завдання 1: перевірка парності числа
            Console.WriteLine("Завдання 1: Введіть ціле число:");
            int num1 = int.Parse(Console.ReadLine());
            if (num1 % 2 == 0)
                Console.WriteLine("Результат: Число парне.\n");
            else
                Console.WriteLine("Результат: Число непарне.\n");

            // Завдання 2: перевірка оцінки
            Console.WriteLine("Завдання 2: Введіть вашу оцінку (0–100):");
            int score = int.Parse(Console.ReadLine());
            if (score >= 90 && score <= 100)
                Console.WriteLine("Ваша оцінка: A\n");
            else if (score >= 75)
                Console.WriteLine("Ваша оцінка: B\n");
            else if (score >= 60)
                Console.WriteLine("Ваша оцінка: C\n");
            else
                Console.WriteLine("Ваша оцінка: F\n");

            // Завдання 3: визначення дня тижня
            Console.WriteLine("Завдання 3: Введіть число (1–7):");
            int day = int.Parse(Console.ReadLine());
            switch (day)
            {
                case 1: Console.WriteLine("Понеділок\n"); break;
                case 2: Console.WriteLine("Вівторок\n"); break;
                case 3: Console.WriteLine("Середа\n"); break;
                case 4: Console.WriteLine("Четвер\n"); break;
                case 5: Console.WriteLine("П’ятниця\n"); break;
                case 6: Console.WriteLine("Субота\n"); break;
                case 7: Console.WriteLine("Неділя\n"); break;
                default: Console.WriteLine("Неправильне число\n"); break;
            }

            // Завдання 4: вибір автомобіля
            Console.WriteLine("Завдання 4: Введіть марку авто (Toyota, BMW, Tesla):");
            string car = Console.ReadLine();
            switch (car)
            {
                case "Toyota": Console.WriteLine("Країна: Японія\n"); break;
                case "BMW": Console.WriteLine("Країна: Німеччина\n"); break;
                case "Tesla": Console.WriteLine("Країна: США\n"); break;
                default: Console.WriteLine("Марку не знайдено\n"); break;
            }

            // Завдання 5: тернарний оператор
            Console.WriteLine("Завдання 5: Введіть температуру:");
            int temp = int.Parse(Console.ReadLine());
            string weather = temp >= 0 ? "Погода тепла." : "Погода холодна.";
            Console.WriteLine("Результат: " + weather + "\n");

            // Завдання 6: try-catch
            Console.WriteLine("Завдання 6: Введіть два числа:");
            try
            {
                int a = int.Parse(Console.ReadLine());
                int b = int.Parse(Console.ReadLine());
                int result = a / b;
                Console.WriteLine($"Результат: {a} / {b} = {result}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Помилка: поділ на нуль!");
            }

            Console.WriteLine("\n=== Кінець роботи ===");
        }
    }
}
