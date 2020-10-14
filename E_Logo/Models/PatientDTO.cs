using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace E_LOGO.Models
{
    public class PatientDTO
    {

        [Key]
        public int Id { get; set; }

        public string Fullname { get; set; }

        public List<ResponseDTO> Responses { get; set; }
        public string Diagnostique { get; set; }
        public int LastTaskDoneID { get; set; }
        public int SpeechTherapistID { get; set; }
        public SpeechTherapistDTO SpeechTherapistDTO { get; set; }
    }
}