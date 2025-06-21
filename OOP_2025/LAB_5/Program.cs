namespace LAB_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Лабораторна робота №5 (все в Main) ===\n");

            // --- Завдання 1: перевірка парності числа ---
            Console.WriteLine("Завдання 1: Введіть ціле число:");
            if (int.TryParse(Console.ReadLine(), out int number))
            {
                bool isEven = (number % 2 == 0);
                Console.WriteLine($"Число {number} {(isEven ? "парне" : "непарне")}\n");
            }
            else
            {
                Console.WriteLine("Введено не число!\n");
            }

            // --- Завдання 2: перевантаження функції (суми) ---
            Console.WriteLine("Завдання 2: Введіть два цілих числа через пробіл:");
            string[] parts = Console.ReadLine().Split(' ');
            if (parts.Length == 2
                && int.TryParse(parts[0], out int a)
                && int.TryParse(parts[1], out int b))
            {
                Console.WriteLine($"Сума {a} + {b} = {a + b}\n");
            }
            else
            {
                Console.WriteLine("Помилка вводу!\n");
            }

            Console.WriteLine("Завдання 2 (продовження): Введіть три цілих числа:");
            parts = Console.ReadLine().Split(' ');
            if (parts.Length == 3
                && int.TryParse(parts[0], out a)
                && int.TryParse(parts[1], out b)
                && int.TryParse(parts[2], out int c))
            {
                Console.WriteLine($"Сума {a} + {b} + {c} = {a + b + c}\n");
            }
            else
            {
                Console.WriteLine("Помилка вводу!\n");
            }

            Console.WriteLine("Завдання 2 (double): Введіть два числа з плаваючою комою:");
            parts = Console.ReadLine().Split(' ');
            if (parts.Length == 2
                && double.TryParse(parts[0], out double da)
                && double.TryParse(parts[1], out double db))
            {
                Console.WriteLine($"Сума {da} + {db} = {da + db}\n");
            }
            else
            {
                Console.WriteLine("Помилка вводу!\n");
            }

            // --- Завдання 3: Swap через ref (імітація в Main) ---
            Console.WriteLine("Завдання 3: Введіть два числа для обміну:");
            parts = Console.ReadLine().Split(' ');
            if (parts.Length == 2
                && int.TryParse(parts[0], out a)
                && int.TryParse(parts[1], out b))
            {
                Console.WriteLine($"Початкові: a = {a}, b = {b}");
                int temp = a;
                a = b;
                b = temp;
                Console.WriteLine($"Після обміну: a = {a}, b = {b}\n");
            }
            else
            {
                Console.WriteLine("Помилка вводу!\n");
            }

            Console.WriteLine("=== Кінець роботи ===");
        }
    }
}
