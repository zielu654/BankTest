using System.Text.RegularExpressions;

namespace BankTest;
public static class Validation
{
    public static bool IsValidEmail(string email)
    {
        Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        return regex.IsMatch(email);
    }
}

