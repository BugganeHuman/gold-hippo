using System.IO;
using Logics;

class Program
{
    static void Main(string[] args)
    {
        if (!File.Exists(Logics.Transaction.filePath))
        {
            File.WriteAllText(Logics.Transaction.filePath, "0\n\n");
        }
        Console.WriteLine("\nHi I'm Gold Hippo your moneybox :)\n");
        Console.WriteLine("Write a number of action");
        while (true)
        {
            Console.Write("\n1 - put money\n\n2 - get money\n\n3 - show balance\n\n" +
                "4 - show logs\n\n0 - exit\n            : ");
            string? choice = Console.ReadLine();

            if (choice == "0")
            {
                break;
            }
            if (choice == "1")
            {
                int amount = WriteAmount();
                if (amount == 0)
                {
                    continue;
                }
                Logics.Transaction.CreateTransactions(amount);
                
            }
            if (choice == "2")
            {
                int amount = WriteAmount();
                if (amount == 0)
                {
                    continue;
                }
                Logics.Transaction.CreateTransactions(-amount);
                

            }

            if (choice == "3")
            {
                int balance = Logics.Transaction.GetBalance();
                Console.WriteLine($"\nYou have - {balance}");
            }
            if (choice == "4")
            {
                Logics.Transaction.ReadTransactions();
            }
        }
        static int WriteAmount()
        {
            Console.Write("\nWrite amount: ");
            bool isInt = int.TryParse(Console.ReadLine(), out int amount);
            if (!isInt || amount < 0)
            {
                Console.WriteLine("\nI need a positive number like 100");
                return 0;
            }
            return amount;
        }

    } 
}