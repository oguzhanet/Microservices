using System.ComponentModel.DataAnnotations;

namespace FreeCourseProjectWebUI.Models.Catalogs
{
    public class FeatureViewModel
    {
        [Display(Name = "Kurs süresi")]
        public int Duration { get; set; }
    }
}
