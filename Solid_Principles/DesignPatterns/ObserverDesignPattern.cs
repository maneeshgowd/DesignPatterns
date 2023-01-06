using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{

    // It is a pattern where objects are represented as observers that wait for an event to trigger.
    // When the new event is triggered, the multiple observers catch these events.


    // it creates one to many relationship between objects

    // if one object changes, then other objects are notified and they update themselves


    internal class ObserverDesignPattern
    {
        // Subject - Weather Station
        public interface ISubject
        {
            // For observers to Attach or Register themselve with Subject
            void Attach(IObserver observer);
            void Notify();
        }

        public class WeatherStation :ISubject
        {
            private List<IObserver> _observers;
            private float _temparature;


            public float Temperature
            {
                get
                {
                    return _temparature;
                }
                set
                {
                    // If Temperature is changed we need to Notify
                    _temparature = value;
                    Notify();
                }
            }


            public WeatherStation()
            {
                _observers = new List<IObserver>();
            }

            public void Attach(IObserver observer)
            {
                _observers.Add(observer);
            }

            // If Change is made to state of Subject
            public void Notify()
            {
                foreach(var observer in _observers)
                {
                    observer.Update(this);
                }
            }
        }


        // Observers - News Station

        public interface IObserver
        {
            void Update(ISubject subject);
        }

        public class NewsAgency : IObserver
        {
            public string AgencyName { get; set; }

            public NewsAgency(string name)
            {
                AgencyName = name;
            }
            public void Update(ISubject subject)
            {
                WeatherStation weatherStation = subject as WeatherStation;
                if(weatherStation != null)
                {
                    Console.WriteLine("Temprature has changed to " + weatherStation.Temperature + " from " + AgencyName);
                }
            }
        }

        public class  ClientODP
        {
            public void Main()
            {
                // Subject
                WeatherStation weatherStation = new WeatherStation();


                NewsAgency ndtvNews = new NewsAgency("NDTV");

                NewsAgency bbcNews = new NewsAgency("BBC");

                NewsAgency cnnNews = new NewsAgency("CNN");

                weatherStation.Attach(ndtvNews);
                weatherStation.Attach(bbcNews);
                weatherStation.Attach(cnnNews);


                // Notify Methods will be Called
                weatherStation.Temperature = 33.4f;
                weatherStation.Temperature = 41.0f;
            }
        }

        // Real time Examples are Delegates and Events use Observer Design Pattern
    }
}
