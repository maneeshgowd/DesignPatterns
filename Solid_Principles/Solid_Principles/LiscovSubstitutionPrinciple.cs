using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Principles
{
    // Objects in a program should be replacable with instances of thier 
    // subtypes without altering the correctness of program

    // If program is using base class then reference to base class can be replaced with derived class without
    // affecting the functionality of the program


    // Derived types must be substitutable for the base types - Its an extension of OCP.

    // Some requiremnets
    // No Exceptions should be thrown by Subtypes
    // New Derived types extend without replacing old classes


    

    // Problem Statement
    internal interface IEmployeeLS
    {
        int GetSalary();
        string GetDetails();
    }

    public class PermanentEmployeeLS : IEmployeeLS
    {
        public string GetDetails()
        {
            return "This is Permanent Employee";
        }

        public int GetSalary()
        {
            return 1000;
        }
    }

    public class ContractEmployeeLS : IEmployeeLS
    {
        public string GetDetails()
        {
            return "This is Contract Employee";
        }

        public int GetSalary()
        {
            return 500;
        }
    }




    // Throws Exception - Against the principle
    public class TemporaryEmployeeLS : IEmployeeLS
    {
        public string GetDetails()
        {
            return "This is Temporary Employee";
        }

        public int GetSalary()
        {
            throw new NotImplementedException();
        }
    }



    // Solution
    internal interface IEmployeeLSS
    {
        string GetDetails();
    }

    internal interface IEmployeeSalary
    {
        int GetSalary();
    }

    public class PermanentEmployeeLSS : IEmployeeLSS, IEmployeeSalary
    {
        public string GetDetails()
        {
            return "This is Permanent Employee";
        }

        public int GetSalary()
        {
            return 1000;
        }
    }


    public class ContractEmployeeLSS : IEmployeeLSS, IEmployeeSalary
    {
        public string GetDetails()
        {
            return "This is Contract Employee";
        }

        public int GetSalary()
        {
            return 500;
        }
    }


    public class TemporaryEmployeeLSS : IEmployeeLSS
    {
        public string GetDetails()
        {
            return "This is Temporary Employee";
        }
    }
}
