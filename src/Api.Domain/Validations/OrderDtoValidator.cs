using Api.Domain.Dtos;
using FluentValidation;

namespace Api.Domain.Validations
{
    public class OrderDtoValidator : AbstractValidator<OrderDto>
    {
        public OrderDtoValidator()
        {            
            ValidateDocument();
            ValidateProducts();
        }

        private void ValidateDocument()
        {
            RuleFor(x => x.DocumentClient)
                .NotEmpty()
                .NotNull()
                .WithMessage("CPF não informado");

            RuleFor(x => x.DocumentClient)
                .IsValidCPF()
                .WithMessage("CPF inválido");
        }

        private void ValidateProducts()
        {
            RuleForEach(x => x.Products).ChildRules(x =>
            {
                x.RuleFor(x => x.CodeProduct)
                    .NotEmpty()
                    .NotNull()
                    .WithMessage("Código do produto não informado");

                x.RuleFor(x => x.CodeProduct)
                    .GreaterThan(0)
                    .WithMessage("Código deve ser maior que 0");
            });                            
        }
    }
}
