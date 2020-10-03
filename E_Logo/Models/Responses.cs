using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace E_LOGO.Models
{
    public class Responses
    {

        [Key]
        public int Id { get; set; }

        public string Stimuli { get; set; }
        public string Choice1 { get; set; }
        public string Choice2 { get; set; }

        public string TitleVocalName { get; set; }
        public string TitlePictureName { get; set; }
        public int TaskID { get; set; }
        [Required(ErrorMessage = "Must have a Task")]

        public virtual Task Task { get; set; }
    }
}