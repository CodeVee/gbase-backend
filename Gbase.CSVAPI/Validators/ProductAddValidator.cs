using FluentValidation;
using Gbase.CSVAPI.DTOs;
using Gbase.CSVAPI.Models;
using System;

namespace Gbase.CSVAPI.Validators
{

    public class ProductAddValidator : AbstractValidator<ProductAddDto>
    {
        public ProductAddValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(product => product.UniqueId)
                .NotEmpty().WithMessage("UniqueId is required.");

            RuleFor(product => product.Price)
                .NotEmpty().WithMessage("Price is required.")
                .Must(ValidatePrice).WithMessage("Price must be a valid number or Call.");

            RuleFor(product => product.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(500).WithMessage("Description cannot be longer than 500 characters.");

            RuleFor(product => product.Year)
                .NotEmpty().WithMessage("Year is required.")
                .Must(ValidateYear).WithMessage("Year must be between 1800 and 2005.");

            RuleFor(product => product.Case)
                .NotEmpty().WithMessage("Case is required.")
                .Must(pc => ApiConstants.ValidCases.Contains(pc)).WithMessage("Invalid Case.");

            RuleFor(product => product.Condition)
                .NotEmpty().WithMessage("Condition is required.")
                .Must(pc => ApiConstants.ValidConditions.Contains(pc)).WithMessage("Invalid Condition.");

            RuleFor(product => product.Type)
                .NotEmpty().WithMessage("Type is required.")
                .Must(pc => ApiConstants.ValidTypes.Contains(pc)).WithMessage("Invalid Type.");

            RuleFor(product => product.Picture1)
                .Must(ValidateUrl).WithMessage("Invalid URL.")
                .When(product => !string.IsNullOrWhiteSpace(product.Picture1));

            RuleFor(product => product.Picture2)
                .Must(ValidateUrl).WithMessage("Invalid URL.")
                .When(product => !string.IsNullOrWhiteSpace(product.Picture2));

            RuleFor(product => product.Picture3)
                .Must(ValidateUrl).WithMessage("Invalid URL.")
                .When(product => !string.IsNullOrWhiteSpace(product.Picture3));

            RuleFor(product => product.Picture4)
                .Must(ValidateUrl).WithMessage("Invalid URL.")
                .When(product => !string.IsNullOrWhiteSpace(product.Picture4));

            RuleFor(product => product.Picture5)
                .Must(ValidateUrl).WithMessage("Invalid URL.")
                .When(product => !string.IsNullOrWhiteSpace(product.Picture5));

            RuleFor(product => product.Picture6)
                .Must(ValidateUrl).WithMessage("Invalid URL.")
                .When(product => !string.IsNullOrWhiteSpace(product.Picture6));

            RuleFor(product => product.OffsiteLinkUrl1)
                .NotEmpty().WithMessage("Invalid URL.")
                .Must(ValidateUrl).WithMessage("Invalid URL.")
                .When(product => !string.IsNullOrWhiteSpace(product.OffsiteLinkLabel1));

            RuleFor(product => product.OffsiteLinkUrl2)
                .NotEmpty().WithMessage("Invalid URL.")
                .Must(ValidateUrl).WithMessage("Invalid URL.")
                .When(product => !string.IsNullOrWhiteSpace(product.OffsiteLinkLabel2));
        }

        private bool ValidateUrl(string? url)
        {
            return Uri.IsWellFormedUriString(url, UriKind.Absolute);
        }

        private bool ValidatePicture(string? picture)
        {
            if (picture == null) return false;
            return picture.EndsWith(".jpeg") || picture.EndsWith(".jpg") || picture.EndsWith(".gif");
        }

        private static bool ValidatePrice(string? price)
        {
            var valid = decimal.TryParse(price, out _);
            return valid || price?.ToLower() == "call";
        }

        private static bool ValidateYear(string? year)
        {
            var valid = int.TryParse(year, out int result);
            if (!valid) { return false; }
            return result >= 1800 && result <= 2005;
        }
    }

}
