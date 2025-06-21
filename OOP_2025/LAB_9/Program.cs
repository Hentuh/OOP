namespace LAB_9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Лабораторна робота №9 ===\n");

            int[] numbers = { 8, 5, 2, 9, 1, 5, 6 };
            int swaps = 0;

            Console.WriteLine("Початковий масив: [" + string.Join(", ", numbers) + "]");

            // Алгоритм сортування бульбашкою
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = 0; j < numbers.Length - 1 - i; j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        // обмін елементів
                        int temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;
                        swaps++;
                    }
                }
            }

            Console.WriteLine($"Кількість перестановок: {swaps}");
            Console.WriteLine("Після сортування: [" + string.Join(", ", numbers) + "]");

            Console.WriteLine("\n=== Кінець роботи ===");
        }
    }
}
