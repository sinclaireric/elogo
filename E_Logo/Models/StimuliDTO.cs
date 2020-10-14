using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_LOGO.Models
{
    public class StimuliDTO
    {

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public int TaskID { get; set; }
        public TaskDTO Task { get; set; }
        public List<ResponseDTO> Responses { get; set; }
    }
}