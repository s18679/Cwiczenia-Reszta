﻿using Wyklad3.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Wyklad3.Services
{
    public class SqlServerStudentDbService : IStudentDbService
    {
        public Student GetStudent(string Index)
        {
            Student student = null;
            using (var connection = new SqlConnection("Data Source=db-mssql;Initial Catalog=s18679;Integrated Security=True"))
            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                connection.Open();
                command.CommandText = "select Student.IndexNumber, Student.FirstName, Student.LastName, Student.BirthDate," +
                                        "Enrollment.Semester, Studies.Name from student " +
                                         "INNER JOIN Enrollment ON student.IdEnrollment=Enrollment.IdEnrollment" +
                                         "INNER JOIN Studies ON enrollment.IdStudy=Studies.IdStudy" +
                                         "where indexnumber=@index";
                command.Parameters.AddWithValue("index", Index);
                SqlDataReader dr = command.ExecuteReader();
                if (dr.Read())
                {
                    student = new Student();
                    student.IndexNumber = dr["IndexNumber"].ToString();
                    student.FirstName = dr["FirstName"].ToString();
                    student.LastName = dr["LastName"].ToString();
                    student.BirthDate = dr["BirthDate"].ToString();
                    student.Semester = dr["Semester"].ToString() + " Semestr";
                    student.Studies = dr["Name"].ToString();
                }
                dr.Close();
            }
            return student;
        }
    }
}