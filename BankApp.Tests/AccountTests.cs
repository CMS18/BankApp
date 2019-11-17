using BankApp.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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

        [TestMethod]
        public void CanDepositAndBalanceIsCorrect()
        {
            //Arrange
            decimal initialBalance = 123.45m;
            decimal depositAmount = 50m;
            decimal expectedBalance = 173.45m;

            var account = new Account(1, initialBalance);

            //Act
            account.Deposit(depositAmount);
            decimal actualBalance = account.Balance;
             
            //Assert
            Assert.AreEqual(expectedBalance, actualBalance);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CannotDepositNegativeAmount()
        {
            //Arrange
            decimal initialBalance = 123.45m;
            decimal depositAmount = -50m;

            var account = new Account(1, initialBalance);

            //Act
            account.Deposit(depositAmount);
            decimal actualBalance = account.Balance;

            //Assert
            Assert.AreEqual(actualBalance, initialBalance);

            //Expects ArgumentOutOfRangeException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CannotWithdrawMoreThanBalance()
        {
            //Arrange
            decimal initialBalance = 123.45m;
            decimal withdrawAmount = 150m;

            var account = new Account(1, initialBalance);

            //Act
            account.Withdraw(withdrawAmount);
            decimal actualBalance = account.Balance;

            //Assert
            Assert.AreEqual(actualBalance, initialBalance);

            //Expects ArgumentOutOfRangeException
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CannotWithdrawNegativeAmount()
        {
            //Arrange
            decimal initialBalance = 123.45m;
            decimal withdrawAmount = -50m;

            var account = new Account(1, initialBalance);

            //Act
            account.Withdraw(withdrawAmount);
            decimal actualBalance = account.Balance;

            //Assert
            Assert.AreEqual(actualBalance, initialBalance);

            //Expects ArgumentOutOfRangeException
        }

        [TestMethod]
        public void CanWithdrawAndBalanceIsCorrect()
        {
            //Arrange
            decimal initialBalance = 123.45m;
            decimal withdrawAmount = 23m;
            decimal expectedBalance = 100.45m;

            var account = new Account(1, initialBalance);

            //Act
            account.Withdraw(withdrawAmount);
            decimal actualBalance = account.Balance;

            //Assert
            Assert.AreEqual(actualBalance, expectedBalance);
        }
    }
}
