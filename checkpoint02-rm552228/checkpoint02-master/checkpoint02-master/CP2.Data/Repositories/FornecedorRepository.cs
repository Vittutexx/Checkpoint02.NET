using CP2.Data.AppData;
using CP2.Domain.Entities;
using CP2.Domain.Interfaces;

namespace CP2.Data.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly ApplicationContext _context;

        public FornecedorRepository(ApplicationContext context)
        {
            _context = context;
        }

        public FornecedorEntity DeletarDados(int id)
        {
         var entity = _context.Fornecedor.Find(id);
            if (entity != null)
            {
                _context.Fornecedor.Remove(entity);
                _context.SaveChanges();

                return entity;
            }

            return null;
        }

        public FornecedorEntity ObterPorId(int id)
        {
            var fornecedor = _context.Fornecedor.Find(id);
            if (fornecedor != null)
            {
                return fornecedor;
            }

            return null;

        }

        public IEnumerable<FornecedorEntity> ObterTodos()
        {
            var fornecedor = _context.Fornecedor.ToList();
            return fornecedor;
        }

        public FornecedorEntity SalvarDados(FornecedorEntity entity)
        {
           _context.Fornecedor.Add(entity);
            _context.SaveChanges();

            return entity;
        }
        public FornecedorEntity EditarDadosFornecedor(FornecedorEntity entity)
        
        {
            var fornecedor = _context.Fornecedor.Find(entity.Id);
            if (fornecedor != null)
            {
                fornecedor.Nome = entity.Nome;
                fornecedor.CNPJ = entity.CNPJ;
                fornecedor.Email = entity.Email;
                fornecedor.Telefone = entity.Telefone;
                fornecedor.Endereco = entity.Endereco;
                fornecedor.CriadoEm = entity.CriadoEm;

                _context.Fornecedor.Update(fornecedor);
                _context.SaveChanges();
                return fornecedor;

            }

            return null;
        }
            
           

  
    }
}
