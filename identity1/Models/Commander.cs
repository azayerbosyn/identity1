using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace identity1.Models
{
    public class Commander : IValidatableObject
    {
        [Key]
        public int CommanderId { set; get; }
        
        [Required]
        public string CommanderLogin { set; get; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long.")]
        public string CommanderPass { set; get; }

        public virtual ICollection<Group> Groups { set; get; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(this.CommanderLogin))
            {
                errors.Add(new ValidationResult("Enter login!"));
            }
            if (string.IsNullOrWhiteSpace(this.CommanderPass))
            {
                errors.Add(new ValidationResult("Password must be at least 8 characters long."));
            }


            return errors;
        }
    }

}
