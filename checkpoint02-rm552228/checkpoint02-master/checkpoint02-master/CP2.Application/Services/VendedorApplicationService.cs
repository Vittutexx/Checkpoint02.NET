using CP2.Domain.Entities;
using CP2.Domain.Interfaces;
using CP2.Domain.Interfaces.Dtos;

namespace CP2.Application.Services
{
    public class VendedorApplicationService : IVendedorApplicationService
    {
        private readonly IVendedorRepository _repository;

        public VendedorApplicationService(IVendedorRepository repository)
        {
            _repository = repository;
        }
        public VendedorEntity? DeletarDadosVendedor(int id)
        {
            return _repository.DeletarDados(id);
        }

        public VendedorEntity? EditarDadosVendedor(int id, IVendedorDto entity)
        {
            entity.Validate();
            return _repository.EditarDadosVendedor(new VendedorEntity
            {
                Id = id,
                Nome = entity.Nome,
                Telefone = entity.Telefone,
                Email = entity.Email,
                Endereco = entity.Endereco,
                CriadoEm = entity.CriadoEm,
                DataNascimento = entity.DataNascimento,
                DataContratacao = entity.DataContratacao,
                ComissaoPercentual = entity.ComissaoPercentual,
                MetaMensal = entity.MetaMensal,

            });
        }

        public IEnumerable<VendedorEntity> ObterTodosVendedores()
        {
            return _repository.ObterTodos();
        }

        public VendedorEntity? ObterVendedorPorId(int id)
        {
            return _repository.ObterPorId(id);
        }

        public VendedorEntity? SalvarDadosVendedor(IVendedorDto entity)
        {
            throw new Exception();
        }
    }
}
