using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    // Decorator - Attach additional responsibilities to an object dynamically
    // Its a Wrapper which adds aditional functionality to a object without changing the structure of class
    // Alligns with Solid Design Principles

    // When to choose
    // 1. When we want to add responsibility to individual objects dynamically / transparently
    // 2. When Class Definition is hidden or unavailable for Subclassing
    // When we want to change legacy code using decorators

    // We can also use Inheritance- which desnot allow for sealed classes

    // Example if you take a Icecream - GetCost() -100
    // If we want to add extra properties like Chocolate - Adds 50 extra 
    // If we want to add extra properties like Nuts - Adds 100 extra
    // We are decorating icecream with Chocolates and Nuts 

    internal class DecoratorDesignPattern
    {
        // Component
        public interface ICar
        {
            string Make { get; }
            double GetPrice();
        }



        // Concrete Component
        // Add Sealed to class to apply discount
        public sealed class Tata : ICar
        {
            public string Make {
                get { return "HatchBack"; }
            }

            public double GetPrice()
            {
                return 10000;
            }
        }

        // Concrete Component
        // Add Sealed to class to apply discount
        public sealed class Maruti : ICar
        {
            public string Make
            {
                get { return "HatchBack"; }
            }

            public double GetPrice()
            {
                return 10000;
            }
        }



        // Decorator - Need to apply Additinal Discount
        public abstract class CarDecorator : ICar
        {
            private ICar car;
            public CarDecorator(ICar car)
            {
                this.car = car;
            }

            public string Make
            {
                get { return car.Make; }
            }

            public double GetPrice()
            {
                return car.GetPrice();
            }

            // Now this is ready to get Extended
            public abstract double GetDiscountedprice();
        }

        // Decorator - Need to apply Additinal Discount
        public abstract class AccesoriesDecorator : ICar
        {
            private ICar car;
            public AccesoriesDecorator(ICar car)
            {
                this.car = car;
            }

            public string Make
            {
                get { return car.Make; }
            }

            public double GetPrice()
            {
                return car.GetPrice();
            }

            // Now this is ready to get Extended
            public abstract double GetAccesories();
        }



        // Concrete Decorator
        public class NormalOfferPrice : CarDecorator
        {
            public NormalOfferPrice(ICar car): base(car)
            {

            }

            public override double GetDiscountedprice()
            {
                return 0.6 * base.GetPrice();
            }
        }

        // Concrete Decorator
        public class EmployeeOfferPrice : CarDecorator
        {
            public EmployeeOfferPrice(ICar car) : base(car)
            {

            }

            public override double GetDiscountedprice()
            {
                return 0.8 * base.GetPrice();
            }
        }


        // Client
        public class ProgramCDP
        {
            public void Main()
            {
                ICar car = new Maruti();
                CarDecorator decorator = new NormalOfferPrice(car);

                string carMake = decorator.Make;
                double price = decorator.GetPrice();
                double discountedprice = decorator.GetDiscountedprice();
            }
        }

    }
}
