using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    internal class Luggage
    {
        Stack<string> clothes = new Stack<string>();
        public Luggage()
        {

        }

        public void AddClothesToLuggage()
        {
            Console.Write("How many pieces of clothing would you like to add? :");
            int piecesOfClothing = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < piecesOfClothing; i++)
            {
                Console.Write("Enter clothe's name : ");
                clothes.Push(Console.ReadLine());
            }
        }

        public Stack<string> GetStackOfClothes()
        {
            return clothes;
        }

        public int TotalClothesCount()
        {
            return clothes.Count;
        }

        public void RemoveTopItem()
        {
            clothes.Pop();
        }

        public void PrintAllClothes()
        {
            foreach (string item in clothes)
            {
                Console.WriteLine(item);
            }
        }
    }
}
