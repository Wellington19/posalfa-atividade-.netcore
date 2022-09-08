using Api.Domain.Dtos;
using FluentValidation;

namespace Api.Domain.Validations
{
    public class CategoryDtoValidator : AbstractValidator<CategoryDto>
    {        
        public CategoryDtoValidator()
        {            
            ValidateDescription();            
        }

        private void ValidateDescription()
        {
            RuleFor(x => x.Description)
                .NotEmpty()
                .NotNull()
                .WithMessage("Descrição não informada");
        }
    }
}
