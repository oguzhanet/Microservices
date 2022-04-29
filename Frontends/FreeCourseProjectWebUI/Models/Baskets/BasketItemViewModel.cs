namespace FreeCourseProjectWebUI.Models.Baskets
{
    public class BasketItemViewModel
    {
        public int Quantity { get; set; } = 1;

        public decimal Price { get; set; }

        public string CourseId { get; set; }

        public string CourseName { get; set; }

        public decimal GetCurrentPrice { get => DiscountAppliedPrice != null ? DiscountAppliedPrice.Value : Price; }


        private decimal? DiscountAppliedPrice;

        public void AppliedDiscount(decimal discountPrice)
        {
            DiscountAppliedPrice = discountPrice;
        }
    }
}
