using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    internal class TravelAgency
    {
        private static TravelAgency instance; // singleton instance variable
        private List<TravelGroup> travelGroupList { get; set; } // variable to store TravelGroup variables
        //private Queue<AirplaneFlight> airplaneFlightQueue { get; set; } // variable to store AirplaneFlight variables
        AirplaneFlight airplaneFlights { get; set; }

        private TravelAgency() // constructor
        {
            travelGroupList = new List<TravelGroup>(); // initialize a List to store TravelGroup variables
            airplaneFlights = AirplaneFlight.GetInstance();
        }

        public static TravelAgency GetInstance()
        {
            instance = new TravelAgency();
            return instance;
        }



        // method to create a TravelGroup
        public static TravelGroup CreateTravelGroup()
        {
            //Retrieves data from user input and creates TravelGroup Instance.
            Console.Write("Enter Travel Group ID: ");
            int groupID = int.Parse(Console.ReadLine());
            Console.Write("Enter Travel Group Name: ");
            string groupName = Console.ReadLine();
            Console.Write("Enter Travel Group Destination: ");
            string groupDestination = Console.ReadLine();
            TravelGroup group = new TravelGroup(groupID, groupName, groupDestination);
            return group;
        }

        // method to create a AirplaneFlight. Will use Queue DS to store flights
        static void CreateAirplaneFlight(int travelGroupID)
        {
            Console.Write("Enter Airplane Flight Number: ");
            string flightNo = Console.ReadLine();
            Flight flight = new Flight(flightNo, travelGroupID);
            AirplaneFlight.FlightManager(flight); //Will check status and add to the Queue if Ok


        }


        // Note that TravelGroup/AirplaneFlight need to implement IEquatable interface to compare GroupID/FlightID only
        // Examples are in my dummy TravelGroup/AirplaneFlight file. This comment can be deleted after implementing IEquatable interface
        public bool AddTravelGroup(TravelGroup group)
        {
            if (travelGroupList.Contains(group)) return false;
            travelGroupList.Add(group);
            CreateAirplaneFlight(group.GroupID);

            return true;
        }

        public bool RemoveTravelGroup(int groupID)
        {
            TravelGroup travelGroupToRemove = FindTravelGroup(groupID);
            if (travelGroupToRemove == null) return false;
            travelGroupList.Remove(travelGroupToRemove);
            //Search for flight by groupID and remove from Queue if found
            AirplaneFlight.RemoveFromQueue(AirplaneFlight.FindFlight(groupID));
            return true;
        }

        public TravelGroup FindTravelGroup(int groupID)
        {
            //Finding travel group by ID
            TravelGroup travelGroup = travelGroupList.Find(x => x.GroupID == groupID);

            return travelGroup;
        }

        // ************************* FUNCTION TO BE IMPLEMENTED LATER ************************* 
        //public bool ModifyTravelGroup(TravelGroup group)
        //{
        //    if (!travelGroupList.Contains(group)) return false;
        //    TravelGroup previous = new TravelGroup();
        //    previous.GroupID = group.GroupID;
        //    travelGroupList.Remove(previous);
        //    travelGroupList.Add(group);
        //    return true;
        //}

        public void DisplayTravelGroups()
        {
            DisplayAirplaneFlights();
            foreach (TravelGroup group in travelGroupList)
            {
                group.DisplayTravelGroup();
            }
        }

        // Not sure if we still handle AirplaneFlight method in TravelAgency class
        // If not, feel free to move below methods to correct class
        // Need extra testing on the order of the queue for remove/modify method

        //TODO REMOVE 
        //public void AddAirplaneFlight(AirplaneFlight flight)
        //{
        //    if (airplaneFlights.Contains(flight)) return false;
        //    airplaneFlightQueue.Enqueue(flight);
        //    return true;
        //}

        //TODO REMOVE

        //public bool RemoveAirplaneFlight(int id)
        //{
        //    AirplaneFlight target = new AirplaneFlight();
        //    target.FlightID = id;
        //    if (!airplaneFlightQueue.Contains(target)) return false;
        //    Queue<AirplaneFlight> holder = new Queue<AirplaneFlight>(); // variable to hold AirplaneFlight objects to keep the correct order
        //    AirplaneFlight item = airplaneFlightQueue.Dequeue();
        //    while (!item.Equals(target)) // loop exit when flight item equals target, which is already removed from the queue
        //    {
        //        holder.Enqueue(item);
        //        item = airplaneFlightQueue.Dequeue();
        //    }
        //    while (holder.Count > 0) // insert rest of AirplaneFlight objects to keep the correct order
        //    {
        //        airplaneFlightQueue.Enqueue(holder.Dequeue());
        //    }
        //    return true;
        //}


        //TODO REMOVE
        //public bool ModifyAirplaneFlight(AirplaneFlight flight)
        //{
        //    if (!airplaneFlightQueue.Contains(flight)) return false;
        //    AirplaneFlight target = new AirplaneFlight();
        //    target.FlightID = flight.FlightID;
        //    Queue<AirplaneFlight> holder = new Queue<AirplaneFlight>(); // variable to hold AirplaneFlight objects to keep the correct order
        //    AirplaneFlight item = airplaneFlightQueue.Dequeue();
        //    while (!item.Equals(target)) // loop exit when flight item equals target, which is already removed from the queue
        //    {
        //        holder.Enqueue(item);
        //        item = airplaneFlightQueue.Dequeue();
        //    }
        //    airplaneFlightQueue.Enqueue(flight); // insert updated flight
        //    while (holder.Count > 0) // insert rest of AirplaneFlight objects to keep the correct order
        //    {
        //        airplaneFlightQueue.Enqueue(holder.Dequeue());
        //    }
        //    return true;
        //}

        public void DisplayAirplaneFlights()
        {
            foreach (Flight flight in AirplaneFlight.GetFlightQueue())
            {
                Console.WriteLine(flight.ToString());
            }

        }
    }
}

