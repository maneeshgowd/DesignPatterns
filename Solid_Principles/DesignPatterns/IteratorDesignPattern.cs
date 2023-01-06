using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    // Iterator pattern also called as cursor/ Generator

    // Example using Linked List- Ppl might ask why not Array? There are constraints on Length and memory so

    // The Main Intent of this pattern is to provide a way to access the elements of an aggregate object sequentially
    // without exposing its underlying representation
    // We can seperate the implementation of a collection from its iteration
    // As per Solid Principle - The Collection which is a aggregation of objects should not have the responsibility of iteration


    internal class IteratorDesignPattern
    {

        // Similar to List
        public class Aggregate<T> : IAggregate<T>
        {
            private IIterator<T> _iterator;
            private List<T> _list = new List<T>();

            public T this[int index]
            {
                get { return _list[index]; }
                set { _list.Add(value); }
            }

            public IIterator<T> Iterator
            {

                get
                {
                    if (_iterator == null) _iterator = new Iterator<T>(this);
                    return _iterator;
                }
            }

            public int Count => _list.Count;
        }

        // Similar to IList
        public interface IAggregate<T>
        {
            T this[int index] { get; set; }

            int Count { get; }

            IIterator<T> Iterator { get; } // GetEnumerator();
        }

        public class Iterator<T> : IIterator<T>
        {
            private readonly IAggregate<T> aggregate;
            int index = 0;
            public Iterator(IAggregate<T> aggregate)
            {
                this.aggregate = aggregate;
            }

            public T Current => aggregate[index];

            public bool HasValue => index < aggregate.Count;

            public T MoveNext()
            {
                index++;
                return aggregate[index];
            }
        }

        // We have to deal with Interface and not concrete - Similar to IEnumerator
        public interface IIterator<T>
        {
            T Current { get; }
            bool HasValue { get; }
            T MoveNext();   
        }

        public class Employee
        {
            public Employee(string name, int age)
            {

            }
        }

        public class ClientIDP
        {
            public void Original()
            {
                var employees = new List<Employee>();
                employees[0] = new Employee("Kunal", 25);
                employees[1] = new Employee("Karen", 24);
                employees[2] = new Employee("Prachi", 20);


                var iterator = employees.GetEnumerator();

                while (true)
                {
                    Console.WriteLine(iterator.Current);
                    iterator.MoveNext();
                }

                // Internally Calls Current and MoveNext
                foreach (var employee in employees)
                {
                    // Print
                }
            }

            public void Main()
            {
                var employees = new Aggregate<Employee>();
                employees[0] = new Employee("Kunal", 25);
                employees[1] = new Employee("Karen", 24);
                employees[2] = new Employee("Prachi", 20);


                var iterator = employees.Iterator;

                while(iterator.HasValue)
                {
                    Console.WriteLine(iterator.Current);
                    iterator.MoveNext();
                }
        
            }
        }

        // If you want to implement your own iterator then we can use this else we can go with existing Design Pattern
        // Practical Example IList - IAggregate, List - Aggregate , 
        // IEnumerator - IIterator  - IEnumerable.GetEnumerator facilates to get the Iteation from Aggregation
    }
}
