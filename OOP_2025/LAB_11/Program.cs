using System.Text.RegularExpressions;

namespace LAB_11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Queue<string> requests = new Queue<string>();

            bool running = true;
            while (running)
            {
                Console.WriteLine("\nМеню:");
                Console.WriteLine("1. Додати заявку");
                Console.WriteLine("2. Обробити заявку");
                Console.WriteLine("3. Подивитися першу заявку");
                Console.WriteLine("4. Показати всі заявки");
                Console.WriteLine("5. Аналіз тексту (Dictionary)");
                Console.WriteLine("6. Вийти");
                Console.Write("Виберіть опцію: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Введіть текст заявки: ");
                        string request = Console.ReadLine();
                        requests.Enqueue(request);
                        Console.WriteLine("Заявку додано!");
                        break;

                    case "2":
                        if (requests.Count > 0)
                        {
                            string processed = requests.Dequeue();
                            Console.WriteLine($"Заявка \"{processed}\" оброблена!");
                        }
                        else
                        {
                            Console.WriteLine("Черга порожня.");
                        }
                        break;

                    case "3":
                        if (requests.Count > 0)
                        {
                            Console.WriteLine($"Перша заявка в черзі: \"{requests.Peek()}\"");
                        }
                        else
                        {
                            Console.WriteLine("Черга порожня.");
                        }
                        break;

                    case "4":
                        if (requests.Count > 0)
                        {
                            Console.WriteLine("Список заявок:");
                            foreach (var r in requests)
                            {
                                Console.WriteLine($"- {r}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Черга порожня.");
                        }
                        break;

                    case "5":
                        Console.WriteLine("Введіть текст для аналізу:");
                        string text = Console.ReadLine();

                        // видалення символів і приведення до нижнього регістру
                        text = Regex.Replace(text.ToLower(), @"[^\w\s]", "");
                        string[] words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                        Dictionary<string, int> wordCount = new Dictionary<string, int>();
                        foreach (string word in words)
                        {
                            if (wordCount.ContainsKey(word))
                                wordCount[word]++;
                            else
                                wordCount[word] = 1;
                        }

                        var sortedWords = wordCount.OrderByDescending(w => w.Value);

                        Console.WriteLine("\nСтатистика слів:");
                        foreach (var pair in sortedWords)
                        {
                            Console.WriteLine($"{pair.Key} — {pair.Value}");
                        }
                        break;

                    case "6":
                        running = false;
                        Console.WriteLine("Програма завершена.");
                        break;

                    default:
                        Console.WriteLine("Невірний вибір, спробуйте ще раз.");
                        break;
                }
            }
        }
    }
}
