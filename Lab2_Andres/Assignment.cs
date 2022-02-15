using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab2_Andres
{
    public class Assignment
    {   // Variable
        double _grade = 0;

        // Properties
        public bool Status { get; private set; } = false;
        public double Grade
        {
            get // when we try to get the grade its default value will be
            {   // that of the variable _grade, which is 0.
                return _grade; // remember that we have not grade the assignment yet!
            }
            set // when we grade the assignment we are setting Grade to what ever
            {           // value it's wanted, so at the same time we want to set Status to
                        // either complete when graded or incomplete when not graded.
                _grade = value; // here we are saying that if Grade is set to it's default
                if (Grade > 0)
                {                  // Status is incomplete 
                    Status = true; // If Grade has been set to something other than 0 then
                }                  // it's complete.
            }
        }
        public string Name { get; private set; }

        public Assignment()
        {
        }

        public Assignment(string _name)
        {
            Name = _name;
        }
        // Assignment.Grade(grade); asignar nota / falta buscar para quien

    }
}
