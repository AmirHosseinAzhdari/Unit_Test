using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unit_Test.Calculator;

namespace Unit_Test.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void AnnualSalaryTest()
        {
            //Arrange
            SalaryCalculator sc = new SalaryCalculator();

            //Act
            decimal annualSalary = sc.GetAnnualSalary(50);

            //Assert
            Assert.AreEqual(104000, annualSalary);
        }

        [TestMethod]
        public void HourlyWageTest()
        {
            //Arrange 
            SalaryCalculator sc = new SalaryCalculator();

            //Act
            decimal hourlyWage = sc.GetHourlyWage(52000);

            //Assert
            Assert.AreEqual(25, hourlyWage);
        }
    }
}
