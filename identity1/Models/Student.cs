using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace identity1.Models
{
    public class Student
    {
        [Key]
        public int StudentId { set; get; }
        [Required]
        public string Name { set; get; }
        [Required]
        public string Surname { set; get; }
        [Required]
        public string Patronymic { set; get; }
        [Required]
        public DateTime DateOfBirth { set; get; }
        [Required]
        public string Address { set; get; }
        [Required]
        public string UniversityGroupName { set; get; }
        [Required]
        public double AverageExams { set; get; }

        public int GroupId { set; get; }
        public virtual Group Group { set; get; }
       
        public virtual ICollection<StudyEvent> StudyEvents { set; get; }
        
    }
}
