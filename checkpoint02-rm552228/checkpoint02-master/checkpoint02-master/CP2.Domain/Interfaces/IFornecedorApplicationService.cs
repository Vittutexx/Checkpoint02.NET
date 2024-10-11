using CP2.Domain.Entities;
using CP2.Domain.Interfaces.Dtos;

namespace CP2.Domain.Interfaces
{
    public interface IFornecedorApplicationService
    {
        IEnumerable<FornecedorEntity> ObterTodosFornecedores();
        FornecedorEntity? ObterFornecedorPorId(int id);
        FornecedorEntity? DeletarDadosFornecedor(int id);
        FornecedorEntity? SalvarDadosFornecedor(IFornecedorDto entity);
        FornecedorEntity? EditarDadosFornecedor(int id, IFornecedorDto entity);
 
    }

}
