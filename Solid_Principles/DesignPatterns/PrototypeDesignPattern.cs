using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    // Prototype Design Pattern – It is a Creational Design Pattern

    // Instead of creating new objects from scrach everytime, create a copy of the prototype and then modify it.
    // when creating is expensive than copying, then use this.
    // Here it doesnot require a class to create object but just another object
    // When objects that we need are similar to existing objects.
    // also we use this when we want to hide the complexity of creating objects from clients.


    // Shallow Copy
    // Salary and Name - Creates copy and new memory for value types
    // Address - Creates copy and reference old memory for reference types

    // Initial Phase
    public class EmployeePDP {

        public string Name {  get; set; }
        public int Salary { get; set; }
        public Address Address { get; set; }
    }


    public class Address
    {
        public Address(int doorNumber, string street, long pinCode) 
        {
            DoorNumber = doorNumber;
            Street = street;
            PinCode = pinCode;
        }
        public int DoorNumber { get; set; }
        public string Street { get; set; }
        public long PinCode { get; set; }
    }

    // MemberwiseClone() - which is inside System.Object and works as Shallow copy
    // It copies non static fields to the new object
    // If memberwise clone finds the field is value type then it will perform bit by bit copy
    // If its reference type it will copy reference but not reference object

    // Changes for Shallow 

    // ICloneable - Provides Customized support of creating a copy of existing object
    // Clone method provides support beyond memberwiseclone method

    // Shallow Copy
    public class EmployeeAC : ICloneable
    {

        public int Salary { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }





    //Deep Copy
    //Class Employee {
    //Id, Name -Creates copy and new memory for value types
    //Address  - Creates copy and new memory for even reference types

    public abstract class CloneProtoType<T>
    {
        // Shallow Copy
        public T Clone()
        {
            return (T)this.MemberwiseClone();
        }

        // Deep Copy
        // Deep Copy can be done in many ways here we are using Json Serializer to serialize and
        // deserialize back to avoid memory referenceing
        public T DeepCopy()
        {
            string result = JsonConvert.SerializeObject(this);
            return JsonConvert.DeserializeObject<T>(result);
        }
    }

    public class EmployeeDC : CloneProtoType<EmployeeDC>
    {

        public int Salary { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
    }
}


