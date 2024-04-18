using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public interface IRepoFornecedor
    {
        void Inserir(Fornecedor fornecedor);
        void Editar(Fornecedor fornecedor);
        List<Fornecedor> BuscarTodos();
        Fornecedor BuscarPorId(int id);
        void Remover(Fornecedor fornecedor);
    }

    public class RepoFornecedor : IRepoFornecedor
    {
        private DataContext _dataContext;

        public RepoFornecedor(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Inserir(Fornecedor fornecedor)
        {
            _dataContext.Add(fornecedor);

            _dataContext.SaveChanges();
        }

        public void Editar(Fornecedor fornecedor)
        {
            _dataContext.SaveChanges();
        }

        public List<Fornecedor> BuscarTodos()
        {
            var fornecedor = _dataContext.Fornecedor.ToList();

            return fornecedor;
        }

        public Fornecedor BuscarPorId(int id)
        {
            var fornecedor = _dataContext.Fornecedor.Where(p => p.Id == id).FirstOrDefault();

            return fornecedor;
        }

        public void Remover(Fornecedor fornecedor)
        {
            _dataContext.Remove(fornecedor);

            _dataContext.SaveChanges();
        }
    }
}
