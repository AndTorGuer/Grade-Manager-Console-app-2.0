using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab2_Andres
{
    public class School
    {
        // Dictionary
        public static Dictionary<string, Classroom> classrooms = new Dictionary<string, Classroom>();

        // Everything here WORKS! DONT TOUCH IT!!

        public void MainMenu()
        {
            bool exit = true; //feature 08 - Exit
            do
            {
                Console.Clear();
                Console.WriteLine(@"Grade Manager 2.0
Select from the following options

Option 1: Add Classroom
Option 2: Show Classroom
Option 3: Remove Classroom
Option 4: Classroom Details
Option 5: Exit

Make selection:");
                string input = Console.ReadLine();

                int selection;
                try
                {
                    selection = int.Parse(input);
                }
                catch (Exception e) // catches the error and returns to main menu
                {
                    Console.WriteLine(e.Message); // Prints an error message of what went wrong       
                    continue;
                }

                switch (selection)
                {
                    case 1:
                        AddClassroom(); //feature 00 - Add classrooms
                        break;
                    case 2:
                        ShowClassrooms(); //feature 01 - Show classrooms
                        break;
                    case 3:
                        RemoveClassroom(); //feature 02 - remove classroom
                        break;
                    case 4:
                        ClassroomDetails();
                        break;
                    case 5:
                        exit = false; //feature 08 - Exit
                        Console.Write("Exiting app..");
                        break;
                    default: //handles exceptions were the user selection was invalid and brings up the main menu
                        Console.WriteLine("Invalid entry");
                        break;
                }
            } while (exit); //feature 08 - Exit
        } // mainMenu()

        public static void AddClassroom() // method to add a classroom to the dictionary
        {
            Console.Clear();
            try //we are using try catch to get any errors/exceptions when we run the following code
            {
                Console.WriteLine("Enter the Classroom Name:");
                string classroomName = Console.ReadLine().ToUpper();

                classrooms.Add(classroomName, new Classroom(classroomName)); // adds a classroom to the list
            }
            catch (Exception e) // catches the error and returns to menu
            {
                Console.WriteLine(e.Message); // Prints an error message of what went wrong
                Console.WriteLine("Press any key to continue:");
                Console.ReadKey();
            }
        } // addClassroom()

        public static void ShowClassrooms()
        {
            Console.Clear();
            Console.WriteLine("Classrooms list:");
            foreach (KeyValuePair<string, Classroom> kvp in classrooms)
            {
                Console.WriteLine(kvp.Key); // here I just want to show the names for classrooms
            }
            Console.WriteLine("\nPress any key to continue:");
            Console.ReadKey();
        } // showClassrooms()

        public void RemoveClassroom()
        {
            Console.Clear();
            try
            {
                Console.WriteLine("Classrooms list:");
                foreach (KeyValuePair<string, Classroom> kvp in classrooms)
                {
                    Console.WriteLine(kvp.Key); // here I just want to show the keys/names for classrooms
                }

                Console.WriteLine("Enter the Classroom name to be removed"); //kvp.Value.name asi se usa
                string classroomName = Console.ReadLine().ToUpper();

                if (classrooms.ContainsKey(classroomName))
                {

                    classrooms.Remove(classroomName);
                }
                else
                {
                    MainMenu();
                }

                Console.WriteLine("Press any key to continue:");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Press any key to continue:");
                Console.ReadKey();
            }
        } // removeClassroom()

        public void ClassroomDetails()
        {
            Console.Clear();
            Console.WriteLine("Classrooms list:");
            foreach (KeyValuePair<string, Classroom> kvp in classrooms) // use this to show the list of classrooms stored
            {
                Console.WriteLine(kvp.Key); // here I just want to show the names for classrooms
            }

            Console.WriteLine("\nEnter the Classroom name to see details:");
            string classroomName = Console.ReadLine().ToUpper();

            Classroom currentClassroom = classrooms[classroomName];

            if (classrooms.ContainsKey(classroomName))
            {
                currentClassroom.StudentMenu(classroomName); // nested method
            }
            else
            {
                MainMenu();
            }
        } // classroomDetails()

    } // class
}// namespace
