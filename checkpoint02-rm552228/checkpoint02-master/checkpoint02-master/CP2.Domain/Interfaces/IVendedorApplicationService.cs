using CP2.Domain.Entities;
using CP2.Domain.Interfaces.Dtos;

namespace CP2.Domain.Interfaces
{
    public interface IVendedorApplicationService
    {
        IEnumerable<VendedorEntity> ObterTodosVendedores();
        VendedorEntity? ObterVendedorPorId(int id);
        VendedorEntity? DeletarDadosVendedor(int id);
        VendedorEntity? SalvarDadosVendedor(IVendedorDto entity);
        VendedorEntity? EditarDadosVendedor(int id, IVendedorDto entity);

    }
}
