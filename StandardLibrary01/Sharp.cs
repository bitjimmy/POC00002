using System;
using System.ComponentModel.DataAnnotations;

namespace StandardLibrary01
{
    // Interface Segregation
    // Breaking this monolithic interface into smaller interfaced based by role, we would get CanEat, CanSleep and CanWalk interfaces
    public interface IEat
    {
        bool CanEat();
    }
    public interface ISleep
    {
        bool CanSleep();
    }
    public interface IWalk
    {
        bool CanWalk();
    }
    public class Animal_A : IEat, ISleep, IWalk
    {
        public bool CanEat()
        {
            throw new NotImplementedException();
        }

        public bool CanSleep()
        {
            throw new NotImplementedException();
        }

        public bool CanWalk()
        {
            throw new NotImplementedException();
        }
    }

    // dependency inversion - this interface is an application of dependency injection, so it will not have concret subclass being
    // passed to the services
    public interface ISolidPrinciple2: IId
    {
        double Size();
        string SharpName { get; }
        object Copy();
    }

    // single responsibility principle - A class should have one, and only one, reason to change.
    // Open-close principle - You should be able to extend a classes behavior, without modifying it
    // Interface Segregation - Make fine grained interfaces that are client specific.
    // Dependency Inversion Principle -Depend on abstractions, not on concretions.
    public abstract class SolidPrinciple2 : ISolidPrinciple2 
    {
        // must implement sharp name
        public abstract string SharpName { get; }
        // Id of sharp
        public Guid Id => Guid.NewGuid();

        protected SolidPrinciple2() { }

        // virutal method to be overriden in child class;
        public virtual double Size()
        {
            return 0;
            //throw new NotImplementedException();
        }

        // local method with logic
        //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/how-to-override-the-tostring-method
        public override string ToString()
        {
            return $"{base.ToString()} - {SharpName}";
        }

        public object Copy()
        {
            return (object)this.MemberwiseClone();
        }
    }

    public class Sqaure : SolidPrinciple2, IHeight<int>
    {
        public Sqaure(int height) : base()
        {
            Height = height;

        }
        public override string SharpName => SharpType.Sqaure.GetEnumName();


        public int Height { get; set; }

        public override double Size()
        {
            return Height * Height;
        }

        // explicitly for squre class
        public string SpecialSqaure()
        {
            return "just for square only";
        }

        //https://docs.microsoft.com/en-us/dotnet/api/system.object?view=netframework-4.7.2
        public override bool Equals(object obj)
        {
            // If this and obj do not refer to the same type, then they are not equal.
            if (obj.GetType() != this.GetType()) return false;

            // Return true if  x and y fields match.
            var other = (Sqaure)obj;
            return (this.Height == other.Height);
        }
    }

    public class Rectangle : SolidPrinciple2, IHeight<int>, IWidth<int>
    {
        public Rectangle(int height, int width) : base()
        {
            Height = height;
            Width = width;
        }

        public override string SharpName => SharpType.Rectangle.GetEnumName();
        public int Height { get; set; }
        public int Width { get; set; }

        public override double Size()
        {
            return Height * Width;
        }

        public override bool Equals(object obj)
        {
            // If this and obj do not refer to the same type, then they are not equal.
            if (obj.GetType() != this.GetType()) return false;

            // Return true if  x and y fields match.
            var other = (Rectangle)obj;
            return (this.Height == other.Height) && (this.Width == other.Width);
        }
    }

    public class Cube : SolidPrinciple2, IHeight<int>, IWidth<int>, IDepth<int>
    {
        public Cube(int height, int width, int depth) : base()
        {
            Height = height;
            Width = width;
            Depth = depth;
        }
       
        public override string SharpName => SharpType.Cube.GetEnumName();

        public int Height { get; set; }
        public int Width { get; set; }
        public int Depth { get; set; }

        public override double Size()
        {
            return Height * Width * Depth;
        }
    }

    //Interface segregation principle
    //Clients should not be forced to implement interfaces they do not use.
    //it is better to have many smaller interfaces, than fewer, fatter interfaces
    public class Circle : SolidPrinciple2, IRadius<double>
    {
        public Circle(double radius) : base()
        {
            Radius = radius;
        }
        public override string SharpName => SharpType.Circle.GetEnumName();

        public double Radius { get; set; }

        public override double Size()
        {
            return 2 * Math.PI * Radius;
        }
    }


    public enum SharpType : short
    {
        [Display(Name = "Sqaure")]
        Sqaure = 1,
        [Display(Name = "Rectangle")]
        Rectangle,
        [Display(Name = "Cube")]
        Cube,
        [Display(Name = "Circle")]
        Circle,

    }

    // Interface segregation principle
    public interface IId
    {
       Guid Id { get; }
    }
    public interface IHeight<T>
    {
        T Height { get; set; }
    }
    public interface IWidth<T>
    {
        T Width { get; set; }
    }

    public interface IDepth<T>
    {
        T Depth { get; set; }
    }

    public interface IRadius<T>
    {
        T Radius { get; set; }
    }
}
