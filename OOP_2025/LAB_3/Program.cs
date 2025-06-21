namespace LAB_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Лабораторна робота №3 ===\n");
            Task1_CorrectNaming();
            Console.WriteLine();

            Task2_ReservedWordsFix();
            Console.WriteLine();

            Task3_WithComments();
        }

        private static void Task1_CorrectNaming()
        {
            int userAge = 20;
            string userName = "Андрій";

            Console.WriteLine("Привіт, " + userName + "! Твій вік: " + userAge);
        }

        private static void Task2_ReservedWordsFix()
        {
            int @int = 42;
            string @string = "Текст";

            Console.WriteLine("Значення int: " + @int);
            Console.WriteLine("Значення string: " + @string);
        }

        private static void Task3_WithComments()
        {
            // Оголошення змінної типу string і присвоєння їй значення
            string name = "Анна";

            // Оголошення змінної типу int і присвоєння їй значення
            int age = 25;

            // Виведення привітання з ім'ям і віком у консоль
            Console.WriteLine("Привіт, " + name + "! Твій вік: " + age);
        }
    }
}