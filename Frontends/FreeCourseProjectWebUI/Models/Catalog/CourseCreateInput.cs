using System.ComponentModel.DataAnnotations;

namespace FreeCourseProjectWebUI.Models.Catalog
{
    public class CourseCreateInput
    {
        [Display(Name ="Kurs ismi")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Kurs açıklamsı")]
        [Required]
        public string Description { get; set; }

        [Display(Name = "Kurs ücreti")]
        [Required]
        public decimal Price { get; set; }

        public string UserId { get; set; }

        public string Picture { get; set; }

        public FeatureViewModel Feature { get; set; }

        [Display(Name = "Kurs kategori")]
        [Required]
        public string CategoryId { get; set; }
    }
}
