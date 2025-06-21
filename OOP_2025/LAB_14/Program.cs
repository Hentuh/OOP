namespace LAB_14
{
    class Program
    {
        static void Main()
        {
            // Масив файлів для обробки
            string[] fileNames = { "log1.txt", "log2.txt", "log3.txt" };

            // Створення масиву задач
            Task[] tasks = new Task[fileNames.Length];

            // Запуск кожного завдання на окремий файл
            for (int i = 0; i < fileNames.Length; i++)
            {
                int fileIndex = i; // Локальна копія індексу
                tasks[i] = Task.Run(() => ProcessFile(fileNames[fileIndex]));
            }

            // Очікування завершення всіх задач
            Task.WhenAll(tasks).Wait();

            Console.WriteLine("Обробка файлів завершена!");
        }

        static void ProcessFile(string fileName)
        {
            int errorCount = 0;

            try
            {
                // Читання всіх рядків з файлу
                var lines = File.ReadAllLines(fileName);

                // Підрахунок рядків, що містять "ERROR"
                foreach (var line in lines)
                {
                    if (line.Contains("ERROR"))
                    {
                        errorCount++;
                    }
                }

                Console.WriteLine($"Файл {fileName}: знайдено {errorCount} помилок.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при обробці файлу {fileName}: {ex.Message}");
            }
        }
    }
}
