using System;
namespace FinalProject
{
    //Base Class for Decorators
	public class Decorator : IFlightSeat
	{
        // Protected --> only subclasses of Decorator Class have access
        protected IFlightSeat seat;
        //Constructor
        protected Decorator(IFlightSeat seat)
		{
            this.seat = seat;
		}
        //Method from IFlightSeat interface
        public virtual string GetSeatClass()
        {
            return seat.GetSeatClass();
        }

        public virtual void SetSeatClass(string seatClass)
        {
            seat.SetSeatClass(seatClass);
        }
    }

    //**************************************************************************
    public class ComfortSeat : Decorator
    {
        public ComfortSeat(IFlightSeat seat) : base(seat){}

        //When call for this decorator's method that will return new seat class
        public override string GetSeatClass()
        {
            string seat_class =  base.GetSeatClass();
            seat_class += " --> Comfort Seat";
            return seat_class;
        }
        public override void SetSeatClass(string seat_class)
        {
            base.SetSeatClass(seat_class);
            Console.WriteLine("Seat Updated Successfully");
        }
    }

    //**************************************************************************
    public class BussinessSeat : Decorator
    {
        public BussinessSeat(IFlightSeat seat) : base(seat) { }

        //When call for this decorator's method that will return new seat class
        public override string GetSeatClass()
        {
            string seat_class = base.GetSeatClass();
            seat_class += " --> Bussiness Seat";
            return seat_class;
        }
        public override void SetSeatClass(string seat_class)
        {
            base.SetSeatClass(seat_class);
            Console.WriteLine("Seat Updated Successfully");
        }
    }

    //**************************************************************************
    public class EconomSeat : Decorator
    {
        public EconomSeat(IFlightSeat seat) : base(seat) { }

        //When call for this decorator's method that will return new seat class
        public override string GetSeatClass()
        {
            string seat_class = base.GetSeatClass();
            seat_class += " --> Econom Seat";
            return seat_class;
        }
        public override void SetSeatClass(string seat_class)
        {
            base.SetSeatClass(seat_class);
            Console.WriteLine("Seat Updated Successfully");
        }
    }


}

