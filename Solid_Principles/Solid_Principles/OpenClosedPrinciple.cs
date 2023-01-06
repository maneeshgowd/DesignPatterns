using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Principles
{
    // Classes, Modules and Function should be Open for Extension but Closed for Modification

    // Impacts of not following
    // 1. Developers Endup testing entire functionality
    // 2. Also QA ned to test entire flow
    // 3. Maintainance will be difficult


    // 1. Implement new functionality on new DerivedClasses
    // 2. Allow Clients to access the Original class with Abstract interface

    // Class should be Open for Extension but closed for Modification



    // Problem Statement 
    // Version 1 
    internal class EmployeeOC
    {
        private int Id;
        private string Name;
        public EmployeeOC(int id, string name)
        {
           Id = id;
           Name = name;
        }

        public int GetSalary()
        {
            return 1000;
        }
    }


    // Version 2 
    internal class EmployeeOC1
    {
        private int Id;
        private string Name;
        private string EmployeeType;
        public EmployeeOC1(int id, string name, string employeeType)
        {
            Id = id;
            Name = name;
            EmployeeType = employeeType;
        }

        public int GetSalary()
        {
            if (EmployeeType == "Permanent")
            {
                return 1000;
            }
            else if(EmployeeType == "Contract")
            {
                return 500;
            }
            return 0;
        }
    }


    // Solution

    internal abstract class EmployeeOCS
    {
        private int Id;
        private string Name;
        public EmployeeOCS(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public abstract int GetSalary();

        // Common Method Used by both Permanent and Contract Employee 
        // If there is no Common method , we can use Interface instead of abstract class
        public void CommonMethod()
        {

        }
    }

    internal class PermanentEmployeeOC : EmployeeOCS
    {
        public PermanentEmployeeOC(int id, string name) : base(id, name)
        {
        }
        public override int GetSalary()
        {
            return 1000;
        }
    }

    internal class ContractEmployeeOC : EmployeeOCS
    {
        public ContractEmployeeOC(int id, string name) : base(id, name)
        {
        }
        public override int GetSalary()
        {
            return 500;
        }
    }

    internal class TemporaryEmployeeOC : EmployeeOCS
    {
        public TemporaryEmployeeOC(int id, string name) : base(id, name)
        {
        }
        public override int GetSalary()
        {
            return 10;
        }
    }
}
