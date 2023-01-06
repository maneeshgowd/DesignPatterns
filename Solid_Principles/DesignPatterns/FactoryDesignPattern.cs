using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{

        // Client should not be exposed with which classes are used and create complex
        // logic in client code using if else statements and new keywords

        //The Responsibility should be delegated to the Factory Class which takes
        //required parameter and creates Products and will return Interfaces which
        //are actually exposed to client.





    // Problem Statement 
    public class MainBefore
    {
        public void Main()
        {
            string input = Console.ReadLine();
            if (input == "Permanent")
            {
                PermanentEmployee pE =  new PermanentEmployee();
                Console.WriteLine(pE?.GetSalary());
            }
            else if (input == "Contract")
            {
                ContractEmployee cE = new ContractEmployee();
                Console.WriteLine(cE?.GetSalary());
            }
            
        }
    }








    // Solution

    // Client can see only this Interface
    public interface IEmployeeFDP 
    {
        int GetSalary();
    }

    public class ContractEmployee : IEmployeeFDP
    {
        public int GetSalary()
        {
            return 100;
        }
    }

    public class PermanentEmployee : IEmployeeFDP
    {
        public int GetSalary()
        {
            return 2000;
        }
    }

    // Usually its a Static Class
    public class Factory
    {
        public static IEmployeeFDP GetEmployee(string employeeType)
        {
            if (employeeType == "Permanent")
            {
                return new PermanentEmployee();
            }
            else if (employeeType == "Contract")
            {
                return new ContractEmployee();
            }

            return null;
        }
    }

    public class MainClass
    {
        public void Main()
        {
            string input = Console.ReadLine();
            IEmployeeFDP employee = Factory.GetEmployee(input);
            Console.WriteLine(employee?.GetSalary());
        }
    }
}
