public class Container<T>
{
    public T Value { get; set; }

    public void ShowInfo()
    {
        Console.WriteLine($"Значення: {Value}, Тип: {Value.GetType().Name}");
    }
}

class Program
{
    // Узагальнений метод пошуку максимального елемента
    public static T FindMax<T>(T[] array) where T : IComparable<T>
    {
        if (array == null || array.Length == 0)
            throw new ArgumentException("Масив не може бути пустим.");

        T max = array[0];
        foreach (T item in array)
        {
            if (item.CompareTo(max) > 0)
            {
                max = item;
            }
        }
        return max;
    }

    static void Main()
    {
        // Завдання 1: тест Container<T>
        Container<int> intBox = new Container<int> { Value = 42 };
        Container<string> strBox = new Container<string> { Value = "Hello" };

        intBox.ShowInfo();   // Виведе: Значення: 42, Тип: Int32
        strBox.ShowInfo();   // Виведе: Значення: Hello, Тип: String

        Console.WriteLine();

        // Завдання 2: тест FindMax<T>
        int[] intArray = { 3, 7, 2, 9, 5 };
        double[] doubleArray = { 2.5, 3.1, 1.7, 4.6 };
        string[] stringArray = { "apple", "orange", "banana", "pear" };

        Console.WriteLine($"Максимум int[]: {FindMax(intArray)}");         // 9
        Console.WriteLine($"Максимум double[]: {FindMax(doubleArray)}");   // 4.6
        Console.WriteLine($"Максимум string[]: {FindMax(stringArray)}");   // pear (лексикографічно найбільший)
    }
}
