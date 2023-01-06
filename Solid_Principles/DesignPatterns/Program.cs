using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    internal class Program
    {
        //  Design Patters - Reusable Solution for day to day Problems

        // 3 Types of Design Patterns based on the Problems we face

        // 1. Creations - Deals with Object creation and Initialization

        // 2. Structural - Deals with Class and Object Composition
        // Mainly on Decoupling Interface and implementation of Classes and its Objects.

        // 3. Behavioral - Deals with Communication between Classes and Objects.
        // Behavioral design patterns are concerned with the interaction and responsibility of objects.
        // In these design patterns, the interaction between the objects should be in such a way that they can easily talk to each other and still should be loosely coupled.

        // That means the implementation and the client should be loosely coupled in order to avoid hard coding and dependencies.

        //        Creational Design Pattern
        //1.            Factory Method - Done
        //2.            Abstract Factory - Done
        //3.            Builder - Done
        //4.            Prototype - Done 
        //5.            Singleton - Done

        //Structural Design Patterns
        //1.            Adapter - Done 
        //2.            Bridge - Done
        //3.            Composite - Done
        //4.            Decorator - Done
        //5.            Façade - Done
        //6.            Flyweight - Done
        //7.            Proxy - Done

        //Behavioral Design Patterns

        //1.            Chain of Responsibility - Done
        //2.            Command - Done
        //3.            Interpreter - Done
        //4.            Iterator - Done
        //5.            Mediator - Done
        //6.            Memento - Done
        //7.            Observer - Done
        //8.            State - Done
        //9.            Strategy - Done
        //10.           Visitor - Done
        //11.           Template Method - Done


        static void Main(string[] args)
        {
            // Prototype Design Pattern - Shallow Copy
            Console.WriteLine("Shallow Copy - Before Changes");
            // Declaring and creating Employee 1 



            Address address = new Address(190, "Ecity", 5600);
            EmployeeAC employee1 = new EmployeeAC();
            employee1.Name = "Nikhil";
            employee1.Salary = 1000;
            employee1.Address = address;




            // Printing Values of Employee 1 
            Console.WriteLine("Employee 1 Details - Name - " + employee1.Name + ". Salary - " + employee1.Salary
                + ". Address - " + employee1.Address.DoorNumber + " ," + employee1.Address.Street + " ," + 
                employee1.Address.PinCode);


            //Shallow Copy
            // Creating Employee 2 - By Clone
            EmployeeAC employee2 = (EmployeeAC)employee1.Clone();







            // Printing Values of Employee 2 
            Console.WriteLine("Employee 2 Details - Name - " + employee2.Name + ". Salary - " + employee2.Salary
               + ". Address - " + employee2.Address.DoorNumber + " ," + employee2.Address.Street + " ," + 
               employee2.Address.PinCode);

            Console.WriteLine();
            Console.WriteLine("Shallow Copy - After Changes");
            // Changing Values of Employee 2 
            employee2.Name = "Prachi";
            employee2.Salary = 500;
            employee2.Address.DoorNumber = 210;
            employee2.Address.Street = "ITPL";
            employee2.Address.PinCode = 7100;

            // Printing Values of Employee 1 
            Console.WriteLine("Employee 1 Details - Name - " + employee1.Name + ". Salary - " + employee1.Salary
                + ". Address - " + employee1.Address.DoorNumber + " ," + employee1.Address.Street + " ," +
                employee1.Address.PinCode);

            // Printing Values of Employee 2 
            Console.WriteLine("Employee 2 Details - Name - " + employee2.Name + ". Salary - " + employee2.Salary
               + ". Address - " + employee2.Address.DoorNumber + " ," + employee2.Address.Street + " ," +
               employee2.Address.PinCode);


            // Prototype Design Pattern - Deep Copy

            Console.WriteLine();
            Console.WriteLine("Deep Copy - Before Changes");
            // Decalring and creating Employee 1 
            Address address1 = new Address(420, "Bellandur", 2310);
            EmployeeDC employee3 = new EmployeeDC();
            employee3.Name = "Kunal";
            employee3.Salary = 2000;
            employee3.Address = address1;

            // Printing Values of Employee 1 
            Console.WriteLine("Employee 1 Details - Name - " + employee3.Name + ". Salary - " + employee3.Salary
                + ". Address - " + employee3.Address.DoorNumber + " ," + employee3.Address.Street + " ," +
                employee3.Address.PinCode);


            // Creating Employee 2 - By Clone
            EmployeeDC employee4 = (EmployeeDC)employee3.DeepCopy();

            // Printing Values of Employee 2 
            Console.WriteLine("Employee 2 Details - Name - " + employee4.Name + ". Salary - " + employee4.Salary
               + ". Address - " + employee4.Address.DoorNumber + " ," + employee4.Address.Street + " ," +
               employee4.Address.PinCode);


            Console.WriteLine();
            Console.WriteLine("Deep Copy - After Changes");
            // Changing Values of Employee 2 
            employee4.Name = "Pallab";
            employee4.Salary = 3000;
            employee4.Address.DoorNumber = 570;
            employee4.Address.Street = "Kalyani";
            employee4.Address.PinCode = 9811;

            // Printing Values of Employee 1 
            Console.WriteLine("Employee 1 Details - Name - " + employee3.Name + ". Salary - " + employee3.Salary
                + ". Address - " + employee3.Address.DoorNumber + " ," + employee3.Address.Street + " ," +
                employee3.Address.PinCode);

            // Printing Values of Employee 2 
            Console.WriteLine("Employee 2 Details - Name - " + employee4.Name + ". Salary - " + employee4.Salary
               + ". Address - " + employee4.Address.DoorNumber + " ," + employee4.Address.Street + " ," +
               employee4.Address.PinCode);

            Console.ReadLine();
        }

        public void DelegateMethod()
        {
            Predicate<int> del = x => x>5;
            del(5);
        }

        // Generic Deletes
        // 1. Action - Input , Return Void
        // 2. Predicate - Input, Return Bool
        // 3. Func - Input, return output
    }
}
