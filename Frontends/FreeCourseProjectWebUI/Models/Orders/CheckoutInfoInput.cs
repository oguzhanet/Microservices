﻿using System.ComponentModel.DataAnnotations;

namespace FreeCourseProjectWebUI.Models.Orders
{
    public class CheckoutInfoInput
    {
        [Display(Name = "İl")]
        public string Province { get; set; }

        [Display(Name = "İlçe")]
        public string District { get; set; }

        [Display(Name = "Cadde")]
        public string Street { get; set; }

        [Display(Name = "Posta Kodu")]
        public string ZipCode { get; set; }

        [Display(Name = "Adres")]
        public string Line { get; set; }

        [Display(Name = "Kart üzerindeki isim")]
        public string CardName { get; set; }

        [Display(Name = "Kart numarası")]
        public string CardNumber { get; set; }

        [Display(Name = "Son kulanma tarihi")]
        public string Expiration { get; set; }

        [Display(Name = "CVV/CVC2 numarası")]
        public string Cvv { get; set; }
    }
}
