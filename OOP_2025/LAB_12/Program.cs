namespace LAB_12
{
    struct Point
    {
        public double X;
        public double Y;

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        // Метод обчислення евклідової відстані
        public double DistanceTo(Point other)
        {
            return Math.Sqrt(Math.Pow(other.X - X, 2) + Math.Pow(other.Y - Y, 2));
        }
    }

    class Car
    {
        public string Brand;
        public string Model;
        public int Year;
        public string Color;

        // Конструктор 1: тільки Brand і Model
        public Car(string brand, string model)
        {
            Brand = brand;
            Model = model;
            Year = 0;
            Color = "Невідомий";
        }

        // Конструктор 2: викликає перший, додає Year
        public Car(string brand, string model, int year)
            : this(brand, model)
        {
            Year = year;
        }

        // Конструктор 3: викликає другий, додає Color
        public Car(string brand, string model, int year, string color)
            : this(brand, model, year)
        {
            Color = color;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Марка: {Brand}, Модель: {Model}, Рік: {Year}, Колір: {Color}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Лабораторна №12 ===");

            // Завдання 1: Point
            Console.WriteLine("\nЗавдання 1: Відстань між точками");
            Point p1 = new Point(3, 4);
            Point p2 = new Point(0, 0);
            Console.WriteLine($"Відстань між точками: {p1.DistanceTo(p2)}");

            // Завдання 2: Car
            Console.WriteLine("\nЗавдання 2: Автомобілі");

            Car car1 = new Car("Toyota", "Corolla");
            Car car2 = new Car("BMW", "X5", 2020);
            Car car3 = new Car("Tesla", "Model S", 2022, "Червоний");

            car1.ShowInfo();
            car2.ShowInfo();
            car3.ShowInfo();

            Console.WriteLine("\n=== Кінець роботи ===");
        }
    }
}
