using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace identity1.Models
{
    public class Group
    {
        [Key]
        public int GroupId { set; get; }
        [Required]
        public string Name { set; get; }

        public int CommanderId { set; get; }
        public virtual Commander Commander { set; get; }

        public virtual ICollection<Student> Students { set; get; }

    }
}
