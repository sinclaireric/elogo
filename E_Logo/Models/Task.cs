using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace E_LOGO.Models
{
    public class Task
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Stimuli> Stimulis { get; set; } = new List<Stimuli>();
    }
}