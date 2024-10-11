using CP2.Domain.Interfaces.Dtos;
using FluentValidation;
using System.Security.Cryptography.X509Certificates;

namespace CP2.Application.Dtos
{
    public class FornecedorDto : IFornecedorDto
    {

        public string Nome { get; set; } = string.Empty;
        public string CNPJ { get; set; } = string.Empty;
        public string Telefone { get; set; }= string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public DateTime CriadoEm { get; set; } 

        public void Validate()
        {
            var validateResult = new FornecedorDtoValidation().Validate(this);

            if (!validateResult.IsValid)
                throw new Exception(string.Join(" e ", validateResult.Errors.Select(x => x.ErrorMessage)));
        }
    }

    internal class FornecedorDtoValidation : AbstractValidator<FornecedorDto>
    {
        public FornecedorDtoValidation()
        {
            RuleFor(f => f.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .Length(2, 100).WithMessage("O nome deve ter entre 2 e 100 caracteres.");

            RuleFor(f => f.CNPJ)
                .NotEmpty().WithMessage("O CNPJ é obrigatório.")
                .Length(14).WithMessage("O CNPJ deve ter 14 caracteres.")
                .Must(IsValidCNPJ).WithMessage("CNPJ inválido.");

            RuleFor(f => f.Telefone)
                .NotEmpty().WithMessage("O telefone é obrigatório.")
                .Matches(@"^\(\d{2}\)\s\d{4,5}-\d{4}$").WithMessage("Formato de telefone inválido. Ex: (XX) XXXXX-XXXX ou (XX) XXXX-XXXX");

            RuleFor(f => f.Email)
                .NotEmpty().WithMessage("O email é obrigatório.")
                .EmailAddress().WithMessage("Formato de email inválido.");

            RuleFor(f => f.Endereco)
                .NotEmpty().WithMessage("O endereço é obrigatório.");

            RuleFor(f => f.CriadoEm)
                .NotEmpty().WithMessage("A data de criação é obrigatória.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("A data de criação não pode ser no futuro.");
        }

        private bool IsValidCNPJ(string cnpj)
        {
            return cnpj.All(char.IsDigit);
        }
    }
}
