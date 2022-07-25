using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTest.Actions
{
    public static class BankAccountActions
    {
        public static void Main()
        {
            // display menu
            Menu.Account();
            BankAccount account = AccountActions.loggedAccount as BankAccount;
            int choice = CommonActions.GetNumber();

            switch (choice)
            {
                // info
                case 1:
                    account.Show();
                    break;
                // transfer
                case 2:
                    Transfer(account);
                    break;
                // history
                case 3:
                    if (account.History.Count == 0)
                    {
                        Console.WriteLine("History empty");
                        return;
                    }

                    Console.WriteLine("---------------History---------------");

                    foreach (HistoryNode node in account.History)
                    {
                        node.Show();
                    }
                    break;
                // clan
                case 4:
                    Console.Clear();
                    break;
                // logout
                case 5:
                    account.LogOut();
                    account = null;
                    goto case 4;
                // wrong
                default:
                    Menu.WrongNumber();
                    break;
            }
        }
        static void Transfer(BankAccount account)
        {
            // check if guid is good
            string id;
            Guid tempGuid = new();
            do
            {
                Console.Write("To id: ");
                id = Console.ReadLine();
                if (id == String.Empty) return;
            } while (Guid.TryParse(id, out tempGuid));

            // get info about receiver and transfer
            Console.Write("Description: ");
            string? description = Console.ReadLine();
            Console.Write("Value: ");
            decimal value;
            // try to do transfer (if fail show error)
            try
            {
                value = Convert.ToDecimal(Console.ReadLine());
                // check for account (by id)
                BankAccount reciver = AccountActions.accounts.First(a => a.Id.Equals(Guid.Parse(id)) && a is BankAccount) as BankAccount;
                account.IsValid();
                // show warning about negative balance
                if (CheckIfBalanceGreaterTheZero(account, value)) return;
                account.SetTransfer(reciver, value, description);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static bool CheckIfBalanceGreaterTheZero(BankAccount account, decimal value)
        {
            if (account.Balance - value < 0)
            {
                // confirm action
                Console.WriteLine("You don't have enough money. Do you want to continue? (y/n)");
                // if something else then 'y' don't do transfer
                if (Console.ReadKey().KeyChar != 'y')
                {
                    Console.WriteLine("Transfer ender");
                    return true;
                }
            }
            return false;
        }
    }
}
