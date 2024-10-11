using CP2.Domain.Entities;
using CP2.Domain.Interfaces;
using CP2.Domain.Interfaces.Dtos;

namespace CP2.Application.Services
{
    public class FornecedorApplicationService : IFornecedorApplicationService
    {
        private readonly IFornecedorRepository _repository;

        public FornecedorApplicationService(IFornecedorRepository repository)
        {
            _repository = repository;
        }

        public FornecedorEntity? DeletarDadosFornecedor(int id)
        {
            return _repository.DeletarDados(id);
        }

        public FornecedorEntity? EditarDadosFornecedor(int id, IFornecedorDto entity)
        {
            entity.Validate();
            return _repository.EditarDadosFornecedor(new FornecedorEntity
            {
                Id = id,
                Nome = entity.Nome,
                CNPJ = entity.CNPJ,
                Telefone = entity.Telefone,
                Email = entity.Email,
                Endereco = entity.Endereco,
                CriadoEm = entity.CriadoEm


            });
        }

     

        public FornecedorEntity? ObterFornecedorPorId(int id)
        {
            return _repository.ObterPorId(id);
        }
        public IEnumerable<FornecedorEntity> ObterTodosFornecedores()
        {
            return _repository.ObterTodos();
        }

        public FornecedorEntity? SalvarDadosFornecedor(IFornecedorDto entity)
        {
            entity.Validate();
            return _repository.SalvarDados(new FornecedorEntity
            {
                Nome = entity.Nome,
                CNPJ = entity.CNPJ,
                Telefone = entity.Telefone,
                Email = entity.Email,
                Endereco = entity.Endereco,
                CriadoEm = entity.CriadoEm
            });
        }
        
    }
}
