using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    // Main purpose - 
    // This pattern sends data to an object and if that object cant use/handle that,
    // it will send it to other objects that may be able to use/handle it

    // Create 4 objects - Add, Subtract, Multiply and Divide
    // Send 2 Numbers and a Command and allow these objects to decide which can handle the requested calculation
    internal class ChainOfResponsibilityDesignPattern
    {
        // Chain Handler
        public interface IChain
        {
            void SetNextChain(IChain nextChain);
            void Calculate(int a, int b, string command);
        }

        public class Add : IChain
        {
            private IChain nextChain;
            public void Calculate(int a, int b, string command)
            {
               if(command == "Add")
                {
                    Console.WriteLine(a + b);
                }
                else
                {
                    nextChain.Calculate(a, b, command);
                }
            }

            public void SetNextChain(IChain nextChain)
            {
                this.nextChain = nextChain;
            }
        }

        public class Subtract : IChain
        {
            private IChain nextChain;
            public void Calculate(int a, int b, string command)
            {
                if (command == "Subtract")
                {
                    Console.WriteLine(a - b);
                }
                else
                {
                    nextChain.Calculate(a, b, command);
                }
            }

            public void SetNextChain(IChain nextChain)
            {
                this.nextChain = nextChain;
            }
        }

        public class Multiply : IChain
        {
            private IChain nextChain;
            public void Calculate(int a, int b, string command)
            {
                if (command == "Multiply")
                {
                    Console.WriteLine(a * b);
                }
                else
                {
                    nextChain.Calculate(a, b, command);
                }
            }

            public void SetNextChain(IChain nextChain)
            {
                this.nextChain = nextChain;
            }
        }

        public class Divide : IChain
        {
            private IChain nextChain;
            public void Calculate(int a, int b, string command)
            {
                if (command == "Divide")
                {
                    Console.WriteLine(a / b);
                }
                else
                {
                    Console.WriteLine("Please send command as only Add/Subtract/Multiply/Divide");
                }
            }

            public void SetNextChain(IChain nextChain)
            {
                this.nextChain = nextChain;
            }
        }

        public class ClientCOR
        {
            public void Main()
            {
                IChain chain1 = new Add();
                IChain chain2 = new Subtract();
                IChain chain3 = new Multiply();
                IChain chain4 = new Divide();

                chain1.SetNextChain(chain2);
                chain2.SetNextChain(chain3);
                chain3.SetNextChain(chain4);

                chain1.Calculate(6, 2, "Subtract");
            }
        }
    }
}
