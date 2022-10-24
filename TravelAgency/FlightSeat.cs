using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    internal class FlightSeat : IEquatable<FlightSeat>, IFlightSeat
    {
        public string PassengerPassport { get; }
        public int SeatNumber { get; set; }
        public string SeatClass = "Econom";
        //Generate Seat Number for Passenger
        private readonly Random random = new Random();
        //Constructor
        public FlightSeat(string passengerPassport)
        {
            this.PassengerPassport = passengerPassport;
        }

        //Method to Generate Seat number
        public void GenerateSeat()
        {
            this.SeatNumber = random.Next(0, 200);
        }
        //Method to display information about seat
        public override string ToString()
        {
            return " --- Seat Number: " + SeatNumber + ",  Seat Class: " + SeatClass;
        }
        //Method to Get Seat Class from Interface IFlightSeat
        public string GetSeatClass()
        {
            return SeatClass;
        }
        public void SetSeatClass(string seatClass)
        {
            this.SeatClass = seatClass;
        }


        //Equal method Comparison 
        public bool Equals(FlightSeat other)
        {
            if (other == null) return false;
            return (this.PassengerPassport.Equals(other.PassengerPassport));
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            FlightSeat objAsFlightSeat = obj as FlightSeat;
            if (objAsFlightSeat == null) return false;
            else return Equals(objAsFlightSeat);
        }
    }
}
