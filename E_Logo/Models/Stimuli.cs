using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace E_LOGO.Models
{
    public class Stimuli
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public int TaskID { get; set; }
        public virtual Task Task { get; set; }
        public virtual IList<Response> Responses { get; set; } = new List<Response>();
    }
}