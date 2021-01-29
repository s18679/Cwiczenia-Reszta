﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wyklad3.Models
{
    public class Student
    {
        public int IdStudent{get; set;}
        public int IdEnrollment { get; set; }
        public string FirstName{get; set;}
        public string LastName{get; set;}
        public string IndexNumber{get; set;}
        public string BirthDate{get; set;}
        public string Studies{get; set;}
        public string Semester{get; set;}
        public object Subject{get; internal set;}

        public string ToString()
        {
            return IndexNumber + " " + FirstName + " " + LastName + " " + BirthDate + " " + Semester + " " + Studies;
        }
    }
}
