using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    internal class NonDisabilityTourist : ITourist
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PassportNumber { get; set; }
        Luggage luggage = null;

        public NonDisabilityTourist(int age, string name, string email, string passportNumber)
        {
            Age = age;
            Name = name;
            Email = email;
            PassportNumber = passportNumber;
            CreateLuggage();
        }

        public void CreateLuggage()
        {
            luggage = new Luggage();
            luggage.AddClothesToLuggage();

        }

        public Luggage GetLuggage()
        {
            return luggage;
        }

        public string GetPassportNumber()
        {
            return this.PassportNumber;
        }

        public override string ToString()
        {

            return String.Format("Name: {0} --- Age: {1} --- Email: {2} --- PassportNumber: {3}", Name, Age, Email, PassportNumber);
        }
    }
}
