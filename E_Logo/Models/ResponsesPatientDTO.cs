using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_LOGO.Models
{
    public class ResponsesPatientDTO
    {


        public int PatientID { get; set; }

        public virtual Patient Patient { get; set; }
        public int ResponseID { get; set; }
        public virtual Response Response { get; set; }
        public DateTime Date { get; set; }
    }
}