using Api.Domain.Dtos;
using FluentValidation;

namespace Api.Domain.Validations
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {        
        public ProductDtoValidator()
        {
            ValidateCategory();
            ValidateDescription();
            ValidateCode();
            ValidatePrice();
            ValidateStock();
        }

        private void ValidateCategory()
        {
            RuleFor(x => x.CategoryId)
                .NotEmpty()
                .NotNull()
                .WithMessage("ID da categoria não informado");
        }

        private void ValidateDescription()
        {
            RuleFor(x => x.Description)
                .NotEmpty()
                .NotNull()
                .WithMessage("Descrição não informada");
        }

        private void ValidateCode()
        {
            RuleFor(x => x.Code)
                .NotEmpty()
                .NotNull()
                .WithMessage("Código não informado");
        }

        private void ValidatePrice()
        {
            RuleFor(x => x.Price)
                .NotEmpty()
                .NotNull()
                .WithMessage("Preço não informado");

            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithMessage("Preço deve ser maior que 0");
        }        

        private void ValidateStock()
        {
            RuleFor(x => x.Stock)
                .NotEmpty()
                .NotNull()
                .WithMessage("Quantidade em estoque não informado");

            RuleFor(x => x.Stock)
                .GreaterThan(0)
                .WithMessage("Quantidade em estoque deve ser maior que 0");
        }
    }
}
