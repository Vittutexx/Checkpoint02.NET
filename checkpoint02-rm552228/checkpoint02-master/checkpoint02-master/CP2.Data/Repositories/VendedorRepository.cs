using CP2.Data.AppData;
using CP2.Domain.Entities;
using CP2.Domain.Interfaces;

namespace CP2.Data.Repositories
{
    public class VendedorRepository : IVendedorRepository
    {
        private readonly ApplicationContext _context;

        public VendedorRepository(ApplicationContext context)
        {
            _context = context;
        }

        public VendedorEntity? DeletarDados(int id)
        {
            var entity = _context.Vendedor.Find(id);
            if (entity != null)
            {
                _context.Vendedor.Remove(entity);
                _context.SaveChanges();

                return entity;
            }

            return null;
        }

        public VendedorEntity EditarDadosVendedor(VendedorEntity vendedorEntity)
        {
            var vendedor = _context.Vendedor.Find(vendedorEntity.Id);
            if (vendedor != null)
            {
                vendedor.Nome = vendedorEntity.Nome;
                vendedor.Telefone = vendedorEntity.Telefone;
                vendedor.Email = vendedorEntity.Email;
                vendedor.Endereco = vendedorEntity.Endereco;
                vendedor.CriadoEm = vendedorEntity.CriadoEm;
                vendedor.DataNascimento = vendedorEntity.DataNascimento;
                vendedor.DataContratacao = vendedorEntity.DataContratacao;
                vendedor.ComissaoPercentual = vendedorEntity.ComissaoPercentual;
                vendedor.MetaMensal = vendedorEntity.MetaMensal;

                _context.SaveChanges();

                return vendedor;
            }
            return null;
        }

        public VendedorEntity? ObterPorId(int id)
        {
            var vendedor = _context.Vendedor.Find(id);
            if (vendedor != null)
            {
                return vendedor;
            }

            return null;

        }

        public IEnumerable<VendedorEntity>ObterTodos()
        {
            return _context.Vendedor.ToList();
        }

        public VendedorEntity? SalvarDados(VendedorEntity entity)
        {

            _context.Vendedor.Add(entity);
            _context.SaveChanges();

            return entity;
        }


    }
}
