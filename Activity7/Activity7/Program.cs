using System;

namespace Activity7
{
    class Program
    {   
        // An Ingerface provides a contract to specifying how to create an object, without caring about the specifics of how
        // they do things.  It is a reference type and only includes abstract members such as Events, Methods, and Properties,
        // and has no implementations for any of it's members.  If you implement an Interface in your Class, you ahve to declare
        // all of the Interface's Events, Methods, and Properties in you Class.  An Interface can have only Abstract methods and
        // Constants, which are always implicity public, static, and final.
        interface Vehicle
        {
            void pressGas();
            void pressBrakes();
        }

        // A Class is a blueprint or prototype from which individual Objects are created.  A Class is a template that describes
        // the kinds of state and behavior that Objects of it's type support.  Below, the Car Class is the blueprint for a Car.
        // Using this blueprint, we can build a delorian, which is an object of the Class Car.
        public class Car : Vehicle
        {
            public string model;
            public int numberOfTires;
            public string engineSize;

            public Car(string make, int tires, string engine)
            {
                model = make;
                numberOfTires = tires;
                engineSize = engine;
            }

            public void pressGas()
            {
                Console.WriteLine("Accelerating to 88 MPH!");
            }

            public void pressBrakes()
            {
                Console.WriteLine("Slowing down.....");
            }

            public void honkHorn()
            {
                Console.WriteLine("Beep, Beep.....");
            }

        }

        // A Class has both definition and an implentation.  An Interface has only a definition.
        // A Class can be instantiated but an Interface cannot be instatiated.  However, you can create and instance
        // of an Object from a Class that implements an Interface.  In this example, the Car Class implements the
        // Vehicle Interface.

        // A Class is a full body entity with members, methods, etc along with there definitions and implementations.
        // An Interface is a set of definitions that must be implemented in the Class that is inheriting the Interface.

        //*************************************************************************************************************

        // In simple terms a Structure (struct) is a simple user-defined type (like int or string).  Basically a lightweight alternative 
        // to a Class.  It is a composite data type consisting of a number of elements of other types.  Structs share many features with
        // classes but do have a few limitations as compared to classes:
        // 1.  Struct cannot have a default contructor (they must have parameters) or a destructor.
        // 2.  Struct is a value type while a Class is a reference type
        // 3.  Struct can be instantiated without using the new operator.
        // 4.  Struct cannot inherit from another Struct or Class, and it cannot be the bass of a Class, but they can implement interfaces.
        // 5.  Because they cannot be a base class, they cannot abstract and are always implicity sealed.
        struct Coordinate
        {
            public int xAxis;
            public int yAxis;

            public Coordinate(int x, int y)
            {
                xAxis = x;
                yAxis = y;
            }

            public void plot()
            {
                Console.WriteLine($"Plot shows x-Axis: {xAxis} and y-Axis: {yAxis}");
            }
        }

        // Value Type:
        //  Can be assigned a value directly.  They are stored in the stack.  They are derived from the class System.ValueType
        // Reference Type:
        //  Refers to a memory location.  Using multiple variables, the reference types can refer to a memory location.  If the data
        //  in the memory location is changed by one of the variables, the other variables automatically reflects this change in value.
        static void Main(string[] args)
        {
            // Class (inherits from interface)
            Car delorian = new Car("Delorian", 4, "DMC 12 V6");
            delorian.pressGas();
            delorian.pressBrakes();
            delorian.honkHorn();

            // Struct
            Coordinate point = new Coordinate(15, 25);
            point.plot();

            // Create a second car from the first object
            // Compare the engines, then change the engine on the first object and compare again
            Car delorian2 = delorian;

            Console.WriteLine($"Delorian engine is: {delorian.engineSize}");
            Console.WriteLine($"Delorian2 engine is: {delorian2.engineSize}");

            delorian.engineSize = "Chevy V8";

            Console.WriteLine($"Delorian engine is: {delorian.engineSize}");
            Console.WriteLine($"Delorian2 engine is: {delorian2.engineSize}");

            // Create a second point from the first
            // Compare the two points, then change the x-Axis on the first point and compare again
            Coordinate point2 = point;

            Console.WriteLine($"Point x-Axis is: {point.xAxis}");
            Console.WriteLine($"Point2 x-Axis is: {point2.xAxis}");

            point.xAxis = 30;

            Console.WriteLine($"Point x-Axis is: {point.xAxis}");
            Console.WriteLine($"Point2 x-Axis is: {point2.xAxis}");

        }
    }
}
