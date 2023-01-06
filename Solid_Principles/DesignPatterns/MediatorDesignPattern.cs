using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    // There is a Popular Library which implements this pattern - MediateR
    // Supports interaction between objects
    // Mediator mediates between 2 people like Broker - Centralize Interaction between objects
    // this is like fascade 

    internal class MediatorDesignPattern
    {
        // Before Mediator
        // Here both the Classes have Cyclic References between each other
        public class LandOwner
        {
            private Worker worker;
           public LandOwner(Worker worker)
            {
                this.worker = worker;
            }
            public void RequentMoney()
            {
                worker.GetMoney();
            }
        }

        public class Worker
        {
            private LandOwner owner;
            public Worker()
            {

            }
            public void GetMoney()
            {

            }
            public void RequestSalary()
            {
                owner.RequentMoney();
            }

        }


        // IMediator
        public interface IBroker
        {
            void Interaction(string request);
        }

        // Mediator
        public class Broker : IBroker
        {
            public Owner Owner { get; set; }
            public Tenant Tenant { get; set; }

            public Broker()
            {

            }

            public void Interaction(string request)
            {
                if (request == "AskRent")
                {
                    Tenant.AskRent();
                }
                else if (request == "AskFacility")
                {
                    Owner.AskFacility();
                }
            }
        }

        public class Owner
        {
            private IBroker broker;
            public Owner(IBroker broker)
            {
                this.broker = broker;
            }
            public void Invoke()
            {
                broker.Interaction("AskRent");
            }

            public void AskFacility()
            {
                Console.WriteLine("Facility asked");
            }

        }

        public class Tenant
        {
            private IBroker broker;
            public Tenant(IBroker broker)
            {
                this.broker = broker;
            }
            public void Invoke()
            {
                broker.Interaction("AskFacility");
            }

            public void AskRent()
            {
                Console.WriteLine("Rent asked");
            }

        }
    }
}
