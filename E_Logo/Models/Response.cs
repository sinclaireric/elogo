using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Net.Mime.MediaTypeNames;

namespace E_LOGO.Models
{

    public enum Types
    {
        Choices = 1, Vocal = 2, Photo = 3,
    }
    public class Response
    {

        [Key]
        public int Id { get; set; }
        public Types Type { get; set; }
        [Required]
        public int StimuliID { get; set; }
        [Required(ErrorMessage = "Must have a Stimuli")]
        public virtual Stimuli Stimuli { get; set; }

        // [RequiredIf("Types", Types.Choices, ErrorMessage = " 2 Choices Required")]
        public string Choice { get; set; } // Si Types.choices

        // [RequiredIf("Types", Types.Choices, ErrorMessage = " 2 Choices Required")]
        // public string Choice2 { get; set; } // Si Types.choices

        // [RequiredIf("Types", Types.Vocal, ErrorMessage = "Vocal Required")]
        // public string TitleVocalName { get; set; } // Si Types.Vocal
        // [RequiredIf("Types", Types.Photo, ErrorMessage = "Photo Required")]
        // public string TitlePictureName { get; set; } // Si Types.Photo

    }
}