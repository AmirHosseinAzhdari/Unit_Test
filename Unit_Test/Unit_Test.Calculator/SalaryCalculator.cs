using System;
using System.ComponentModel.DataAnnotations;

namespace Unit_Test.Calculator
{
    public class SalaryCalculator
    {
        const int HourInYear = 2080;

        public decimal GetAnnualSalary(decimal hourlyWage) => hourlyWage * HourInYear;

        public decimal GetHourlyWage(int annualSalary) => annualSalary / HourInYear;
    }
}
