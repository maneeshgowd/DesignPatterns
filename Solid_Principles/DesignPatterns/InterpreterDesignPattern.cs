using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DesignPatterns
{
    // Interpreter design pattern is one of the behavioral design pattern.
    // Interpreter pattern is used to defines a grammatical representation for a language and provides an interpreter to deal with this grammar.

    // Instead of going and Filling a form to order something.
    // i will just say order me coke from Reliance - which will be interpreted by system and routed to correct place

    // Practically these type of Patterns are used in Alexa, Google Home and Siri when we can Speak and Order Something from Amazon.

    internal class InterpreterDesignPattern
    {
        public class ClientIDP
        {
            public void Main()
            {
                string voiceMessage = "Order 5 'Play Station' from Amazon";
                Alexa alexa = new Alexa(voiceMessage);
                alexa.PlaceOrder();
            }    
        }

        public class Alexa
        {
            const string space = " ?";
            const string quantity = "(?<quantity>\\d+)" + space;
            const string product = "'(?<product>[\\w]+)'" + space;
            const string place = " from (?<place>\\w+)";
            const string orderCommand = "order" + space + quantity + product + place;

            private string sentence;
            private Regex regex;
            public Alexa(string sentence)
            {
                this.sentence = sentence;
                regex = new Regex(orderCommand);
            }

            public void PlaceOrder()
            {
                var match = regex.Match(sentence);
                if(match.Success)
                {
                    int quantity = int.Parse(match.Groups["quantity"].Value);
                    string product = match.Groups["product"].Value;
                    string place = match.Groups["place"].Value;
                    Order order = new Order(quantity, product, place);
                    Console.WriteLine("Order has been successfully placed");
                }
                else
                {
                    Console.WriteLine("Please Repeat once again");
                }
            }

        }

        public class Order
        {
            public int Quantity { get; set; }
            public string Product { get; set; }
            public string Place { get; set; }

            public Order(int quantity, string product, string place)
            {
                Quantity = quantity;
                Product = product;
                Place = place;
            }

            // Payment Gameway
        }
    }
}
