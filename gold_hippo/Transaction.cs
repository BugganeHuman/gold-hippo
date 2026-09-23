namespace Logics;

using System.IO;

public class Transaction
{
    public const string filePath = "balance.txt";


    public static void CreateTransactions (int amount)
    {
        bool isBalanceInt = int.TryParse(File.ReadLines(filePath).FirstOrDefault(),
                                out int balance);
        if (!isBalanceInt)
        {
            throw new InvalidOperationException("file balance.txt was broken," +
                " delete them and restart program");
        }
        balance += amount;
        if (balance < 0)
        {
            Console.WriteLine("I can't have money less 0");
            return;
        }
        string log = $"{DateTime.Now}; AMOUNT = {amount}; BALANCE = {balance}\n\n";
        File.AppendAllText(filePath, log ); 
        string[] fileStrings = File.ReadAllLines(filePath);
        fileStrings[0] = balance.ToString();
        File.WriteAllLines(filePath, fileStrings);
        Console.WriteLine("\nDone");
    }

    public static void ReadTransactions()
    {
        string[] fileStrings = File.ReadAllLines(filePath);
        for (int i = 0; i < fileStrings.Length; i++)
        {
            if (i != 0)
            {
                Console.WriteLine(fileStrings[^i]);
            }
        }
    }

    public static int GetBalance()
    {
        bool isBalanceInt = int.TryParse(File.ReadLines(filePath).FirstOrDefault(),
                                out int balance);
        if (!isBalanceInt)
        {
            throw new InvalidOperationException("file balance.txt was broken," +
                " delete them and restart program");
        }
        return balance;
    }
}
// надо методы - сделать запись типо лог, посмтреть транзации