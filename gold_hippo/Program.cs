using System.IO;
using Logics;

class Program
{
    static void Main(string[] args)
    {
        if (!File.Exists("balance.txt"))
        {
            File.WriteAllText("balance.txt", "0\n\n");
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
            if (choice == "1" || choice == "2")
            {
                Console.Write("\nWrite amount: ");
                bool is_int = int.TryParse(Console.ReadLine(), out int amount);
                if (!is_int)
                {
                    Console.WriteLine("\nI need a number like 100");
                    continue;
                }
                if (choice == "2")
                {
                    amount = -amount;
                }
                Logics.Transaction.CreateTransactions(amount);
                Console.WriteLine("\nDone");
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

    } 
}