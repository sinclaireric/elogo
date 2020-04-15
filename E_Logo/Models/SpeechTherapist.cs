using System.ComponentModel.DataAnnotations;

namespace E_Logo.Models
{
    public class SpeechTherapist
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Required")]
        [RegularExpression("^[a-zA-Z][a-zA-Z0-9_]*$", ErrorMessage = "Characters are not allowed.")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Remark must have min length of 3 and max Length of 10")]
        public string Username { get; set; }
        
        [Required(ErrorMessage = "Required")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Remark must have min length of 3 and max Length of 10")]
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

    }
}