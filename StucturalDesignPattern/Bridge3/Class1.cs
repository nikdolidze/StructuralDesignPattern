using System;
/* 
 definition for it is that it's trying to separate  the implementation from the abstraction so those can vary independently.
 */
namespace Bridge3
{
    // top level abstraction
    public abstract class Vehicle
    {
        private Make Make;
        public void Start()
        {
            Make.PerformRitual();
            Make.StartCar();
        }
        public abstract bool AllowedToDrive(string person);
    }
    public abstract class Make
    {
        public abstract void PerformRitual();
        public abstract void StartCar();
    }
    // implementation
    public class Lada : Make
    {
        public override void PerformRitual() => Console.WriteLine("Hit the cer");
        public override void StartCar() => Console.WriteLine("Start a car");
        public class Volvo : Make
        {
            public override void PerformRitual() => Console.WriteLine();

            public override void StartCar() => Console.WriteLine();
        }

        // lower level abstraction
        //public class LCar : Lada 
        //{ }
        //public class LTruck : Lada 
        //{ }
        //public class VCar : Volvo 
        //{ }
        //public class VTruck : Volvo 
        //{ }

        // ---------------
        // try to re-arrange
        // ---------------

        // lower level abstraction
        public class Car : Vehicle
        {
            public override bool AllowedToDrive(string person) => person == "has licence";
        }
        public class Truck : Vehicle
        {
            public override bool AllowedToDrive(string person) => person == "has special truck licence";
        }

        // implementations
        //public class L2Car : Car 
        //{ }
        //public class L2Truck : Truck 
        //{ }
        //public class V2Car : Car 
        //{ }
        //public class V2Truck : Truck 
        //{ }

    }
}
