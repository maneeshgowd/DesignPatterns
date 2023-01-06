using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    // Composite means things made up of several parts or elements

    // It is a partitioning design pattern and it describes that a group of objects are treated the same 
    // way as single instance of same type of objects


    // When to Choose
    // 1. When you want to represent whole part as hierarchies
    // 2. When clients wants to ignore the  diff b/w composition of objects and individual objects

    internal class CompositeDesignPattern
    {
        // Component
        public interface IEmployeeCDP
        {
            void GetDetails();

        }



        // Leaf
        public class EmployeeCDP : IEmployeeCDP
        {
            public EmployeeCDP(int id, string name)
            {
                Id = id;
                Name = name;
            }

            public int Id { get; set; }
            public string Name { get; set; }

            public void GetDetails()
            {
                Console.WriteLine("Employee Details" + "Id : " + Id + " Name : " + Name);
            }
        }



        // Composite - Manager who manages the Subordinates
        // Manager has Children - Employees who reports to him

        public class Manager : IEmployeeCDP
        {
            // Additional Operation
            public List<IEmployeeCDP> SubOrdinates;
            public Manager(int id, string name)
            {
                Id = id;
                Name = name;
                SubOrdinates= new List<IEmployeeCDP>();
            }

            public int Id { get; set; }
            public string Name { get; set; }

            public void GetDetails()
            {
                // Print only Manager Details
                Console.WriteLine( "Manger Details" + "Id : " + Id + " Name : " + Name);

                // Print Employee Details - Additional Operation
                foreach(var sub in SubOrdinates)
                {
                    sub.GetDetails();
                }
            }
        }


        // Client
        public class ProgramCDP
        {
            public void Main()
            {
                // 4 Employees
                IEmployeeCDP nikhil = new EmployeeCDP(1, "Nikhil");
                IEmployeeCDP kunal = new EmployeeCDP(2, "Kunal");
                IEmployeeCDP pallab = new EmployeeCDP(3, "Pallab");
                IEmployeeCDP akshay = new EmployeeCDP(4, "Akshay");

                // 2 Managers
                IEmployeeCDP dhaval = new Manager(5, "Dhaval")
                {
                    SubOrdinates = { nikhil, pallab }
                };


                IEmployeeCDP umar = new Manager(6, "Umar")
                {
                    SubOrdinates = { akshay, kunal }
                };


                // 1 Head
                IEmployeeCDP thiliban = new Manager(7, "Thiliban")
                {
                    SubOrdinates = { dhaval, umar }
                };

                // If End Clients wants details of Head, Managers and Employees in Hierachical manner
                // Invokes the Manager, Subordinates and Leafs Details
                thiliban.GetDetails();

                // We can get only particular manager details and his employees
                dhaval.GetDetails();
            }
        }
    }
}
