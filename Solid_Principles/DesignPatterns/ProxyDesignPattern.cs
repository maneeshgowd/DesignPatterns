using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    // Proxy is Similar to Decorator Design Pattern
    // In decorator we used to create the object before and put inside it.
    // But in Proxy we wont create object before creating proxy

    // We use Proxy when we dont want to change something at runtime. its infrastructure bound .
    // In Decorator different objects can be injected

    // Decorator - Runtime decision
    // Proxy - Compile time decision

    // You have original Object
    // Proxy is pointing to that . but its decided at compile time 
    internal class ProxyDesignPattern
    {
        public interface ICar
        {
            string Make { get; }
            double GetPrice();
        }

        public class Tata : ICar
        {
            public string Make { get; set; }

            public double GetPrice()
            {
                return 2.0;
            }
        }

        public class Maruti : ICar
        {
            public string Make { get; set; }

            public double GetPrice()
            {
                return 2.0;
            }
        }

        // Extra Layer of Security can be added here 
        // Instead of Directly accessing Car, Authorization/Firewall kind of thing
        public class CarProxy : ICar
        {
            // This is Compile Time decision
            // Hide Concretion , In Decorator as we are injecting its already known
            ICar car = new Tata();

            public string Make
            {
                get { return car.Make; }
            }

            public double GetPrice()
            {
                return car.GetPrice();
            }

            public double GetDiscountedPrice()
            {
                return 0.6 * car.GetPrice();
            }
        }


        // Client
        public class ProgramPDP
        {
            public void Main()
            {
                CarProxy carProxy = new CarProxy();

                string carMake = carProxy.Make;
                double price = carProxy.GetPrice();
            }
        }
    }
}
