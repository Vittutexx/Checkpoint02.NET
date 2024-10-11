
namespace CP2.Domain.Interfaces.Dtos
{
    public interface IVendedorDto
    {
        string Nome { get; set; }
        string Telefone { get; set; }
        string Email { get; set; }
        string Endereco { get; set; }
        DateTime CriadoEm { get; set; }
        DateTime DataNascimento { get; set; }
        DateTime DataContratacao { get; set; }
        decimal ComissaoPercentual { get; set; }
        decimal MetaMensal { get; set; }

        void Validate();
    }
}
