using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    internal class Tester
    {
        static void Main(string[] args)
        {
            TravelAgency travelAgency = TravelAgency.GetInstance(); // create only one TravelAgency variable

            int mainChoice; // Choice for Main Menu
            int subChoice; // Choice for Sub Menu

            Console.WriteLine("\nWelcome to ACE Travel Agency");
            do
            {
                Console.WriteLine("\n------Main Menu-----");
                Console.WriteLine("1. Add new Travel Group");
                Console.WriteLine("2. Remove Travel Group");
                Console.WriteLine("3. Modify Travel Group");
                Console.WriteLine("4. Display all Travel Groups");
                Console.WriteLine("Press 0 to quit\n");
                Console.Write("Enter your choice:  ");
                mainChoice = Int32.Parse(Console.ReadLine());
                if (mainChoice == 1)
                {
                    // Add new Travel Group
                    TravelGroup group = TravelAgency.CreateTravelGroup();
                    if (travelAgency.AddTravelGroup(group))
                    {
                        Console.WriteLine(String.Format("Travel Group {0} was successfully added!", group.GroupID));
                        group.DisplayTravelGroup();
                    }
                    else
                    {
                        Console.WriteLine(String.Format("Failed to add! Travel Group {0} already exists!", group.GroupID));
                    }
                }
                else if (mainChoice == 2)
                {
                    // Remove Travel Group
                    Console.Write("Enter Travel Group ID you want to remove: ");
                    int groupID = int.Parse(Console.ReadLine());
                    if (travelAgency.RemoveTravelGroup(groupID))
                    {
                        Console.WriteLine(String.Format("Travel Group {0} is successfully removed!", groupID));
                    }
                    else
                    {
                        Console.WriteLine(String.Format("Failed to remove! Travel Group {0} does not exist!", groupID));
                    }
                }
                else if (mainChoice == 3)
                {
                    // Modify Travel Group
                    Console.Write("Enter Travel Group ID you want to modify: ");
                    int groupID = int.Parse(Console.ReadLine());
                    TravelGroup group = travelAgency.FindTravelGroup(groupID);
                    if (group == null)
                    {
                        Console.WriteLine(String.Format("Cannot find Travel Group {0}", groupID));
                    }
                    else
                    {
                        do
                        {
                            Console.WriteLine(String.Format("\n\n------This is Travel Group {0} Menu-----", groupID));
                            Console.WriteLine("1. Add Tourist to a group");
                            Console.WriteLine("2. Remove tourist from the group");
                            Console.WriteLine("3. Display Travel Group Information");
                            Console.WriteLine("4. Modify Tourist Information");
                            Console.WriteLine("Press 0 to go back Main Menu\n");
                            Console.Write("Enter your choice:  ");

                            subChoice = Int32.Parse(Console.ReadLine());

                            if (subChoice == 1)
                            {

                                Console.Write("Enter type of Tourist(disability/nondisability): ");
                                string typeOfTourist = Console.ReadLine();
                                //Creating a new Tourist from the Tourist Client class
                                ITourist touristToAddToGroup = TouristClient.CreateNewTourist(typeOfTourist);

                                // Add Tourist to a group
                                group.AddTouristToGroup(touristToAddToGroup);    

                            }
                            else if (subChoice == 2)
                            {
                                // Remove tourist from the group
                                Console.Write("Enter PassportNumber : ");
                                string passportNumber = Console.ReadLine();
                                group.RemoveTouristFromGroup(passportNumber);

                            }
                            else if (subChoice == 3)
                            {
                                // Display Travel Group Information
                                group.DisplayTravelGroup();
                            }
                            else if (subChoice == 4)
                            {
                                // Modify TravelGroup object only once here before return to the main menu
                                Console.Write("Enter PassportNumber : ");
                                string passportNumber = Console.ReadLine();
                                group.ModifyTouristInformation(passportNumber);

                            }
                            else
                            {
                                Console.WriteLine("Invalid Choice!!!");
                            }
                        }
                        while (subChoice != 0);
                    }
                }
                else if (mainChoice == 4)
                {
                    // Display all Travel Groups
                    travelAgency.DisplayTravelGroups();
                }
                else
                    Console.WriteLine("Invalid Choice!!!");
            }
            while (mainChoice != 0);
            Console.WriteLine("\nSession Ended\n");
        }




    }

}

