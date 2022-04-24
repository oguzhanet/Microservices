﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace FreeCourseProjectWebUI.Models.Catalog
{
    public class CourseUpdateInput
    {
        public string Id { get; set; }

        [Display(Name = "Kurs ismi")]
        public string Name { get; set; }

        [Display(Name = "Kurs açıklamsı")]
        public string Description { get; set; }

        [Display(Name = "Kurs ücreti")]
        public decimal Price { get; set; }

        public string UserId { get; set; }

        public string Picture { get; set; }

        public FeatureViewModel Feature { get; set; }

        [Display(Name = "Kurs kategori")]
        public string CategoryId { get; set; }

        [Display(Name = "Kurs resim")]
        public IFormFile PhotoFormFile { get; set; }
    }
}
