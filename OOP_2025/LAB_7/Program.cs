namespace LAB_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Лабораторна робота №7 ===\n");

            // Завдання 1: Виведення парних чисел (for)
            Console.WriteLine("Завдання 1: Парні числа від 2 до 20:");
            for (int i = 2; i <= 20; i += 2)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("\n");

            // Завдання 2: Підрахунок суми (while)
            Console.WriteLine("Завдання 2: Введення чисел і обчислення суми (0 — завершення):");
            int sum = 0;
            int input;
            while (true)
            {
                Console.Write("Введіть число: ");
                input = int.Parse(Console.ReadLine());
                if (input == 0)
                    break;
                sum += input;
            }
            Console.WriteLine($"Сума: {sum}\n");

            // Завдання 3: Введення пароля (do-while)
            Console.WriteLine("Завдання 3: Введення пароля");
            string password;
            do
            {
                Console.Write("Введіть пароль: ");
                password = Console.ReadLine();
                if (password != "1234")
                    Console.WriteLine("Неправильний пароль!");
            }
            while (password != "1234");
            Console.WriteLine("Доступ дозволено!\n");

            Console.WriteLine("=== Кінець роботи ===");
        }
    }
}
