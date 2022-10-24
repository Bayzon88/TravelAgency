using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    internal class AirplaneFlight
    {
       static Queue<Flight> flightsQueue = new Queue<Flight>();
        Flight flight = new Flight();
        private static AirplaneFlight instance; // singleton instance variable
        public static AirplaneFlight GetInstance()
        {
            instance = new AirplaneFlight();
            return instance;
        }


        public int FlightID { get; set; }

        public bool Equals(AirplaneFlight other) // used for AddAirplaneFlight/RemoveAirplaneFlight/ModifyAirplaneFlight
        {
            if (other == null) return false;
            return (this.FlightID == other.FlightID);
        }

        public override bool Equals(Object obj)
        {
            if (obj == null) return false;
            AirplaneFlight objAsTest = obj as AirplaneFlight;
            if (objAsTest == null) return false;
            else return Equals(objAsTest);
        }

        // method to display current aireplane flight information
        public override string ToString() // please complete it... 
        {
            // or use String.Format
            // return String.Format("Airplane Flight ID: {0} {1} {2}", FlightID, v2, v3);
            return "Airplane Flight ID: " + FlightID;
        }
        public static bool AddToQueue(Flight f)
        {
            if (FindFlight(f.TravelGroupID) == null)
            {
                flightsQueue.Enqueue(f);
                return true;
            }
            return false;

        }

        //Find Flight
        public static Flight FindFlight(int travelGroupID )
        {
            Flight f = null;

            foreach (var item in flightsQueue)
            {
                if (item.TravelGroupID == travelGroupID)
                {
                    f = item;
                    break;
                }
            }
            return f;
        }

        //Remove flights to the queue
        public static bool RemoveFromQueue(Flight f)
        {
            if (FindFlight(f.TravelGroupID) != null)
            {
                flightsQueue = new Queue<Flight>(
                    flightsQueue.Where(x => x.FlightNo != f.FlightNo));
                return true;
            }
            return false;
        }

        //Flight management
        public static void FlightManager(Flight f)
        {
            if (f.CheckFlightStatus())
            {
                AddToQueue(f);
                Console.WriteLine("Flight number " + f.FlightNo + " is added to the Queue.");
            }
            else
            {
               Console.WriteLine("Flight number cannot be added to the Queue");
            }
        }

        //Display all flights (just for test)        
        public static Queue<Flight> GetFlightQueue()
        {
            return flightsQueue;
        }

    }
}

