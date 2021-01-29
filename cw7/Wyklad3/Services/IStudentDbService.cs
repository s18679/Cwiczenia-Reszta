using Wyklad3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wyklad3.Services
{
    public interface IStudentDbService
    {
        public Student GetStudent(string Index);
    }
}