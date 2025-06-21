using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    // --- Завдання 1 ---
    static void PrintNumbers()
    {
        for (int i = 1; i <= 500; i++)
        {
            Console.Write($"{i} ");
        }
        Console.WriteLine();
    }

    static long CalculateFactorial(int n)
    {
        long result = 1;
        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }
        Console.WriteLine($"Факторіал {n} = {result}");
        return result;
    }

    static void Task1_ParallelInvoke()
    {
        Console.WriteLine("=== Завдання 1: Parallel.Invoke ===");
        Stopwatch stopwatch = Stopwatch.StartNew();

        Parallel.Invoke(
            () => PrintNumbers(),
            () => CalculateFactorial(10)
        );

        stopwatch.Stop();
        Console.WriteLine($"⏳ Час виконання: {stopwatch.ElapsedMilliseconds} мс\n");
    }

    // --- Завдання 2 ---
    static int counter = 0;
    static object locker = new object();

    // Без потокобезпеки — буде неправильний результат
    static void Task2_WithoutThreadSafety()
    {
        counter = 0;
        Parallel.For(0, 1000, i =>
        {
            counter++; // Гонка потоків!
        });
        Console.WriteLine($"Без потокобезпеки: counter = {counter} (очікується 1000)");
    }

    // Захист за допомогою lock
    static void Task2_WithLock()
    {
        counter = 0;
        Parallel.For(0, 1000, i =>
        {
            lock (locker)
            {
                counter++;
            }
        });
        Console.WriteLine($"З lock: counter = {counter} (очікується 1000)");
    }

    // Захист за допомогою Interlocked.Increment
    static void Task2_WithInterlocked()
    {
        counter = 0;
        Parallel.For(0, 1000, i =>
        {
            Interlocked.Increment(ref counter);
        });
        Console.WriteLine($"З Interlocked.Increment: counter = {counter} (очікується 1000)");
    }

    static void Main()
    {
        // Виконуємо Завдання 1
        Task1_ParallelInvoke();

        // Виконуємо Завдання 2
        Console.WriteLine("=== Завдання 2: Race Condition та потокобезпека ===");
        Task2_WithoutThreadSafety();
        Task2_WithLock();
        Task2_WithInterlocked();
    }
}
