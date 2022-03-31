using System.ComponentModel.DataAnnotations;

namespace FreeCourseProjectWebUI.Models
{
    public class SingInInput
    {
        [Required]
        [Display(Name ="Email adresiniz")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Şifreniz")]
        public string Password { get; set; }

        [Display(Name = "Beni hatırla")]
        public bool IsRemember { get; set; }
    }
}
