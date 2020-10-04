using System;

namespace Unit_Test.Calculator
{
    public class SalaryCalculator
    {
        public decimal GetAnnualSalary(decimal hourlyWage)
        {
            const int hourInYear = 2080;
            decimal annualSalary = hourInYear * hourlyWage;
            return annualSalary;
        }
    }
}
