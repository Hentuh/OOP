namespace LAB_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Лабораторна робота №8 ===\n");

            // Завдання 1: фільтрація чисел, що діляться на 3 або 5
            Console.WriteLine("Завдання 1: Числа, що діляться на 3 або 5:");
            int[] numbers = { 12, 15, 7, 20, 33, 50, 8, 11, 90, 45 };
            int sum = 0;

            foreach (int num in numbers)
            {
                if (num % 3 == 0 || num % 5 == 0)
                {
                    Console.Write(num + " ");
                    sum += num;
                }
            }

            Console.WriteLine($"\nСума таких чисел: {sum}\n");

            // Завдання 2: аналіз цін товарів
            Console.WriteLine("Завдання 2: Аналіз цін товарів");

            string[] productNames = { "Хліб", "Молоко", "Яблука", "Сир", "Шоколад", "Кава", "Чай" };
            double[] productPrices = { 25.5, 32.0, 45.3, 120.0, 80.0, 150.0, 75.5 };

            // Середня ціна
            double total = 0;
            for (int i = 0; i < productPrices.Length; i++)
            {
                total += productPrices[i];
            }
            double average = total / productPrices.Length;
            Console.WriteLine($"Середня ціна: {average:F2}");

            // Товари, дорожчі за середню
            Console.WriteLine("\nТовари дорожчі за середню:");
            for (int i = 0; i < productPrices.Length; i++)
            {
                if (productPrices[i] > average)
                {
                    Console.WriteLine($"{productNames[i]} — {productPrices[i]} грн");
                }
            }

            // Пошук найдешевшого та найдорожчого
            int minIndex = 0;
            int maxIndex = 0;

            for (int i = 1; i < productPrices.Length; i++)
            {
                if (productPrices[i] < productPrices[minIndex])
                    minIndex = i;
                if (productPrices[i] > productPrices[maxIndex])
                    maxIndex = i;
            }

            Console.WriteLine($"\nНайдешевший товар: {productNames[minIndex]} — {productPrices[minIndex]} грн");
            Console.WriteLine($"Найдорожчий товар: {productNames[maxIndex]} — {productPrices[maxIndex]} грн");

            Console.WriteLine("\n=== Кінець роботи ===");
        }
    }
}
