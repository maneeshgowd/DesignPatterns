using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    // Easiest Pattern we use in our day to day coding
    // Template is like a Blueprint of Methods
    // Class which uses this Tempplate has to be able to Substitute of this

    // If you are using Interface and Abstract class you are using Template Method by Default

    internal class TemplateMethodDesignPattern
    {
        public abstract class House
        {
            // Template Method where Blueprint/ Steps cannot be Changed
            // You will Hook into the Default Algorithm or Blueprint through your custom Step

            public void Build()
            {
                Foundation();
                Pillars();
                Walls();
                Windows();
                Extra();
            }

            // Optional Steps to Override
            public virtual void Foundation()
            {
                Console.WriteLine("Basic Foundation for the House");
            }

            public virtual void Pillars()
            {
                Console.WriteLine("Basic Pillars for the House");
            }

            public virtual void Walls()
            {
                Console.WriteLine("Basic Walls for the House");
            }
            public virtual void Windows()
            {
                Console.WriteLine("Basic Windows for the House");
            }

            // Mandatory to Override
            public abstract void Extra();
        }

        public class Villa : House
        {
            public override void Walls()
            {
                Console.WriteLine("Stone Walls for the House");
            }
            public override void Windows()
            {
                Console.WriteLine("Glass Windows for the House");
            }

            public override void Extra()
            {
                Console.WriteLine("Garden for the House");
            }
        }

        public class Apartment : House
        {
            public override void Windows()
            {
                Console.WriteLine("Fabric Windows for the House");
            }

            public override void Extra()
            {
                Console.WriteLine("Lift for the House");
            }
        }


        public class ClientTMDP
        {
            public void Main()
            {
                Villa villa = new Villa();
                villa.Build();

                Apartment apartment = new Apartment();
                apartment.Build();
            }
        }
    }
}
