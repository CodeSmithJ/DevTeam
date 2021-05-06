using DevTeams_Challenge_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeams_Challenge_Console
{
    public class ProgramUI
    {
        //This class will be how we interact with our user through the console. When we need to access our data, we will call methods from our Repo class.

        private DevTeamsRepo _repo = new DevTeamsRepo();

        public void Run()
        {
            SeedContentList();
            Menu();
        }


        private void Menu()
        {
            //Start with the main menu here

            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select a menu option:\n" +
                    "1. Create New Member\n" +
                    "2. View All Members\n" +
                    "3. View Member By First Name\n" +
                    "4. Update Existing Member\n" +
                    "5. Delete Existing Member\n" +
                    "6. Exit");

                string input = Console.ReadLine();

                switch (input.ToLower())
                {
                    case "1":
                    case "one":
                        //CreateNewMember
                        CreateNewMember();
                        break;
                    case "2":
                    case "two":
                        //ViewAllMembers
                        DisplayAllMembers();
                        break;
                    case "3":
                    case "three":
                        //View Member By First Name
                        DisplayMemberByFirstName();
                        break;
                    case "4":
                    case "four":
                        //Update Existing Member
                        UpdateExistingDeveloper();
                        break;
                    case "5":
                    case "five":
                        //Delete Existing Member
                        DeleteExistingDeveloper();
                        break;
                    case "6":
                    case "six":
                        //Exit
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;
                }

                Console.WriteLine("Please press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }

        }
        private void CreateNewMember() // optional challenge - ask the user to confirm information before adding to directory
        {
            Console.Clear();
            Developer newDeveloper = new Developer();

            // ID Number
            Console.WriteLine("What is the developers ID number?");
            newDeveloper.ID = Convert.ToInt32(Console.ReadLine());

            //First Name
            Console.WriteLine("What is the first name of this member?");
            newDeveloper.FirstName = Console.ReadLine();

            //Last Name
            Console.WriteLine("What is the last name of the member");
            newDeveloper.LastName = Console.ReadLine();

            //Team Assignment
            Console.WriteLine("Enter the Team Assignment for this member:\n" +
                "1. FrontEnd\n" +
                "2. BackEnd\n" +
                "3. Tester\n");

            newDeveloper.TeamAssingment = (TeamAssignment)Convert.ToInt32(Console.ReadLine());
            bool wasAddedCorrectly = _repo.AddDeveloperToDirectory(newDeveloper);
            if (wasAddedCorrectly)
            {
                Console.WriteLine("The member was added correctly!");
            }
            else
            {
                Console.WriteLine("Could not add the member.");
            }
        }
        private void DisplayAllMembers() // Display All Members in the Directory
        {
            Console.Clear();
            List<Developer> allMembers = _repo.GetMembers();
            foreach (Developer member in allMembers)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Full Name: {member.FirstName} {member.LastName}\n" +
                    $"Has access to Pluralsight: {member.TeamAssingment}");
                Console.ResetColor();
            }
        }

        private void DisplayMemberByFirstName() // Display Member By First Name get name
        {
            Console.Clear();
            DisplayAllMembers();

            Console.WriteLine($"Enter the first name for the developer.");
            Developer memberToDisplay = _repo.GetDeveloperByFirstName(Console.ReadLine());

            if (memberToDisplay != null)
            {
                Console.WriteLine($"ID: {memberToDisplay.ID}\n" +
                    $"First Name: {memberToDisplay.FirstName}\n" +
                    $"Last Name: {memberToDisplay.LastName}\n" +
                    $"Team Assingment: {memberToDisplay.TeamAssingment}");
            }
            else
            {
                Console.WriteLine("There is no developers with that name.");
            }
        }

        private void UpdateExistingDeveloper()
        {
            Console.Clear();
            DisplayAllMembers();
            Developer newDeveloper = new Developer();
            Console.WriteLine("Enter the first name of the developer you would like to update");
            string oldDeveloper = Console.ReadLine();

            // ID Number
            Console.WriteLine("What is the developers ID number?");
            newDeveloper.ID = Convert.ToInt32(Console.ReadLine());

            //First Name
            Console.WriteLine("What is the first name of this member?");
            newDeveloper.FirstName = Console.ReadLine();

            //Last Name
            Console.WriteLine("What is the last name of the member");
            newDeveloper.LastName = Console.ReadLine();

            //Team Assignment
            Console.WriteLine("Enter the Team Assignment for this member:\n" +
                "1. FrontEnd\n" +
                "2. BackEnd\n" +
                "3. Tester\n");

            newDeveloper.TeamAssingment = (TeamAssignment)Convert.ToInt32(Console.ReadLine());
            bool wasUpdatedCorrectly = _repo.UpdateExistingDeveloper(oldDeveloper, newDeveloper);
            if (wasUpdatedCorrectly)
            {
                Console.WriteLine("The member was added correctly!");
            }
            else
            {
                Console.WriteLine("Could not add the member.");
            }
        }


        private void DeleteExistingDeveloper()
        {
            Console.Clear();
            DisplayAllMembers();

            Console.WriteLine("Enter the first name for the member you want to delete.");

            bool wasDeleted = _repo.DeleteExistingDeveloper(Console.ReadLine());

            if (wasDeleted)
            {
                Console.WriteLine("Your member was successfully deleted!");
            }
            else
            {
                Console.WriteLine("Member could not be deleted.");
            }
        }

        private void SeedContentList()
        {
            Developer front = new Developer(007, "James", "Bond", TeamAssignment.FrontEnd);
            Developer back = new Developer(001, "Max", "Payne", TeamAssignment.BackEnd);
            Developer test = new Developer(003, "Jason", "Born", TeamAssignment.Testing);

            _repo.AddDeveloperToDirectory(front);
            _repo.AddDeveloperToDirectory(back);
            _repo.AddDeveloperToDirectory(test);
        }
    }
}
