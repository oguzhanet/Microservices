using System.ComponentModel.DataAnnotations;

namespace FreeCourseProjectWebUI.Models.Catalog
{
    public class FeatureViewModel
    {
        [Display(Name = "Kurs süresi")]
        [Required]
        public int Duration { get; set; }
    }
}
