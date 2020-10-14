using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace E_LOGO.Models
{
    public class Patient
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Fullname { get; set; }
        public virtual IList<ResponsesPatient> ResponsesPatient { get; set; } = new List<ResponsesPatient>();
        [NotMapped]
        public virtual IEnumerable<Response> Responses { get => ResponsesPatient.Select(r => r.Response); }
        public string Diagnostique { get; set; }
        public int LastTaskDoneID { get; set; }
        public int SpeechTherapistID { get; set; }
        [Required(ErrorMessage = "Must have a speech therapist")]
        public virtual SpeechTherapist SpeechTherapist { get; set; }
    }
}