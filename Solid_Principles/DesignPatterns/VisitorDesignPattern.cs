using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    //  It is used when we have to perform an operation on a group of similar kind of Objects.
    //  With the help of visitor pattern, we can move the operational logic from the objects to another class.


    // Elements - Car and Visitors  - Tata and Bmw
    // - Setting Operation on Elements -SetSpeed() will have different for Visitors
    // Element will accept a Visitor
    // One of the rare pattern that will be used.
    internal class VisitorDesignPattern
    {
        // Element
        public abstract class Car
        {
            public abstract void Accept(Visitor visitor);
        }

        public class Tata : Car
        {
            public override void Accept(Visitor visitor)
            {
                visitor.VisitTata(this);
            }
        }

        public class Bmw : Car
        {
            public override void Accept(Visitor visitor)
            {
                visitor.VisitBmw(this);
            }
        }

        //Visitor
        public abstract class Visitor
        {
            public abstract void VisitTata(Tata tata);
            public abstract void VisitBmw(Bmw bmw);
        }

        public class Customer1 : Visitor
        {
            public override void VisitBmw(Bmw bmw)
            {
                Console.WriteLine("Customer 1 has visited from BMW");
            }

            public override void VisitTata(Tata tata)
            {
                Console.WriteLine("Customer 1 has visited from Tata");
            }
        }

        public class Customer2 : Visitor
        {
            public override void VisitBmw(Bmw bmw)
            {
                Console.WriteLine("Customer 2 has visited from BMW");
            }

            public override void VisitTata(Tata tata)
            {
                Console.WriteLine("Customer 2 has visited from Tata");
            }
        }
    }
}
