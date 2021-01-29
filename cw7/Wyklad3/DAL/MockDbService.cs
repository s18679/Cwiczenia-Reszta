﻿using cw3.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wyklad3.Models;

namespace Wyklad3.DAL
{
    public class MockDbService : IDbService
    {
        private static IEnumerable<Student> _students;

        static MockDbService()
        {
            _students = new List<Student>
            {
                new Student { IdStudent = 1, FirstName = "Jan", LastName = "Kowalski" },
                new Student { IdStudent = 2, FirstName = "Andrzej", LastName = "Malewski" },
                new Student { IdStudent = 3, FirstName = "Maciej", LastName = "Andrzejewicz" }
             };
        }

        public IEnumerable<Student> GetStudents()
        {
            return _students;
        }
    };
}
