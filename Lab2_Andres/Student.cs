using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab2_Andres
{
    public class Student
    {
        // Properties
        public string Name { get; private set; }
        public double StudentAverageGrade { get; private set; }
        public bool CompletionStatus { get; private set; }


        // Dictionary
        public Dictionary<string, Assignment> assignments { get; }

        // Constructor
        public Student(string studentName)
        {
            Name = studentName.ToUpper(); // will make the name uppercase
            assignments = new Dictionary<string, Assignment>();
            CompletionStatus = false;
        }

        // Methods

        public static void AddAssignment(Student currentStud)
        {
            Student currentStudent = currentStud;
            Console.Clear();
            try //we are using try catch to get any errors/exceptions when we run the following code
            {
                string assignmentName = "";
                while (assignmentName is "" or null) //to verify that an input has been provided
                {
                    Console.WriteLine("Enter the Assignment Name:"); //to get the name of the assignment from input
                    assignmentName = Console.ReadLine().ToUpper(); //when user enters a string is going to capitalize it
                }//while

                // I'm using the current student object to add an assignment to
                currentStudent.assignments.Add(assignmentName, new Assignment(assignmentName));
            }//try
            catch (Exception e) // catches the error and returns to menu
            {
                Console.WriteLine(e.Message); // Prints an error message of what went wrong
                Console.WriteLine("Press any key to continue:");
                Console.ReadKey();
            }//catch
        }//AddAssignment

        public static void ShowStudentSummary(Student currentStud)
        {
            Student currentStudent = currentStud;
            try
            {
                Console.Clear();
                Console.WriteLine("\nName: " + currentStudent.Name);
                Console.WriteLine("Average Grade: " + currentStudent.StudentAverageGrade); // Calculate the average grade for this student
                Console.WriteLine("All assignments Complete: " + currentStudent.CompletionStatus);
                Console.WriteLine("Number of Assignments: " + currentStudent.assignments.Count);
                Console.WriteLine("\nPress any key to continue:");
                Console.ReadKey();
            }//try
            catch (Exception e) // catches the error and returns to menu
            {
                Console.WriteLine(e.Message); // Prints an error message of what went wrong
                Console.WriteLine("Press any key to continue:");
                Console.ReadKey();
            }//catch
        }//ShowStudentsSummary

        public static void RemoveAssignment(Student currentStud) // is not removing assignments
        {
            Student currentStudent = currentStud;
            try
            {
                Console.Clear();
                Console.WriteLine("Assignment list:");
                foreach (KeyValuePair<string, Assignment> kvp in currentStudent.assignments)
                {
                    Console.WriteLine("\nName: " + kvp.Key);
                    Console.WriteLine("Grade: (" + kvp.Value.Grade + "%)  Status: (" + kvp.Value.Status + ")");
                }

                Console.WriteLine("\nEnter the Assignment name to be removed");
                string assignmentName = Console.ReadLine().ToUpper();
                if (currentStudent.assignments.ContainsKey(assignmentName))
                {
                    currentStudent.assignments.Remove(assignmentName);
                }
            }//try

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Press any key to continue:");
                Console.ReadKey();
            }//catch
        } // removeAssignment()

        public static void ShowAssignments(Student currentStud)
        {
            Student currentStudent = currentStud;

            try
            {
                Console.Clear(); //clear console before displaying something new
                Console.WriteLine("Assignment list:");
                foreach (KeyValuePair<string, Assignment> assignment in currentStudent.assignments) //looping through the assignment dictionary of the current student
                {
                    Console.WriteLine("\nName: " + assignment.Key); // shows the assignment by name/key
                    if (assignment.Value.Status) // If Status = true, move to complete statement
                    {
                        Console.WriteLine("Grade: (" + assignment.Value.Grade + "%)  Status: (Complete)");
                    }
                    else
                    {
                        Console.WriteLine("Grade: (" + assignment.Value.Grade + "%)  Status: (Incomplete)");
                    }
                }//foreach
                Console.WriteLine("\nPress any key to continue:");
                Console.ReadKey();
            }//try
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Press any key to continue:");
                Console.ReadKey();
            }//catch
        } // showAssignment()

        public static void GradeAssignment(Student currentStud)  //not done yet
        {
            Student currentStudent = currentStud;

            try
            {
                Console.Clear();
                Console.WriteLine("Assignmentlist:\n");
                foreach (KeyValuePair<string, Assignment> assignments in currentStudent.assignments) //looping through the assignment dictionary of the current student 
                {
                    Console.WriteLine(assignments.Key); // here I just want to show the keys/names for classrooms
                }

                Console.WriteLine("\nEnter the Assignment to grade:");
                string assignmentName = Console.ReadLine().ToUpper();

                if (currentStudent.assignments.ContainsKey(assignmentName)) // I'm comparing the input value with the stored values
                {
                    string input = null;
                    Console.Clear();

                    Console.WriteLine("Assignment: " + assignmentName); // here I just want to show the name the selected classrooms
                    Console.WriteLine("\nEnter the grade:");
                    input = Console.ReadLine(); //get the string input
                    double grade = double.Parse(input); //takes string input and converts it to double type number
                    if (grade >= 0)
                    {
                        Assignment grading = currentStudent.assignments[assignmentName];
                        grading.Grade = Math.Round(grade, 5); //asignar nota para el objeto especifico
                    }
                    else
                    {
                        Console.WriteLine("Grade must be greater than 0");
                    }

                    foreach (KeyValuePair<string, Assignment> assignments in currentStudent.assignments)
                    {
                        if (assignments.Value.Status) // If Status = true, it will make if = true and proceed
                        {
                            currentStudent.CompletionStatus = true;
                        }
                    }

                    // Here we get the average for the Student Grades
                    double avgSum = 0;
                    double assignmentsAvg;

                    foreach (KeyValuePair<string, Assignment> assignmentsGrade in currentStudent.assignments)
                    {
                        assignmentsAvg = assignmentsGrade.Value.Grade;
                        avgSum += assignmentsAvg;

                        currentStudent.StudentAverageGrade = Math.Round(avgSum / currentStudent.assignments.Count, 3);
                    }
                }//if 
            }//try
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Press any key to continue:");
                Console.ReadKey();
            }
        } // gradeAssignment()

        public static void ShowBestGrade(Student currentStud)
        {
            Student currentStudent = currentStud;

            try
            {
                Console.Clear();
                Console.WriteLine("Assignment list:");
                foreach (KeyValuePair<string, Assignment> kvp in currentStudent.assignments)
                {
                    Console.WriteLine("\nName: " + kvp.Key);
                    if (kvp.Value.Status)
                    {
                        Console.WriteLine("Grade: (" + kvp.Value.Grade + "%)  Status: (Complete)");
                    }
                    else
                    {
                        Console.WriteLine("Grade: (" + kvp.Value.Grade + "%)  Status: (Incomplete)");
                    }
                }//foreach

                double max = currentStudent.assignments.Max(kvp => kvp.Value.Grade); //looks for the max value in the Value.AverageGrade
                string best;
                best = currentStudent.assignments.Where(kvp => kvp.Value.Grade == max).First().Key; //gets the key that contains the max value

                if (currentStudent.assignments.ContainsKey(best))
                {
                    Console.WriteLine("\n" + best + " has the Best grade.");
                }
                Console.WriteLine("\nPress any key to continue:");
                Console.ReadKey();
            }//try
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Press any key to continue:");
                Console.ReadKey();
            }//catch
        } // showBestGrade()

        public static void ShowWorstGrade(Student currentStud)
        {
            Student currentStudent = currentStud;

            try
            {
                Console.Clear();
                Console.WriteLine("Assignment list:");
                foreach (KeyValuePair<string, Assignment> kvp in currentStudent.assignments)
                {
                    Console.WriteLine("\nName: " + kvp.Key);
                    if (kvp.Value.Status)
                    {
                        Console.WriteLine("Grade: (" + kvp.Value.Grade + "%)  Status: (Complete)");
                    }
                    else
                    {
                        Console.WriteLine("Grade: (" + kvp.Value.Grade + "%)  Status: (Incomplete)");
                    }
                }

                double min = currentStudent.assignments.Min(kvp => kvp.Value.Grade); //looks for the max value in the Value.AverageGrade
                string worst;
                worst = currentStudent.assignments.Where(kvp => kvp.Value.Grade == min).First().Key; //gets the key that contains the max value

                if (currentStudent.assignments.ContainsKey(worst))
                {
                    Console.WriteLine("\n" + worst + " has the Worst grade.");
                }
                Console.WriteLine("Press any key to continue:");
                Console.ReadKey();
            }//try
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Press any key to continue:");
                Console.ReadKey();
            }//catch
        } // showWorstGrade()

        // Menu Methods

        public static void StudentDetailsSub(string classroomName)
        {
            Classroom currentClassroom = School.classrooms[classroomName];
            Console.Clear();
            try
            {
                Console.WriteLine("Student list:");
                foreach (KeyValuePair<string, Student> kvp in currentClassroom.students) // use this to show the list of classrooms stored
                {
                    Console.WriteLine(kvp.Key); // here I just want to show the names for classrooms
                }

                Console.WriteLine("\nEnter the Student name to see details:");
                string studentName = Console.ReadLine().ToUpper();

                Student currentStudent = currentClassroom.students[studentName];

                if (currentClassroom.students.ContainsKey(studentName))
                {
                    StudentDetails(currentStudent); // nested method
                }
                else
                {
                    currentClassroom.StudentMenu(classroomName);
                }
            }//try
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Press any key to continue:");
                Console.ReadKey();
            }//catch
        }//StudentDetailsSub

        public static void StudentDetails(Student studentName)
        {
            bool back = true; //feature 08 - Exit
            try
            {
                do
                {
                    Console.Clear();

                    Console.WriteLine(@"Select from the following options

Option 1: Add Assignment
Option 2: Show Summary
Option 3: Remove Assignment
Option 4: Show Assignment
Option 5: Grade Assignment
Option 6: Show Best Grade
Option 7: Show Worst Grade
Option 8: Back to Classroom Details 

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
                            AddAssignment(studentName); //feature 0 - Add Assignment
                            break;
                        case 2:
                            ShowStudentSummary(studentName); //feature 0 - Show summary
                            break;
                        case 3:
                            RemoveAssignment(studentName); //feature 0 - remove Assignment
                            break;
                        case 4:
                            ShowAssignments(studentName);  //feature 0 - show Assignment
                            break;
                        case 5:
                            GradeAssignment(studentName); //feature 0 - grade Assignment
                            break;
                        case 6:
                            ShowBestGrade(studentName); //feature 0 - show best grade
                            break;
                        case 7:
                            ShowWorstGrade(studentName);  //feature 0 - show worst grade
                            break;
                        case 8:
                            back = false; //feature 08 - Exit
                            break;
                        default: //handles exceptions were the user selection was invalid and brings up the menu
                            Console.WriteLine("Invalid entry");
                            continue;
                    }
                } while (back); //feature 08 - Exit
            }//try
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Press any key to continue:");
                Console.ReadKey();
            }//catch
        } // studentDetails()

    } // class
} // namespace
