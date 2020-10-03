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

        public virtual IList<Responses> Responses { get; set; } = new List<Responses>();
    }
}