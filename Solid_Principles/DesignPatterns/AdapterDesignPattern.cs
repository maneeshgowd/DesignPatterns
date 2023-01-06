using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace DesignPatterns
{
    // Adapter match interfaces of different classes
    // It allows incompatible classes to interact with each other by converting interface of one class
    // into an interface expected by the clients.
    // Without modifying the source code of other class
    // It helps in reusability of older functionality

    // Acts as a Bridge between 2 incompatible interfaces

    // When to use
    // 1. Class needs to be reused when it doesnot have an interface
    // 2.we need to work through adarpter which adapts the interface of existing class without changing it
    // Client doesnot know which they work through - Adapter or class
    // AC adapter
    internal class AdapterDesignPattern
    {
        public class Student
        {
            public int StudentId { get; set; }
            public string StudentName { get; set; }
        }

        // Adaptee Class
        public class StudentRegistry
        {
            public List<Student> Students;
            public StudentRegistry()
            {
                Students = new List<Student>();
                Students.Add(new Student { StudentId = 1, StudentName = "First Student"});
                Students.Add(new Student { StudentId = 2, StudentName = "Second Student" });
                Students.Add(new Student { StudentId = 3, StudentName = "Third Student" });
            }

            // Get Data in XML Format
            public string GetAllStudents()
            {
                var namespaces = new XmlSerializerNamespaces();
                var serializer = new XmlSerializer(Students.GetType());
                var settings = new XmlWriterSettings();

                using(var stream = new StringWriter())
                {
                    using(var writer = XmlWriter.Create(stream, settings))
                    {
                        serializer.Serialize(writer, Students, namespaces);
                        return stream.ToString();
                    }
                }
            }
        }

        // Target Interface
        public interface IStudentRegistry
        {
            string GetAllStudentsUpdated();
        }

        // Adapter
        public class StudentAdapter : StudentRegistry, IStudentRegistry
        {
            // Get Data in Json Format
            public string GetAllStudentsUpdated()
            {
                string xmlData =  base.GetAllStudents();
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(xmlData);
                return JsonConvert.SerializeObject(xmlDocument);
            }
        }

        // Client 
        public class AdapterClient
        {
            public void Main()
            {
                IStudentRegistry studentRegistry = new StudentAdapter();
                string result = studentRegistry.GetAllStudentsUpdated();
                Console.WriteLine(result);
            }
        }
    }
}
