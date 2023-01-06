using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    // Bridge - It decouples abstractions from implementations so both can be modified indepdently
    // It involves Interface which acts as an Bridge between 2 Components

    // When to Choose
    // 1. When we want to avoid permanent binding b/w abstraction and implementation
    // 2. Both Abstraction and implementations should be extensible
    internal class BridgeDesignPattern
    {
        // Implementor Interface - Bridge
        public interface IPaymentSystem
        {
            // Debit Card and Credit Card Payment for Payment Type
            void ProcessPayment(string paymentType);
        }



        // There will be Different Payment Gateways - HDFC and ICICI

        // Concrete Implementors for given Interface 
        public class HDFCPaymentSystem : IPaymentSystem
        {
            public void ProcessPayment(string paymentType)
            {
                Console.WriteLine("HDFC Payment : " + paymentType);
            }
        }


        // Concrete Implementors for given Interface 
        public class ICICIPaymentSystem : IPaymentSystem
        {
            public void ProcessPayment(string paymentType)
            {
                Console.WriteLine("ICICI Payment : " + paymentType);
            }
        }

        // We Need to use this Gateways and bridge with Payment Types - Debit or Credit Card
        // Gateways are Internal representation to the System and Payment Types are higher Abstractions exposed to end Clients
        // Bridge pattern connects this in Runtime



        // Higher Abstract Class
        public abstract class Payment
        {
            public IPaymentSystem _IPaymentSystem;
            public abstract void MakePayment();
        }

        // Redined Abstract Class

        public class DebitCard : Payment
        {
            public override void MakePayment()
            {
                _IPaymentSystem.ProcessPayment("DebitCard");
            }
        }

        public class CreditCard : Payment
        {
            public override void MakePayment()
            {
                _IPaymentSystem.ProcessPayment("CreditCard");
            }
        }

        // We need to Bridge IPaymentSystem



        // Client
        public class ProgramCDP
        {
            public void Main()
            {
                Payment order = new DebitCard();


                order._IPaymentSystem = new HDFCPaymentSystem();
                order.MakePayment();


                order._IPaymentSystem = new ICICIPaymentSystem();
                order.MakePayment();
            }
        }
    }

    // We have Decoupled the Abstraction from its Implementations
}
