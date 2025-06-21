namespace LAB_10
{
    class MortgageApplication
    {
        public decimal Principal { get; set; } // Сума кредиту
        public decimal AnnualInterestRate { get; set; } // Річна відсоткова ставка
        public int Years { get; set; } // Кількість років

        public decimal CalculateMonthlyPayment()
        {
            decimal r = AnnualInterestRate / 12 / 100;
            int n = Years * 12;

            decimal numerator = r * (decimal)Math.Pow((double)(1 + r), n);
            decimal denominator = (decimal)Math.Pow((double)(1 + r), n) - 1;

            decimal monthlyPayment = Principal * numerator / denominator;
            return Math.Round(monthlyPayment, 2);
        }

        public override string ToString()
        {
            return $"Сума: {Principal} грн, Ставка: {AnnualInterestRate}%, Років: {Years}, Щомісячний платіж: {CalculateMonthlyPayment()} грн";
        }
    }

    class Program
    {
        static Queue<MortgageApplication> applications = new Queue<MortgageApplication>();

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("\n--- Меню ---");
                Console.WriteLine("1. Додати нову заявку");
                Console.WriteLine("2. Обробити першу заявку");
                Console.WriteLine("3. Переглянути першу заявку");
                Console.WriteLine("4. Переглянути всі заявки");
                Console.WriteLine("5. Вийти");
                Console.Write("Ваш вибір: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddApplication();
                        break;
                    case "2":
                        ProcessApplication();
                        break;
                    case "3":
                        PeekApplication();
                        break;
                    case "4":
                        ViewAllApplications();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                        break;
                }
            }
        }

        static void AddApplication()
        {
            Console.Write("Введіть суму кредиту (грн): ");
            decimal p = decimal.Parse(Console.ReadLine());

            Console.Write("Введіть річну відсоткову ставку (%): ");
            decimal r = decimal.Parse(Console.ReadLine());

            Console.Write("Введіть кількість років: ");
            int y = int.Parse(Console.ReadLine());

            var app = new MortgageApplication
            {
                Principal = p,
                AnnualInterestRate = r,
                Years = y
            };

            applications.Enqueue(app);
            Console.WriteLine("Заявку додано успішно.");
        }

        static void ProcessApplication()
        {
            if (applications.Count == 0)
            {
                Console.WriteLine("Черга порожня.");
                return;
            }

            var app = applications.Dequeue();
            Console.WriteLine("Оброблено заявку:");
            Console.WriteLine(app);
        }

        static void PeekApplication()
        {
            if (applications.Count == 0)
            {
                Console.WriteLine("Черга порожня.");
                return;
            }

            var app = applications.Peek();
            Console.WriteLine("Поточна заявка:");
            Console.WriteLine(app);
        }

        static void ViewAllApplications()
        {
            if (applications.Count == 0)
            {
                Console.WriteLine("Черга порожня.");
                return;
            }

            Console.WriteLine("Усі заявки:");
            foreach (var app in applications)
            {
                Console.WriteLine(app);
            }
        }
    }
}
