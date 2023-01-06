using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{

// Note: you should never say "reference types are allocated on the heap while value types are allocated on the stack",
// this is a commonly repeated mistake.
// Reference types (classes, interfaces, delegates) are always allocated on the heap.
// When you pass a reference object as a parameter or assign it to a variable, you're in fact passing its reference.
// By passing a reference to an object, you're telling where that object is located on the heap so that your code can access it.
// Value types (derived from System.ValueType, e.g. int, bool, char, enum and any struct) can be allocated on the heap or on the stack,
// depending on where they were declared.


//•	If the value type was declared as a variable inside a method then it's stored on the stack.
//•	If the value type was declared as a method parameter then it's stored on the stack.
//•	If the value type was declared as a member of a class then it's stored on the heap, along with its parent.
//•	If the value type was declared as a member of a struct then it's stored wherever that struct is stored.

    internal class StackAndHeap
    {
        // Heap
        public class AddressSH
        {
            string Country = "India";
            int PinCode = 560078;
            PermanentEmployee employee = new PermanentEmployee();
        }

        public struct NewStruct
        { 
        }

        public void MainSH()
        {
            // Stack
            int x = 10;

            // Stack
            int y = 20;

            // Stack
            int z = x + y;

            // Heap
            PermanentEmployee employee1 = new PermanentEmployee();

            // Heap
            PermanentEmployee employee2 = new PermanentEmployee();

        }
    }
}

















// Static variable goes to the special reason within Heap. It is called High Frequency Heap , all the static variables go to the High Frequency Heap in memory.
// Objects in High Frequency Heap is not garbage collected by GC and hence static variables available throughout life time of an application.
