using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    // Abstract Factory Design Pattern - Its a Creational Design Pattern

    // An abstract factory pattern is also known called the Factory of Factories because it is a super factory that creates other factories.
    // It provides an interface that responsible for creating a factory of related objects without explicitly specifying their classes.


    // Create a Common Interface for Factory.
    // Create a Abstract factory which uses this interface because it can also
    // provide common methods in this class for all the factories.

    // Wrapper
    public class DataObject
    {
        private Object dataObject;
        public DataObject(object dataObject)
        {
            this.dataObject = dataObject;
        }

        public object DataObjectProperty => dataObject;
    }

    public interface IFactory
    {
        DataObject GetDataObject(string type);
    }

    public abstract class AbstractFactory : IFactory
    {
        //Abstract
        public abstract DataObject GetDataObject(string type);

        // Implemented
        public void CommonMethod()
        {
        }
    }

    public class ShapeFactory : AbstractFactory
    {
        public override DataObject GetDataObject(string type)
        {
            if (type == "Circle")
            {
                return new DataObject(new Circle());
            }
            else if (type == "Rectangle")
            {
                return new DataObject(new Rectangle());
            }
            return null;
        }
    }

    public class ColorFactory : AbstractFactory
    {
        public override DataObject GetDataObject(string type)
        {
            if (type == "Red")
            {
                return new DataObject(new Red());
            }
            else if (type == "Blue")
            {
                return new DataObject(new Blue());
            }

            return null;
        }
    }

    public class FactoryClass
    {
        public static IFactory CreateFactory(string type)
        {
            if(type == "Shape")
            {
                return new ShapeFactory();
            }
            else if(type == "Color")
            {
                return new ColorFactory();
            }
            return null;
        }
    }

    public class Red
    {

    }

    public class Blue
    {

    }

    public class Rectangle
    {

    }

    public class Circle
    {

    }

    // Client
    public class Main
    {
        public void MainMethod()
        {
            // Create Factory
            IFactory factory = FactoryClass.CreateFactory("Shape");


            var result = factory.GetDataObject("Circle");
            var actualObject = result.DataObjectProperty;

            IFactory factory1 = FactoryClass.CreateFactory("Color");


            var result1 = factory1.GetDataObject("Red");
            var actualObject1 = result.DataObjectProperty;
        }

}

    // Can again create Factory for Factory Classes
}
