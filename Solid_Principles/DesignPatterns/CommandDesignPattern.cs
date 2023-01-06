using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    // behavioral design pattern in which an object is used to encapsulate all information needed to perform an action or trigger an event at a later time
    // Change the Behavior without altering the Structure of Architecture
    // Command pattern allows to exists as an object.
    // Example you do Control X- its saved as an class or object which can be used later
    // When to use - when you want to maintain request as classes and objects

    internal class CommandDesignPattern

    {
        // Normal flow - Lot of if Conditions - Future if we need to add something it will change the structure again
        public void FileAction(string action)
        {
            if(action == "Open")
            {
                Console.WriteLine("Open File");
            }
            else if (action == "Close")
            {
                Console.WriteLine("Close File");
            }
            else if (action == "Save")
            {
                Console.WriteLine("Save File");
            }
            else if (action == "Delete")
            {
                Console.WriteLine("Delete File");
            }
        }





        public interface IExecuteCommand
        {
            string ActionCommand { get; set; }
            void Execute();
        }

        public class OpenCommand : IExecuteCommand
        {
            public string ActionCommand { get; set; }
            public OpenCommand()
            {
                ActionCommand = "Open";
            }

            public void Execute()
            {
                // Logic wrt Opening File
                Console.WriteLine(ActionCommand + " File");
            }
        }

        public class CloseCommand : IExecuteCommand
        {
            public string ActionCommand { get; set; }
            public CloseCommand()
            {
                ActionCommand = "Close";
            }

            public void Execute()
            {
                Console.WriteLine(ActionCommand + " File");
            }
        }

        public class SaveCommand : IExecuteCommand
        {
            public string ActionCommand { get; set; }
            public SaveCommand()
            {
                ActionCommand = "Save";
            }

            public void Execute()
            {
                Console.WriteLine(ActionCommand + " File");
            }
        }

        public class DeleteCommand : IExecuteCommand
        {
            public string ActionCommand { get; set; }
            public DeleteCommand()
            {
                ActionCommand = "Delete";
            }

            public void Execute()
            {
                Console.WriteLine(ActionCommand + " File");
            }
        }

        public class UndoCommand : IExecuteCommand
        {
            public string ActionCommand { get; set; }
            public UndoCommand()
            {
                ActionCommand = "Undo";
            }

            public void Execute()
            {
                // logic Undo
                Console.WriteLine(ActionCommand + " File");
            }
        }

        // Invoker Executes the Commands
        public class Invoker
        {
            private IList<IExecuteCommand> commands = new List<IExecuteCommand>();

            public Invoker()
            {
                commands.Add(new OpenCommand());
                commands.Add(new CloseCommand());
                commands.Add(new SaveCommand());
                commands.Add(new DeleteCommand());
                commands.Add(new UndoCommand());
            }

            public IExecuteCommand GetCommand(string action)
            {
                foreach(IExecuteCommand command in commands)
                {
                    if(command.ActionCommand == action)
                    {
                        return command;
                    }
                }
                return null;
            }
        }

        //Client - In Future if new Requests/ Action Comes we just add new Class without altering the Architecture
        public class ClientCDP
        {
            public void Main()
            {
                Invoker commandInvoker = new Invoker();
                IExecuteCommand command = commandInvoker.GetCommand("Save");
                command.Execute();

                Invoker commandInvoker1 = new Invoker();
                IExecuteCommand command1 = commandInvoker1.GetCommand("Undo");
                command.Execute();
            }
        }

        // Practical Use case would be when you do Undo and Redo, it saves the whole action with the data
        // so when you revert back it will be able to come back to its old state
        // When you want to save actions along with data. Games - Shooting, Walking, Save as objects and reuse again

    }
}
