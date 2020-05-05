using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_LOGO.Models
{
    public class SpeechTherapistDTO
    {

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public IList<PatientDTO> Patients { get; set; }

    }
}