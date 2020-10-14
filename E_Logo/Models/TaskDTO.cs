using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_LOGO.Models
{
    public class TaskDTO
    {

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public List<StimuliDTO> Stimulis { get; set; }
    }
}