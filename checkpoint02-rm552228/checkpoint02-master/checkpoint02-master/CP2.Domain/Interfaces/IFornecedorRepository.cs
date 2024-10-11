using CP2.Domain.Entities;

namespace CP2.Domain.Interfaces
{
    public interface IFornecedorRepository
    {

        IEnumerable<FornecedorEntity> ObterTodos();
        FornecedorEntity? ObterPorId(int id);
        FornecedorEntity? SalvarDados(FornecedorEntity entity);
        FornecedorEntity? DeletarDados(int id);
        FornecedorEntity? EditarDadosFornecedor(FornecedorEntity entity);
    }
}
