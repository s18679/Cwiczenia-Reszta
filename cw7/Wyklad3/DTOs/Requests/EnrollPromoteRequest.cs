using System;
using System.ComponentModel.DataAnnotations;
    public class EnrollPromoteRequest
    {
        [Required]
        public string StudiesName{get; set;}
        [Required]
        [Range(1, 9)]
        public int Semester{get; set;}
    }