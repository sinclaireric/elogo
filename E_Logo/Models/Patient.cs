using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_LOGO.Models
{
    public class Patient
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Fullname { get; set; }
        public string Results { get; set; }
        public string Diagnostique { get; set; }
        public string LastTaskDone { get; set; }
        public int SpeechTherapistID { get; set; }
        [Required(ErrorMessage = "Must have a speech therapist")]
        public virtual SpeechTherapist SpeechTherapist { get; set; }
    }
}