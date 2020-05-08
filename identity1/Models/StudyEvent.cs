using System;
using System.ComponentModel.DataAnnotations;


namespace identity1.Models
{
    public class StudyEvent
    {
        public int Id { set; get; }
        [Required]
        public string EventType { set; get; }
        public int? Mark { set; get; }
        [Required]
        public string DescriptionOfEvent { set; get; }
        [Required]
        public DateTime EventDate { set; get; }
      
        public int StudentId { set; get; }
        public virtual Student Student { set; get; }

    }
}
