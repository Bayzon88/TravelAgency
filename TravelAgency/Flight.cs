using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    internal class Flight
    {
   
        public string FlightNo { get; set; }
        public int TravelGroupID { get; set; }
        

        //Constructors
        public Flight()
        {

        }
        public Flight(string flightNo, int travelGroupID)
        {
            this.TravelGroupID = travelGroupID;
            this.FlightNo = flightNo;
        }

        //Methods
        public bool CheckFlightStatus()
        {
            //Using Facade Desgin Pattern
            if (Tire.GetTirePressure() && 
                Engine.CheckEngineStatus() &&
                Fuel.CheckFuelStatus())
            {
                Console.WriteLine("Flight is ready.");
                return true;
            }

            else
            {
                Console.WriteLine("Sorry, flight is delayed.");
                return false;
            }
        }

        public override string ToString()
        {
            return "Flight Number : " + FlightNo + " - Group ID : " + TravelGroupID;
        }

    }
}
