using BasicsOfCSharp.Classes;
using System;

namespace BasicsOfCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            BeginnerConcreteClass beginner = new BeginnerConcreteClass();
           
            beginner.Learning();
            beginner.Progress();
            beginner.Agenda();

            IntermediateConcreteClass intermediate = new IntermediateConcreteClass();
            
            intermediate.Learning();
            intermediate.Progress();
            intermediate.Agenda();

            ExpertConcreteClass expert = new ExpertConcreteClass("siva","kumar");
            expert.Learning();
            expert.Progress();

            Console.ReadLine();
        }
    }
}
