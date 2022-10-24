using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    internal class TouristClient 
    {
        //Factory
        public static ITourist CreateNewTourist(string typeOfTourist)
        {
            Console.Write("Enter Tourist Age : ");
            int age = Convert.ToInt16(Console.ReadLine());

            Console.Write("Enter Tourist Name : ");
            string name = Console.ReadLine();
            Console.Write("Enter Tourist Email : ");
            string email = Console.ReadLine();
            Console.Write("Enter Tourist Passport Number : ");
            string passportNumber = Console.ReadLine();

            //Based on the type of tourist, this method will return a Disability or Non Disability Tourist
            if (typeOfTourist == "NonDisability")
            {
                return new NonDisabilityTourist(age, name, email, passportNumber);
            }
            else
            {
                return new DisabilityTourist(age, name, email, passportNumber);
            }
        }

  

        

      
    }
}
