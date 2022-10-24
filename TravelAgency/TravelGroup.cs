using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    internal class TravelGroup
    {
        // Key string is a Passport number , and value is a Tourist object
        private Dictionary<string, ITourist> group = new Dictionary<string, ITourist>();
        // Linked List for Flight Seats
        public LinkedList<FlightSeat> seats = new LinkedList<FlightSeat>();

        public int GroupID { get; set; }
        public string GroupName;
        public string GroupDestination;

        public TravelGroup(int GroupID, string GroupName, string GroupDestination)
        {
            this.GroupID = GroupID;
            this.GroupName = GroupName;
            this.GroupDestination = GroupDestination;
        }
        public bool Equals(TravelGroup other) // used for AddTravelGroup/RemoveTravelGroup/ModifyTravelGroup
        {
            if (other == null) return false;
            return (this.GroupID == other.GroupID);
        }

        public override bool Equals(Object obj)
        {
            if (obj == null) return false;
            TravelGroup objAsTest = obj as TravelGroup;
            if (objAsTest == null) return false;
            else return Equals(objAsTest);
        }

        //Methods for the submenu. 
        public void AddTouristToGroup(ITourist tourist)
        {
            string passportNumber = tourist.GetPassportNumber();
            if (group.ContainsKey(passportNumber))
                Console.WriteLine("Tourist with that passport number is already in the group! Try Again.");
            //Otherwise Add to Travel Group's Dictionary
            group.Add(passportNumber, tourist);
            // Call method to Creaate and add seat to the flight seats
            AddSeatToList(passportNumber);

        }

        public void RemoveTouristFromGroup(string passportNumber)
        {
            if (!group.ContainsKey(passportNumber))
                Console.WriteLine("Tourist with that passport was not found in the group.");
            // Remove from Travel Group Dictionary
            group.Remove(passportNumber);
            RemoveSeatFromList(passportNumber);
        }

        private void AddSeatToList(string passportNumber)
        {
            // Firstly, creating fly seat object
            FlightSeat flightSeat = new FlightSeat(passportNumber);
            // Generate number for flight seat
            flightSeat.GenerateSeat();
            // Adding to the List
            seats.AddFirst(flightSeat);
        }

        private void RemoveSeatFromList(string passportNumber)
        {
            // Creating new fly seat(target) object with desired Passport Number
            FlightSeat target = new FlightSeat(passportNumber);
            // Trying to find target in the Linked List
            LinkedListNode<FlightSeat> flightSeat = seats.Find(target);
            if (flightSeat == null)
                Console.WriteLine("Seat for that passenger not found.");
            //Otherwise Remove from the List
            seats.Remove(flightSeat);
        }

        public void ModifyTouristInformation(string passportNumber)
        {
            if (!group.ContainsKey(passportNumber))
            {
                Console.WriteLine("Tourist's Passport Number not found");
            }
            else
            {
                //Check for name update
                Console.Write("Would you like to update Name? (y/n)");
                string updateName = Console.ReadLine();
                if (updateName.ToLower().Equals("y"))
                {
                    Console.Write("Enter New Name : ");
                    string newName = Console.ReadLine();
                    group[passportNumber].Name = newName;
                }
                //Check for age update
                Console.Write("Would you like to update age? (y/n)");
                string updateAge = Console.ReadLine();
                if (updateAge.ToLower().Equals("y"))
                {
                    Console.Write("Enter New Age : ");
                    int newAge = Convert.ToInt32(Console.ReadLine());
                    group[passportNumber].Age = newAge;
                }

                //Check for name update
                Console.Write("Would you like to update Email? (y/n)");
                string updateEmail = Console.ReadLine();
                if (updateEmail.ToLower().Equals("y"))
                {
                    Console.Write("Enter New Email : ");
                    string newEmail = Console.ReadLine();
                    group[passportNumber].Email = newEmail;
                }
                //Check for seat update
                Console.Write("Would you like to update Seat Class? (y/n)");
                string updateSeat = Console.ReadLine();
                if (updateSeat.ToLower().Equals("y"))
                {
                    //Find seat related to this Tourist (by Passport No)
                    FlightSeat target = new FlightSeat(passportNumber);
                    // Trying to find target in the Linked List
                    LinkedListNode<FlightSeat> flightSeatNode = seats.Find(target);
                    if (flightSeatNode == null)
                        Console.WriteLine("Seat for that passenger not found.");
                    //Otherwise update seat
                    else
                    {
                        //Retrieving FlightSeat object from the found Node
                        IFlightSeat fly = flightSeatNode.Value;
                        //What type of decorator to use
                        Console.Write("Enter New Seat Class (Econom/Comfort/Bussiness): ");
                        string seatInput = Console.ReadLine();
                        if (seatInput.ToLower().Equals("comfort"))
                        {
                            fly = new ComfortSeat(fly); //Using ComfortSeat Decorator
                            string newSeat = fly.GetSeatClass();
                            fly.SetSeatClass(newSeat);

                        }
                        else if(seatInput.ToLower().Equals("bussiness"))
                        {
                            fly = new BussinessSeat(fly); //Using BussinessSeat Decorator
                            string newSeat = fly.GetSeatClass();
                            fly.SetSeatClass(newSeat);
                        }
                        else
                        {
                            fly = new EconomSeat(fly); //Using BussinessSeat Decorator
                            string newSeat = fly.GetSeatClass();
                            fly.SetSeatClass(newSeat);
                        }
                    }
                  
                }
            }
        }
        public void DisplayTravelGroup()
        {
            Console.WriteLine("\n-----------------------------------------------------------------");
            Console.WriteLine("Group ID: " + GroupID + ", Name of Group: " + GroupName + ", Destination: "
                + GroupDestination);
            Console.WriteLine("-----------------------------------------------------------------");
            foreach (KeyValuePair<string, ITourist> pair in group)
            {
                // pair.Value is a ITourist object that implement ToString()
                Console.Write(pair.Value.ToString());

                //Find Seat for that particular Tourist
                FlightSeat target = new FlightSeat(pair.Key);
                // Trying to find target in the Linked List
                LinkedListNode<FlightSeat> flightSeatNode = seats.Find(target);

                if (flightSeatNode == null)
                    Console.WriteLine("Seat for that passenger not found.");
                //Otherwise Display Tourist Info
                else
                {
                    Console.WriteLine(flightSeatNode.Value.ToString());
                }
            }

        }
    }
}

