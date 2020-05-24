using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace identity1.Models
{
    public class News
    {
        [Key]
        public long id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string content { get; set; }
        public string fullContent { get; set; }



    }
}
