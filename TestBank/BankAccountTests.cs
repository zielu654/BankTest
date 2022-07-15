using BankTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestBank
{
    public class BankAccountTests
    {
        [Fact]
        public void BankAccount_ShouldCreateAccount()
        {
            // Arrange
            string name = "Michal";
            string lastName = "Zielinski";
            string password = "password";
            string email = "michal@gmail.com";

            // Act
            BankAccount account = new BankAccount(name, lastName, password, email);

            // Assert
            Assert.Equal(name, account.FirstName);
            Assert.Equal(lastName, account.LastName);
            Assert.Equal(email, account.Email);
        }

        [Fact]
        public void SetTransfer_DoTransferWork()
        {
            BankAccount accountFrom = new BankAccount("Bob", "Smith", "password", "BSmith@gmail.com");
            BankAccount accountTo = new BankAccount("Olivia", "Jones", "1234", "OliviaJ@gmail.com");

            accountFrom.SetTransfer(accountTo, 200, "description of transfer");

            Assert.Equal(-200M, accountFrom.Balance);
            Assert.Equal(200M, accountTo.Balance);
        }

        [Fact]
        public void GetTransfer_ShouldWork()
        {
            BankAccount accountFrom = new BankAccount("Bob", "Smith", "password", "BSmith@gmail.com");
            BankAccount accountTo = new BankAccount("Olivia", "Jones", "1234", "OliviaJ@gmail.com");

            accountTo.GetTransfer(accountFrom, 200, "test");
        }

        [Fact]
        public void History_Add()
        {
            BankAccount accountFrom = new BankAccount("Bob", "Smith", "password", "BSmith@gmail.com");
            BankAccount accountTo = new BankAccount("Olivia", "Jones", "1234", "OliviaJ@gmail.com");

            accountFrom.SetTransfer(accountTo, 200, "description of transfer");

            HistoryNode historyNode = new HistoryNode(200, "description of transfer", accountFrom, accountTo);
            Assert.True(NodeEqual(historyNode, accountFrom.History.First()));
            Assert.True(NodeEqual(historyNode, accountTo.History.First()));
        }

        bool NodeEqual(HistoryNode historyNode1, HistoryNode historyNode2)
        {
            if(historyNode1.Value != historyNode2.Value) return false;
            if(historyNode1.Sender != historyNode2.Sender) return false;
            if(historyNode1.Receiver != historyNode2.Receiver) return false;
            if(historyNode1.Description != historyNode2.Description) return false;

            return true;
        }
    }
}
