using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankTest
{
    public static class GetPropertiesOfAccount
    {
        public static string GetProperty(string? message = null)
        {
            if (message != null) Console.Write(message);
            string? output = Console.ReadLine();
            return output != null ? output : string.Empty;
        }

        public static string GetFirstName()
        {
            return GetProperty("First name: ");
        }
        public static string GetLastName()
        {
            return GetProperty("First name: ");
        }
        public static string GetEmail()
        {
            return GetProperty("E-mail: ");
        }
        public static string GetPasssword()
        {
            string output = GetProperty("Password: ");
            CommonActions.ClearCurrentConsoleLine();
            return output;
        }
        public static string? GetLineOrNull(string? message = null)
        {
            // if message is null don't show
            if (message != null) Console.Write(message);
            // get string and if not null return it but if is null return null
            string? input = Console.ReadLine();
            if (input == String.Empty) return null;
            return input;
        }
    }
}
