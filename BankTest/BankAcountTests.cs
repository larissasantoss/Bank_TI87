using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank;


namespace BankTest
{
    [TestClass]
    public class BankAcountTests
    {
       [TestMethod]
       public  void Debit_WithValidAmount_updateBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAcount acount = new BankAcount("Lari", beginningBalance);

            // Act
            acount.Debit(debitAmount);

            // Assert
            double actual = acount.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
     
       }
        [TestMethod]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 20.0;
            BankAcount acount = new BankAcount("Mr. Bryan Walton", beginningBalance);

            // Act
            try
            {
                acount.Debit(debitAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message, BankAcount.DebitAmountExceedsBalanceMessage);
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }
    }



}
