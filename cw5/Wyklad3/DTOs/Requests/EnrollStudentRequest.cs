using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
public class EnrollStudentRequest
{
    [RegularExpression("^s[0-9]+$")]
    public string IndexNumber{get; set;}

    [Required(ErrorMessage = "Musisz podac imie")]
    [MaxLength(10)]
    public string FirstName{get; set;}

    [Required(ErrorMessage = "Musisz podac nazwisko")]
    [MaxLength(17)]
    public string LastName{get; set;}

    [Required]
    public DateTime BirthDate{get; set;}

    [Required]
    public string Studies{get; set;}

    [Required]
    public int Semester { get; set; }
}
