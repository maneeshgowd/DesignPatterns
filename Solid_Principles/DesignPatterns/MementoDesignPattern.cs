using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    // Memento - an object kept as a reminder of a person or event:

    // Memento allows you to keep snapshot of the original object state,
    // which can be reverted any moment it is required.

    // Or its a way you can capture internal state of the object without violating encapsulation
    // Preserve or hide access to the state.

    // In ADO.NET Memento can be useful, but using latest LINQ and EF we can manage the states so not required. But internally it wil be using the ADO.NET only

    // One Way of doing is if you have Update and Revert Button, Take Original Value and keep in Object/ Class and when we click on Revert we can revert that with this object.

    // Consider Example of Business - We can move forward by some position and when we want to move back that step, it has to remember how many steps and take back that

    // It is like Command Patterns which works on Actions 
    internal class MementoDesignPattern
    {
        // Using this Class we are encapsulating the State - States
        public class Position
        {
            public Position GetCurrentPosition()
            {
                return this;
            }

            public void MovePosition(int steps)
            {
                // Move Forward by the steps
            }

            public Position FetchLastPosition()
            {
                return this;
            }

            public void SetPosition(Position position)
            {
                // Move Forward by the steps
            }
        }
       


        public class Business
        {
            // State is consumed here where state can be encapsulated
            List<Position> positionMemory = new List<Position>();

            public void MoveForward()
            {
                Position position = new Position();
                // Rolling Dice 
                var currentPosition = position.GetCurrentPosition(); // 2


                // Store Original Postion in a Stack
                positionMemory.Add(position);

                int diceValue = new Random().Next(1, 6);

                position.MovePosition(diceValue); // 6

            }

            public void MoveBackward()
            {
                Position position = new Position();

                var oldPosition = position.FetchLastPosition();
                positionMemory.Remove(oldPosition);

                // Set the Latest Position to Old Postion
                position.SetPosition(oldPosition); // 2
            }
        }

        public class ClientMDP
        {
         public void Main()
            {
                Business business = new Business();
                business.MoveForward();
                business.MoveForward();
                business.MoveForward(); // Undo
                // Violation
                business.MoveBackward();

                business.MoveBackward();

                business.MoveForward();
                business.MoveForward();
                business.MoveBackward();
            }
        }
    }
}
