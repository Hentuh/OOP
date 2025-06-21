class BankAccount
{
    private int balance = 0;
    private readonly object balanceLock = new object();

    public async Task DepositAsync(int amount)
    {
        await Task.Delay(100);

        lock (balanceLock)
        {
            balance += amount;
            Console.WriteLine($"Поповнення +{amount}");
        }
    }

    public async Task WithdrawAsync(int amount)
    {
        await Task.Delay(100);

        lock (balanceLock)
        {
            if (balance >= amount)
            {
                balance -= amount;
                Console.WriteLine($"Зняття -{amount}");
            }
            else
            {
                Console.WriteLine($"Недостатньо коштів для зняття {amount}");
            }
        }
    }

    public int GetBalance()
    {
        lock (balanceLock)
        {
            return balance;
        }
    }
}

class Program
{
    static async Task Main()
    {
        BankAccount account = new BankAccount();

        Task[] tasks = new Task[]
        {
            account.DepositAsync(200),
            account.WithdrawAsync(100),
            account.DepositAsync(300),
            account.WithdrawAsync(50)
        };

        await Task.WhenAll(tasks);

        Console.WriteLine($"Фінальний баланс: {account.GetBalance()}");
    }
}
