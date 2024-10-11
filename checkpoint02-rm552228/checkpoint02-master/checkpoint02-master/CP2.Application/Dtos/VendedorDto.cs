using CP2.Domain.Interfaces.Dtos;
using FluentValidation;

namespace CP2.Application.Dtos
{
    public class VendedorDto : IVendedorDto
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataContratacao { get; set; }
        public decimal ComissaoPercentual { get; set; }
        public decimal MetaMensal { get; set; }


        public void Validate()
        {
            var validateResult = new VendedorDtoValidation().Validate(this);

            if (!validateResult.IsValid)
                throw new Exception(string.Join(" e ", validateResult.Errors.Select(x => x.ErrorMessage)));
        }
    }

    internal class VendedorDtoValidation : AbstractValidator<VendedorDto>
    {
        public VendedorDtoValidation()
        {
            RuleFor(v => v.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .Length(2, 100).WithMessage("O nome deve ter entre 2 e 100 caracteres.");

            RuleFor(v => v.Telefone)
                .NotEmpty().WithMessage("O telefone é obrigatório.")
                .Matches(@"^\(\d{2}\)\s\d{4,5}-\d{4}$").WithMessage("Formato de telefone inválido. Ex: (XX) XXXXX-XXXX ou (XX) XXXX-XXXX");

            RuleFor(v => v.Email)
                .NotEmpty().WithMessage("O email é obrigatório.")
                .EmailAddress().WithMessage("Formato de email inválido.");

            RuleFor(v => v.Endereco)
                .NotEmpty().WithMessage("O endereço é obrigatório.");

            RuleFor(v => v.CriadoEm)
                .NotEmpty().WithMessage("A data de criação é obrigatória.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("A data de criação não pode ser no futuro.");

            RuleFor(v => v.DataNascimento)
                .NotEmpty().WithMessage("A data de nascimento é obrigatória.")
                .LessThan(DateTime.Now).WithMessage("A data de nascimento deve ser uma data passada.");

            RuleFor(v => v.DataContratacao)
                .NotEmpty().WithMessage("A data de contratação é obrigatória.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("A data de contratação não pode ser no futuro.")
                .GreaterThan(v => v.DataNascimento).WithMessage("A data de contratação deve ser posterior à data de nascimento.");

            RuleFor(v => v.ComissaoPercentual)
                .InclusiveBetween(0, 100).WithMessage("O percentual de comissão deve estar entre 0 e 100.");

            RuleFor(v => v.MetaMensal)
                .GreaterThan(0).WithMessage("A meta mensal deve ser maior que zero.");
        }
    }
}
