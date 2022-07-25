using BankTest;
using Bogus;

bool canContinue = true;

AccountActions.accounts.Add(new Manager("a", "m", "123", "m@m.com", true));

for (int i = 0; i < 10; i++)
{
    Faker faker = new Faker();
    AccountActions.accounts.Add(new BankAccount(faker.Person.FirstName, faker.Person.LastName, "123", faker.Person.Email));
}
AccountActions.accounts[1].Show();


while (canContinue)
{
    // check if logged
    if (AccountActions.loggedAccount == null) AccountActions.Start(ref canContinue);
    else AccountActions.Main();
}
