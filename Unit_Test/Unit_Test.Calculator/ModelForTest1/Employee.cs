namespace Unit_Test.Calculator.ModelForTest1
{
    public class Employee
    {
        public virtual string CalculateWeeklySalary(int weeklyHours, int wage)
        {
            var salary = 40 * wage;

            string result = $"Angry Employee Worked {weeklyHours} hrs." +
                                          $"Paid for 40 hrs at ${wage}" +
                                          $"/hr = ${salary}";
            return result;
        }
    }
}