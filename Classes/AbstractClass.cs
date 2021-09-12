using System;
using System.Collections.Generic;
using System.Text;

namespace BasicsOfCSharp.Classes
{
    public interface IBase
    {
        void Learning();
        void Progress();
        void Agenda();
    }
    public abstract class AbstractClass : IBase
    {
        // Internal class field, cannot declare a field as abstract type
        public string progressStatus;

        // Non-abstract method
        public void Learning()
        {
            Console.WriteLine("Learning Abstract Class");
        }

        // Abstract Method
        public abstract void Progress();

        // Implementing inheriting interface method as `virtual`
        public virtual void Agenda()
        {
            Console.WriteLine("Understanding and implementing abstract class");
        }
    }

    public abstract class AnotherAbstractClass : AbstractClass
    {
        // Instance Constructor 
        public AnotherAbstractClass()
        {
            base.progressStatus = "Started";
        }

        // Hide base class concrete method with new abstract keyword
        public new abstract void Learning();
        public override void Progress()
        {
            Console.WriteLine(progressStatus);
        }

        // Instead of implementing the base class abstract method, overriding it to abstract
        public abstract override void Agenda();
    }

    public class BeginnerConcreteClass : AnotherAbstractClass
    {
        public BeginnerConcreteClass()
        {
            base.progressStatus = "50% Completed";
        }
        public override void Learning()
        {
            Console.WriteLine("Learning Abstract Class - Beginner");
        }
        public override sealed void Agenda()
        {
            Console.WriteLine("Implementing features of abstract class from beginner to expert level \n\n");
        }
    }

    // Deriving a concrete class to an abstract class
    public abstract class AbstractClassDerivedFromConcreteClass : BeginnerConcreteClass
    {
        // Abstract property
        public abstract string studentName { get; }
        // Abstract indexer
        public abstract int this[int index] { get; set; }
        // Abstract Event
        public abstract event FullName fullName;
    }

    public class IntermediateConcreteClass : BeginnerConcreteClass
    {
        public IntermediateConcreteClass() : base()
        {
            base.progressStatus = "75% Completed";
        }
        public override void Learning()
        {
            Console.WriteLine("Learning Abstract Class - Intermediate");
        }

        public override void Progress()
        {
            base.Progress();
        }
    }

    // Delegate
    public delegate string FullName();
    public class ExpertConcreteClass : AbstractClassDerivedFromConcreteClass
    {
        private string _firstName;
        private string _lastName;
        
        public ExpertConcreteClass(string firstName, string lastName)
        {
            this._firstName = firstName;
            this._lastName = lastName;
            base.progressStatus = "100% Completed";
        }

        public override int this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override string studentName { 
            get
            {
                FullName name = GetFullName;
                return name();
            }
        }

        public override event FullName fullName;

        public override sealed void Learning()
        {
            Console.WriteLine("Learning Abstract Class - Expert");
        }

        public override void Progress()
        {
            base.Progress();
            Console.WriteLine("Course completed by {0}", this.studentName);
        }

        public string GetFullName()
        {
            return this._firstName + " " + this._lastName;
        }
    }
}
