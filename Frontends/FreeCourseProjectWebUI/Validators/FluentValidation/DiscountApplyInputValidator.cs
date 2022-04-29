using FluentValidation;
using FreeCourseProjectWebUI.Models.Discounts;

namespace FreeCourseProjectWebUI.Validators.FluentValidation
{
    public class DiscountApplyInputValidator:AbstractValidator<DiscountApplyInput>
    {
        public DiscountApplyInputValidator()
        {
            RuleFor(x=>x.Code).NotEmpty().WithMessage("indirim kodu alanı boş olamaz.");
        }
    }
}
