using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    // Provide a Unified Interface to a set of Interfaces in SubSystem
    // Its French word called Face - Exterior Appereance
    // Provide Abstracted Interface of Complex Subsystems
    // Its Entry point to Sub System Levels

    // Subsystems doesnot maintain reference to Facade - It just performs actual work
    // Facade does extra work 


    internal class FaçadeDesignPattern
    {
        // Sub Systems

        public interface IOrder
        {
            List<string> ConsolidateAllTheOrders(string item);
            bool PlaceOrder(List<string> orders);
        }

        public interface ITax
        {
            long CalculateTax(long amount);
        }

        public interface IItems
        {
            string AddItemsToCart(string item, int quantity);
            bool CheckForAvailability(string item, int quantity);
        }

        public interface IPayment
        {
            bool IsBalanceAvailable(string accountDetails);
            bool IsPaymentSuccessFul(long amount, string cardNumber);
        }


        // Facade 

        public interface IUserOrder
        {
            void AddItems(string itemName, int quantity);

            void PlaceOrder(string itemName, int quantity, string accountDetails);
        }

        public class UserOrder : IUserOrder
        {
            public void AddItems(string itemName, int quantity)
            {
                IItems item = null;
                if (item.CheckForAvailability(itemName, quantity))
                {
                    var result = item.AddItemsToCart(itemName, quantity);
                    Console.WriteLine(result + " Items Added SuccessFully");
                }
                Console.WriteLine("There is no availability of the Items");
            }

            public void PlaceOrder(string itemName, int quantity, string accountDetails)
            {
                IOrder order = null;
                order.ConsolidateAllTheOrders("Orders");
                ITax tax = null;
                long calculatedTax = tax.CalculateTax(54200);
                IPayment payment = null;
                if(payment.IsBalanceAvailable(accountDetails))
                {
                    long balance = Convert.ToInt64(accountDetails);
                    long finalAmount = calculatedTax + balance;

                    if(payment.IsPaymentSuccessFul(finalAmount,accountDetails))
                    {
                        order.PlaceOrder(new List<string>() { itemName });
                    }
                }
            }
        }

        // Client

        public class FacadeClient
        {
            public void Main()
            {
                //Facade

                IUserOrder userOrder = new UserOrder();

                userOrder.AddItems("Laptop", 1);
                userOrder.PlaceOrder("Laptop", 1, "4234566");
  
            }
        }
    }
}
