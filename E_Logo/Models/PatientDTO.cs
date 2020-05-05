using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_LOGO.Models
{
    public class PatientDTO
    {

        [Key]
        public int Id { get; set; }

        public string Fullname { get; set; }

        public string Results { get; set; }
        public string Diagnostique { get; set; }
        public string LastTaskDone { get; set; }
        public int SpeechTherapistID { get; set; }
        public SpeechTherapistDTO SpeechTherapistDTO { get; set; }
    }
}