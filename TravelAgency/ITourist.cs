using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    internal interface ITourist
    {

        int Age { get; set; }
        string Name { get; set; }
        string Email { get; set; }
        string PassportNumber { get; set; }

        public void CreateLuggage();
        public Luggage GetLuggage();
        string GetPassportNumber();
        


    }
}
