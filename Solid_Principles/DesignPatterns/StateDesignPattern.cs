using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    // Object can change its behavior dependending on the state which it is in

    // Example - Drinking Coffee, Alocohol or Tired. States are different so Behavior will be Different
    // Person(Object) is Choosing himself to alter the State
    internal class StateDesignPattern
    {
        // Before implementing Design Pattern
        public class ComputerBefore
        {
            private int state = 0;
            private bool isCharging;
            public void PressPowerButton()
            {
                // If it is Off
                if(state == 0)
                {
                    // Logic Switch On Computer
                    state = 1;
                    return;
                }

                // If it is On
                if (state == 1)
                {
                    if(isCharging)
                    {
                        // Logic Switch StandBy Computer
                        state = 2;
                        return;
                    }
                    else
                    {
                        state = 0;
                        return;
                    }
                }

                // If it is StandBy
                state = 1;
                return;
            }
        }

        // After implementing Design Pattern
        public class Computer
        {
            private State _state = new Off();

            public void SetState(State state)
            {
                _state = state;
            }
            public void PressPowerButton()
            {
                _state.PressPowerButton(this);
            }
        }

        public interface State
        {
           void PressPowerButton(Computer computer);
        }

        public class On : State
        {
            private bool isCharging;
            public void PressPowerButton(Computer computer)
            {
                if(isCharging)
                {
                    // Logic moving Computer to Standup
                    computer.SetState(new StandBy());
                }
                else
                {
                    computer.SetState(new Off());
                }
                
            }
        }

        public class Off : State
        {
            public void PressPowerButton(Computer computer)
            {
                // Logic to Switch the Computer to On 
                computer.SetState(new On());
            }
        }

        public class StandBy : State
        {
            public void PressPowerButton(Computer computer)
            {
                // Logic to Switch On
                computer.SetState(new On());
            }
        }
    }
}
