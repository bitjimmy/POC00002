using StandardLibrary01;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var size = 0.0;
            // D - Dependency Inversion Principle -Depend on abstractions, not on concretions.
            // LSP - Lickov Subsitution Principle - Any dervied class is able to subsitute to base class without breaking it.
            // https://www.youtube.com/watch?v=-3UXq2krhyw
            ISolidPrinciple2 sharp_generic;
            ISolidPrinciple2 sharp_reference;
            ISolidPrinciple2 sharp_copy; // https://docs.microsoft.com/en-us/dotnet/api/system.object?view=netframework-4.7.2

            //SolidPrinciple2 sharp_generic;
            //SolidPrinciple2 sharp_reference;
            //ISolidPrinciple2 sharp_copy; // https://docs.microsoft.com/en-us/dotnet/api/system.object?view=netframework-4.7.2

            sharp_generic = new Sqaure(2);
            size = sharp_generic.Size();
            Console.WriteLine(sharp_generic.Id);
            Console.WriteLine(sharp_generic.SharpName);
            Console.WriteLine(sharp_generic.ToString());
            Console.WriteLine(sharp_generic);
            Console.WriteLine(size);
            Console.WriteLine((sharp_generic as Sqaure).SpecialSqaure());
            Console.WriteLine(((Sqaure)sharp_generic).SpecialSqaure());
            sharp_copy = (Sqaure)sharp_generic.Copy();  // Make another SolidPrinciple2 object that is a copy of the first.
            sharp_reference = sharp_generic; // Make another variable that references the first SolidPrinciple2 object.
            if (sharp_generic is Sqaure) Console.WriteLine("It is a Sqaure");
            if (sharp_copy is Sqaure) Console.WriteLine("It is a Copy Sqaure");
            if (sharp_reference is Sqaure) Console.WriteLine("It is a Reference Sqaure");
            Console.WriteLine(object.ReferenceEquals(sharp_generic, sharp_copy)); // The line below displays false because p1 and p2 refer to two different objects.
            Console.WriteLine(object.Equals(sharp_generic, sharp_copy)); // The line below displays true because p1 and p2 refer to two different objects that have the same value.
            Console.WriteLine(object.ReferenceEquals(sharp_generic, sharp_reference)); // The line below displays true because p1 and p3 refer to one object.


            sharp_generic = new Rectangle(2,3);
            size = sharp_generic.Size();
            Console.WriteLine(sharp_generic.Id);
            Console.WriteLine(sharp_generic.SharpName);
            Console.WriteLine(sharp_generic.ToString());
            Console.WriteLine(sharp_generic);
            Console.WriteLine(size);
            sharp_copy = (Rectangle)sharp_generic.Copy();
            sharp_reference = sharp_generic;
            if (sharp_generic is Rectangle) Console.WriteLine("It is a Retangle");
            if (sharp_copy is Rectangle) Console.WriteLine("It is a Copy Retangle");
            if (sharp_reference is Rectangle) Console.WriteLine("It is a Reference Retangle");
            Console.WriteLine(object.ReferenceEquals(sharp_generic, sharp_copy)); // The line below displays false because p1 and p2 refer to two different objects.
            Console.WriteLine(object.Equals(sharp_generic, sharp_copy)); // The line below displays true because p1 and p2 refer to two different objects that have the same value.
            Console.WriteLine(object.ReferenceEquals(sharp_generic, sharp_reference)); // The line below displays true because p1 and p3 refer to one object.


            sharp_generic = new Cube(2, 3, 4);
            size = sharp_generic.Size();
            Console.WriteLine(sharp_generic.Id);
            Console.WriteLine(sharp_generic.SharpName);
            Console.WriteLine(sharp_generic.ToString());
            Console.WriteLine(sharp_generic);
            Console.WriteLine(size);
            sharp_copy = (Cube)sharp_generic.Copy();
            sharp_reference = sharp_generic;
            if (sharp_generic is Cube) Console.WriteLine("It is a Cube");
            if (sharp_copy is Cube) Console.WriteLine("It is a Copy Cube");
            if (sharp_reference is Cube) Console.WriteLine("It is a Reference Cube");

            sharp_generic = new Circle(6);
            size = sharp_generic.Size();
            Console.WriteLine(sharp_generic.Id);
            Console.WriteLine(sharp_generic.SharpName);
            Console.WriteLine(sharp_generic.ToString());
            Console.WriteLine(sharp_generic);
            Console.WriteLine(size);
            sharp_copy = (Circle)sharp_generic.Copy();
            sharp_reference = sharp_generic;
            if (sharp_generic is Circle) Console.WriteLine("It is a Circle");
            if (sharp_copy is Circle) Console.WriteLine("It is a Copy Circle");
            if (sharp_reference is Circle) Console.WriteLine("It is a Reference Circle");

            Console.ReadLine();

        }
    }
}
