using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_LOGO.Models
{
    public class ResponseDTO
    {

        [Key]
        public int Id { get; set; }

        public Types Type { get; set; }
        public string Choice { get; set; }
        public int StimuliID { get; set; }
        public bool isGoodAnswer { get; set; }
        public StimuliDTO Stimuli { get; set; }
        //   public List<PatientDTO> Patients { get; set; }
    }
}