using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    // Strategy is a behavioral design pattern that turns a set of behaviors into objects
    // and makes them interchangeable inside original context object.
    // Strategy to make a Tea- First u may add water then Milk or otherwise
    // It can be applied in various ways - You may be using this without the knowledge

    internal class StrategyDesignPattern
    {
        public interface IDatabase
        {
            string GetTable(int id);
            void SaveTable();
        }

        // Strategy is interchangable as long as we go and follow interface
        // You want to remove something and add new one 
        // May be databases we can interchange
        public class SQLDatabase : IDatabase
        {
            public string GetTable(int id)
            {
                return "Table from SQL Database";
            }

            public void SaveTable()
            {
                Console.WriteLine("Saving Table in SQL Database");
            }
        }

        public class OracleDatabase : IDatabase
        {
            public string GetTable(int id)
            {
                return "Table from Oracle Database";
            }

            public void SaveTable()
            {
                Console.WriteLine("Saving Table in Oracle Database");
            }
        }

        public class MongoDatabase : IDatabase
        {
            public string GetTable(int id)
            {
                return "Table from Oracle Database";
            }

            public void SaveTable()
            {
                Console.WriteLine("Saving Table in Oracle Database");
            }
        }

        public class FileController
        {
            private IDatabase storage;
            public FileController(IDatabase storage)
            {
                this.storage = storage;
            }

            public void SaveTable()
            {
                storage.SaveTable();
            }
        }

        public class ClientSDP
        {
            public void Main()
            {
                IDatabase oracleDatabase = new SQLDatabase(); 
                FileController fileController = new FileController(oracleDatabase);
                fileController.SaveTable();
            }
        }
    }
}
