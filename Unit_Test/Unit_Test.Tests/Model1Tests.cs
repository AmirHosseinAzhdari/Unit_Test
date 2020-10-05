using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unit_Test.Calculator.ModelForTest1;

namespace Unit_Test.Tests
{
    [TestClass]
    public class Model1Tests
    {
        [TestMethod]
        public void CalculateWeeklySalaryForEmployeeTest_70Wage_55Hours_Returns2800Dollars()
        {
            //Arrange
            int weeklyHours = 55;
            int wage = 70;
            int salary = 40 * wage;

            Employee e = new Employee();

            string expectedResponse = string.Format("Angry Employee Worked {0} hrs." +
                                                    "Paid for 40 hrs at ${1}" +
                                                    "/hr = ${2}", weeklyHours, wage, salary);

            //Act
            string response = e.CalculateWeeklySalary(weeklyHours, wage);

            //Assert
            Assert.AreEqual(response, expectedResponse);
        }

        [TestMethod]
        public void CalculateWeeklySalaryForContractorTest_70Wage_55Hours_Returns3850Dollars()
        {
            //Arrange
            int weeklyHours = 55;
            int wage = 70;
            int salary = weeklyHours * wage;

            Contractor e = new Contractor();

            string expectedResponse = string.Format("Happy Contractor Worked {0} hrs." +
                                                    "Paid for {0} hrs at ${1}" +
                                                    "/hr = ${2}", weeklyHours, wage, salary);

            //Act
            string response = e.CalculateWeeklySalary(weeklyHours, wage);

            //Assert
            Assert.AreEqual(response, expectedResponse);
        }

        [TestMethod]
        public void CalculateWeeklySalaryForEmployeeTest_70Wage_55Hours_ReturnsCorrectString()
        {
            //Arrange
            int weeklyHours = 55;
            int wage = 70;
            int salary = 40 * wage;

            Employee e = new Employee();

            string expectedResponse = string.Format("Problem 1 - Angry Employee Worked {0} hrs." +
                                                    "Paid for 40 hrs at ${1}" +
                                                    "/hr = ${2}", weeklyHours, wage, salary);

            //Act
            string response = e.CalculateWeeklySalary(weeklyHours, wage);

            //Assert
            Assert.AreNotEqual(response, expectedResponse);
        }

        [TestMethod]
        public void CalculateWeeklySalaryForContractorTest_70Wage_55Hours_ReturnsCorrectString()
        {
            //Arrange
            int weeklyHours = 55;
            int wage = 70;
            int salary = weeklyHours * wage;

            Contractor e = new Contractor();

            string expectedResponse = string.Format("Problem 2 - Happy Contractor Worked {0} hrs." +
                                                    "Paid for {0} hrs at ${1}" +
                                                    "/hr = ${2}", weeklyHours, wage, salary);

            //Act
            string response = e.CalculateWeeklySalary(weeklyHours, wage);

            //Assert
            Assert.AreNotEqual(response, expectedResponse);
        }
    }
}