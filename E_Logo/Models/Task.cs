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

        public IList<Stimuli> Stimulis { get; set; } = new List<Stimuli>();

        [NotMapped]
        public IList<Response> Responses { get; set; } = new List<Response>();
    }
}