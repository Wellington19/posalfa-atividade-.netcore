using Api.Domain.Dtos;
using FluentValidation;

namespace Api.Domain.Validations
{
    public class ClientDtoValidator : AbstractValidator<ClientDto>
    {
        public ClientDtoValidator()
        {
            ValidateName();
            ValidateDocument();
            ValidateEmail();
        }

        private void ValidateName()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Nome não informado");
        }

        private void ValidateDocument()
        {
            RuleFor(x => x.Document)
                .NotNull()
                .NotEmpty()
                .WithMessage("Documento não informado");

            RuleFor(x => x.Document)
                .IsValidCPF()
                .WithMessage("CPF inválido");
        }

        private void ValidateEmail()
        {
            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .WithMessage("E-mail não informado");

            RuleFor(x => x.Email)
               .EmailAddress()
               .WithMessage("E-mail inválido");
        }
    }
}
