using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab2_Andres
{
    public class Classroom : School // inherit from this class to be able to use it's properties                  
    {
        // Properties
        public string Name { get; private set; }

        // Dictionary
        public Dictionary<string, Student> students { get; }

        public Classroom(string className) // Using constructor to assign a name to the classroom
        {
            Name = className.ToUpper(); // here I'm setting the value of Name to the string entered via attribute
            students = new Dictionary<string, Student>();
        }

        // Methods
        public static void AddStudent(string aClassroom) //another way to do it
        {
            Console.Clear();
            // to get the name of the student from input
            Console.WriteLine("Enter the Student name:");
            string studentName = Console.ReadLine().ToUpper();

            // to instanciate an object and give it a name
            Student newStudent = new Student(studentName);

            // to get the actual classroom we are working on
            Classroom currentClassroom = classrooms[aClassroom];

            // to add the item/student to the dictionary
            // I'm associating the student to the classroom because of dictionary key/value  
            currentClassroom.students.Add(newStudent.Name, newStudent);
        } // AddStudent

        public static void ShowClassroomStudents(string aClassroom)
        {
            Classroom currentClassroom = classrooms[aClassroom];
            Console.Clear();
            Console.WriteLine("Student list:");

            foreach (KeyValuePair<string, Student> studentInClassroom in currentClassroom.students)
            {

                Console.WriteLine("\nName:  " + studentInClassroom.Key + "\nAverage Grade: " + studentInClassroom.Value.StudentAverageGrade + "%");

                Console.WriteLine("All Assignments Complete: " + studentInClassroom.Value.CompletionStatus + "\nNumber of Assignments: " + studentInClassroom.Value.assignments.Count);

            }

            Console.WriteLine("\nPress any key to continue:");
            Console.ReadKey();

        }//showTheStudents()

        public void RemoveStudent()
        {
            Console.Clear();
            try
            {
                Console.WriteLine("Student list:");
                foreach (KeyValuePair<string, Student> student in students)
                {
                    Console.WriteLine("\nName: " + student.Key + "\nAverage Grade: " + student.Value.StudentAverageGrade + "%");
                    Console.WriteLine("Assignment Complete: " + student.Value.CompletionStatus + "\nNumber of Assignments: " + student.Value.assignments.Count);
                }

                Console.WriteLine("\nEnter the Student name to be removed");
                string studentName = Console.ReadLine().ToUpper();

                if (students.ContainsKey(studentName))
                {
                    students.Remove(studentName);
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
        } //removeStudent()

        public void CompareStudent()
        {
            Console.Clear();
            try
            {
                Console.WriteLine("Student list:");
                foreach (KeyValuePair<string, Student> student in students)
                {
                    Console.WriteLine("\nName: " + student.Key + "\nAverage Grade: " + student.Value.StudentAverageGrade + "%");
                    Console.WriteLine("Assignment Complete: " + student.Value.CompletionStatus + "\nNumber of Assignments: " + student.Value.assignments.Count);
                }

                Console.WriteLine("\nEnter the First Student name to compare");
                string firstStudent = Console.ReadLine().ToUpper();

                Console.WriteLine("\nEnter the Second Student name to compare");
                string secondStudent = Console.ReadLine().ToUpper();

                Console.Clear();

                if (students.ContainsKey(firstStudent))
                {
                    Console.WriteLine("\nName: " + students[firstStudent].Name + "\nAverage Grade: " + students[firstStudent].StudentAverageGrade + "%");
                    Console.WriteLine("Assignment Complete: " + students[firstStudent].CompletionStatus + "\nNumber of Assignments: " + students[firstStudent].assignments.Count);
                }
                if (students.ContainsKey(secondStudent))
                {
                    Console.WriteLine("\nName: " + students[secondStudent].Name + "\nAverage Grade: " + students[secondStudent].StudentAverageGrade + "%");
                    Console.WriteLine("Assignment Complete: " + students[secondStudent].CompletionStatus + "\nNumber of Assignments: " + students[secondStudent].assignments.Count);
                }
                if (students[firstStudent].StudentAverageGrade > students[secondStudent].StudentAverageGrade)
                {
                    Console.WriteLine("\n" + firstStudent + " has the higher grade");
                }
                else if (students[firstStudent].StudentAverageGrade < students[secondStudent].StudentAverageGrade)
                {
                    Console.WriteLine("\n" + secondStudent + " has the higher grade");
                }
                else if (students[firstStudent].CompletionStatus && students[secondStudent].CompletionStatus)
                {
                    Console.WriteLine("\nBoth students don't have any assignments");
                }
                else if (students[firstStudent].StudentAverageGrade == students[secondStudent].StudentAverageGrade)
                {
                    Console.WriteLine("\nBoth students have the same grade");
                }

                Console.WriteLine("\nPress any key to continue:");
                Console.ReadKey();
            } //try
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Press any key to continue:");
                Console.ReadKey();
            }
        }//compareStudent()

        public void ShowClassroomAvgGrade(string currentClass)
        {
            Classroom currentClassroom = classrooms[currentClass];
            Console.Clear();
            try
            {
                double studentAvgGrade;
                double studentSum = 0; // sum of students averages
                double classroomAvgGrade = 0;

                foreach (KeyValuePair<string, Student> student in currentClassroom.students)
                {
                    studentAvgGrade = student.Value.StudentAverageGrade;
                    studentSum += studentAvgGrade;
                    classroomAvgGrade = studentSum / students.Count;
                }

                Console.WriteLine("The Average Grade for the classroom is: " + classroomAvgGrade + "%");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("\nPress any key to continue:");
                Console.ReadKey();
            }
        } //showAvgGrade()

        public void BestStudent()
        {
            Console.Clear();
            try
            {
                Console.WriteLine("Student list:");
                foreach (KeyValuePair<string, Student> student in students)
                {
                    Console.WriteLine("\nName: " + student.Key + "\nAverage Grade: " + student.Value.StudentAverageGrade + "%");
                    Console.WriteLine("Assignment Complete: " + student.Value.CompletionStatus + "\nNumber of Assignments: " + student.Value.assignments.Count);
                }
                double max = students.Max(student => student.Value.StudentAverageGrade); //looks for the max value in the Value.AverageGrade
                string best;
                best = students.Where(student => student.Value.StudentAverageGrade == max).First().Key; //gets the key that contains the max value

                if (students.ContainsKey(best))
                {
                    Console.WriteLine("\nThe best student is: " + students[best].Name);
                }
                Console.WriteLine("\nPress any key to continue:");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Press any key to continue:");
                Console.ReadKey();
            }

        } //bestStudent()

        public void WorstStudent()
        {
            Console.Clear();
            try
            {
                Console.WriteLine("Student list:");
                foreach (KeyValuePair<string, Student> student in students)
                {
                    Console.WriteLine("\nName: " + student.Key + "\nAverage Grade: " + student.Value.StudentAverageGrade + "%");
                    Console.WriteLine("Assignment Complete: " + student.Value.CompletionStatus + "\nNumber of Assignments: " + student.Value.assignments.Count);
                }
                double min = students.Min(student => student.Value.StudentAverageGrade); //looks for the max value in the Value.AverageGrade
                string worst;
                worst = students.Where(student => student.Value.StudentAverageGrade == min).First().Key; //gets the key that contains the max value

                if (students.ContainsKey(worst))
                {
                    Console.WriteLine("\nThe worst student is: " + students[worst].Name);
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

        } //worstStudent()

        // Menu Method
        public void StudentMenu(string classroomName)
        {

            bool back = true; //feature 08 - Exit
            do
            {
                Console.Clear();
                Console.WriteLine("Classroom: " + classroomName);
                Console.WriteLine(@"Select from the following options

Option 1: Add Student
Option 2: Show Students
Option 3: Remove Students
Option 4: Student Details
Option 5: Compare Students
Option 6: Show Average Grade
Option 7: Best Student
Option 8: Worst Student
Option 9: Back to main menu

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
                        AddStudent(classroomName);
                        break;
                    case 2:
                        ShowClassroomStudents(classroomName);
                        break;
                    case 3:
                        RemoveStudent(); //feature 0 - remove student
                        break;
                    case 4:
                        Student.StudentDetailsSub(classroomName);  //feature 0 - student details
                        break;
                    case 5:
                        CompareStudent(); //feature 0 - compare students
                        break;
                    case 6:
                        ShowClassroomAvgGrade(classroomName); //feature 0 - show average grade
                        break;
                    case 7:
                        BestStudent();  //feature 0 - best student
                        break;
                    case 8:
                        WorstStudent();  //feature 0 - worst student
                        break;
                    case 9:
                        back = false; //feature 08 - Exit
                        break;
                    default: //handles exceptions were the user selection was invalid and brings up the menu
                        Console.WriteLine("Invalid entry");
                        continue;
                }
            } while (back); //feature 08 - Exit
        }// studentMenu

    } // class
} // namespace
