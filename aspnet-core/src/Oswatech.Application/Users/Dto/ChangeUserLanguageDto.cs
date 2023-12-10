using System.ComponentModel.DataAnnotations;

namespace Oswatech.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}