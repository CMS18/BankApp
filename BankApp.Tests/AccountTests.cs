using BankApp.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankApp.Tests
{
    [TestClass]
    public class AccountTests
    {
        [TestMethod]
        public void AccountHasBalance()
        {
            //Arrange
            decimal expectedBalance = 123.45m;
            var account = new Account(1, 123.45m);

            //Act
            decimal actualBalance = account.Balance;

            //Assert
            Assert.AreEqual(expectedBalance, actualBalance);

        }
    }
}
