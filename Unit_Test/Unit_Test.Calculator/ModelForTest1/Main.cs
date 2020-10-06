using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using Moq;

namespace Unit_Test.Calculator.ModelForTest1
{
    public class Main
    {
        /// <summary>
        /// Use Mock To Insert data 
        /// </summary>
        static void Program()
        {
            var mock = new Mock<Utils>();
            mock.Setup(m => m.GetMockEmployees()).Returns(() => new List<Employee>()
            {
                new Employee(),
                new Contractor()
            });

            List<Employee> employees = mock.Object.GetMockEmployees();
        }
    }
}