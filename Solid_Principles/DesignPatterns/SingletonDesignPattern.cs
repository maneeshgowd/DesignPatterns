using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    // Singleton Design Pattern - It is a Creational Design Pattern

    //Restricts the instantiation of class to single Instance.
    //When one object is needed throughout the application - to cache some data or create one global object

    //  Sealed Keyword to prevent Inheritance inside a nested class
    public sealed class Singleton
    {
        private static readonly object lockObj = new object();

        private static Singleton instance = null;

        // Constructor - Private Constructor to prevent from creating instance
        private Singleton() 
        { 
        }

        public static Singleton Instance
        {
            get
            {
                // Double Check Lock
                if (instance == null)
                {
                    lock (lockObj)
                    {
                        if (instance == null)
                        {
                            instance = new Singleton();
                        }


                    }
                }
                return instance;

            }
        }

        public void LogError()
        {
            Console.WriteLine("Error has occured. Logging into the file..");
        }
    }

    public class MainSingleton
    {
        public void Main()
        {
            // Client using the Instance
            Singleton s = Singleton.Instance;
            Singleton s1 = Singleton.Instance; // Both will have single instance throughout the application lifecycle
        }
    }



    // Singleton -- 

    //It is a Design Pattern.
    //Allows Lazy Loading - Can create Class when required.
    //It is Tread Safety if accessed by multiple Users
    //Encapsulation of Data is Provided
    //it can implement interfaces - Makes use of OOPS Concept



    //Static -- 

    //Keyword - inbuild to create one single instance globally
    //Data is loaded if you need or not - Static class is loaded automatically by the CLR
    //Is not thread safe for the Data that is accessed by multiple users.
    //Data is not Encapsulated.
    //It cannot implement interfaces.


    //Singleton Class instance can be passed as a parameter to another method whereas static class cannot
    //We can dispose the objects of a singleton class but not of static class.
    //Static has Better performance(static methods are bonded on compile time)


    //Static variables are stored on the Managed Heap, not the Stack, when the type is first referenced.
    //The Type Object of the compiled class contains a reference to the object.
    //The Type Object of a class will stay in memory until the AppDomain where it resides is unloaded.
}
