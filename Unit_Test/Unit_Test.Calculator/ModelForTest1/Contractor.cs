namespace Unit_Test.Calculator.ModelForTest1
{
    public class Contractor : Employee
    {
        public override string CalculateWeeklySalary(int weeklyHours, int wage)
        {
            var salary = weeklyHours * wage;

            string result = $"Happy Contractor Worked {weeklyHours} hrs." +
                                          $"Paid for {weeklyHours} hrs at ${wage}" +
                                          $"/hr = ${salary}";
            return result;
        }
    }
}