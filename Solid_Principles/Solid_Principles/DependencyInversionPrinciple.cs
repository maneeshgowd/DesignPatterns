using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Principles
{
    // one shud depend on Abstractions and not on Concretions
    // high Level Modules should depend on low level modules, both should depend on Abstractions

    // Impact of not using
    // 1. Tight coupling of code
    // 2. Difficult to write Unit tests






    // Problem Statement
    internal class EmployeeRepository 
    {
        public EmployeeRepository()
        {

        }
        public int GetSalaryFromDB()
        {
            return 2000;
        }
    }

    //
    internal class EmployeeController
    {
        private EmployeeRepository employeeRepository;

        public EmployeeController()
        {
            employeeRepository = new EmployeeRepository();
        }

        public int GetSalaryDetails()
        {
            return employeeRepository.GetSalaryFromDB();
        }
    }


    // Solution
    interface IEmployeeRepository
    {
        int GetSalaryFromDB();
    }

    internal class EmployeeRepositorySol : IEmployeeRepository
    {
        public EmployeeRepositorySol()
        {

        }
        public int GetSalaryFromDB()
        {
            return 2000;
        }
    }

    internal class EmployeeControllerSol
    {
        private IEmployeeRepository employeeRepository;

        // Injecting Dependency
        public EmployeeControllerSol(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public int GetSalaryDetails()
        {
            return employeeRepository.GetSalaryFromDB();
        }
    }
}
