//using BankTest;
//using System.IO;
//using Xunit;

//namespace TestBank;
//public class AccountTests
//{
//    [Fact]
//    public void Account_ShouldCreateAccount()
//    {
//        // Arrange
//        string name = "Bob";
//        string lastName = "Smith";
//        string password = "password";
//        string email = "michal@gmail.com";

//        // Act
//        Account account = new Account(name, lastName, password, email);

//        // Assert
//        Assert.Equal(name, account.FirstName);
//        Assert.Equal(lastName, account.LastName);
//        Assert.Equal(email, account.Email);
//    }
//    [Fact]
//    public void Account_NotShouldCreateAccount()
//    {
//        Assert.Throws<InvalidDataException>(() => new Account("Bob", "Smith", "password", "email"));
//    }

//    [Fact]
//    public void Login_NotShouldLogIn()
//    {
//        Account account = new Account("Bob", "Smith", "password123", "BobS@gmail.com");

//        Assert.False(account.LogIn("wrongPassword"));
//        Assert.False(account.IsLoggedIn);
//    }

//    [Fact]
//    public void Login_ShouldLogIn()
//    {
//        Account account = new Account("Bob", "Smith", "password123", "BobS@gmail.com");

//        Assert.True(account.LogIn("password123"));
//        Assert.True(account.IsLoggedIn);
//    }

//    [Fact]
//    public void IsValid_ShouldBeValid()
//    {
//        Account account = new Account("Bob", "Smith", "password123", "BobS@gmail.com");
//        Assert.True(account.IsValid());
//    }
//    [Fact]
//    public void LogOut_ShoudLogout()
//    {
//        Account account = new Account("Bob", "Smith", "password123", "BobS@gmail.com");
//        account.LogIn("password123");
//        Assert.True(account.IsLoggedIn);
//        account.LogOut();
//        Assert.False(account.IsLoggedIn);
//    }

//    [Theory]
//    [InlineData(null, null, "123", null)]
//    [InlineData("Tom", "Jones", null, null)]
//    [InlineData(null, null, null, null)]
//    [InlineData(null, null, null, "abc@gmail.com")]
//    [InlineData("Olivia", "Taylor", "myPassword1", "oliT@yahoo.org")]
//    public void Edit_ShouldEditvalues(string? firstName, string? lastName, string? password, string? email)
//    {
//        Account account = new Account("Bob", "Smith", "password", "BobS@gmail.com");

//        account.Edit(firstName, lastName, password, email);

//        if (firstName == null) Assert.Equal("Bob", account.FirstName);
//        else Assert.Equal(firstName, account.FirstName);

//        if (lastName == null) Assert.Equal("Smith", account.LastName);
//        else Assert.Equal(lastName, account.LastName);

//        if (password == null) Assert.Equal(Hashing.GetHashString("password"), account.Password);
//        else Assert.Equal(Hashing.GetHashString(password), account.Password);

//        if (email == null) Assert.Equal("BobS@gmail.com", account.Email);
//        else Assert.Equal(email, account.Email);
//    }
//}

