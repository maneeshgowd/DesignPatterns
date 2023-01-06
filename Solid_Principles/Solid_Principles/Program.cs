using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Principles
{
    // To Build a Robust Application
    // 1. Architecture 
    // 2. Design Patterns
    // 3. Design Principles - Development process has to follow these principles

    // SOLID -
    // 1. Helps to Manage Design problems.
    // 2. Makes code more Understandable, Flexible and Maintainable.

    // Imapcts of not using Design principle
    // 1. It creates strong coupling of code in the application.
    // 2. Not testable.
    // 3. Time to implement new features or fix any bugs --> might create unknown issues.
    // 4. Duplication of Code.

    // S - Single Responsibility Principle
    // O - Open Closed Principle
    // L - Liscov Substitution Principle
    // I - Interface Segregation Principle
    // D - Dependency Inversion Principle













    internal class Program
    {
        static void Main(string[] args)
        {
            // Open Closed Principle
            EmployeeOC employeeOC = new EmployeeOC(1, "User1");
            int salary = employeeOC.GetSalary();




            // Liscov Substitution Princple
            IEmployeeLSS employee = new PermanentEmployeeLSS();
            string res1 = employee.GetDetails();

            employee = new ContractEmployeeLSS();
            string res2 = employee.GetDetails();

            employee = new TemporaryEmployeeLSS();
            string res3 = employee.GetDetails();
        }
    }
}
