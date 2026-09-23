namespace Logics;

using System.IO;

public class Transaction
{
    public static void CreateTransactions (int amount)
    {
        bool is_balance_int = int.TryParse(File.ReadLines("balance.txt").FirstOrDefault(),
                                out int balance);
        if (!is_balance_int)
        {
            throw new InvalidOperationException("file balance.txt was broken," +
                " delete them and restart program");
        }
        balance += amount;
        string log = $"{DateTime.Now}; AMOUNT = {amount}; BALANCE = {balance}\n\n";
        File.AppendAllText("balance.txt", log ); 
        string[] fileStrings = File.ReadAllLines("balance.txt");
        fileStrings[0] = balance.ToString();
        File.WriteAllLines("balance.txt", fileStrings);
        
    }

    public static void ReadTransactions()
    {
        string[] fileStrings = File.ReadAllLines("balance.txt");
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
        bool is_balance_int = int.TryParse(File.ReadLines("balance.txt").FirstOrDefault(),
                                out int balance);
        if (!is_balance_int)
        {
            throw new InvalidOperationException("file balance.txt was broken," +
                " delete them and restart program");
        }
        return balance;
    }
}
// надо методы - сделать запись типо лог, посмтреть транзации