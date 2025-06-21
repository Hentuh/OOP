namespace LAB_13
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // === Завдання 1: Делегат і предикат ===
            Console.WriteLine("=== Завдання 1: Фільтрація парних чисел ===");

            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Predicate<int> isEven = n => n % 2 == 0;

            int[] evenNumbers = Filter(numbers, isEven);

            Console.WriteLine("Парні числа:");
            foreach (int num in evenNumbers)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();

            // === Завдання 2: Події ===
            Console.WriteLine("\n=== Завдання 2: Статус замовлення ===");

            Order order = new Order();
            order.OrderStatusChanged += OrderStatusChangedHandler;

            order.Status = "Замовлення отримано";
            order.Status = "Відправлено";
            order.Status = "Доставлено";
        }

        static int[] Filter(int[] numbers, Predicate<int> predicate)
        {
            List<int> result = new List<int>();
            foreach (int number in numbers)
            {
                if (predicate(number))
                    result.Add(number);
            }
            return result.ToArray();
        }

        static void OrderStatusChangedHandler(object sender, string status)
        {
            Console.WriteLine($"Статус замовлення змінено на: {status}");
        }
    }

    class Order
    {
        public event EventHandler<string> OrderStatusChanged;

        private string status;
        public string Status
        {
            get => status;
            set
            {
                if (status != value)
                {
                    status = value;
                    OnOrderStatusChanged(status);
                }
            }
        }

        protected virtual void OnOrderStatusChanged(string status)
        {
            OrderStatusChanged?.Invoke(this, status);
        }
    }
}
