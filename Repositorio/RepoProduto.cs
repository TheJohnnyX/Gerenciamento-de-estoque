using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public interface IRepoProduto
    {
        void Inserir(Produto produto);

        void Editar(Produto produto);
        Produto BuscarPorId(int id);
        List<Produto> BuscarTodos();
        void Remover(Produto produto);
    }
    public class RepoProduto : IRepoProduto
    {
        private DataContext _dataContext;

        public RepoProduto(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Inserir(Produto produto)
        {
            _dataContext.Add(produto);

            _dataContext.SaveChanges();
        }
        public void Editar(Produto produto)
        {
            _dataContext.SaveChanges();
        }

        public List<Produto> BuscarTodos()
        {
            var produtos = _dataContext.Produto.ToList();

            return produtos;
        }

        public Produto BuscarPorId(int id)
        {
            var produto = _dataContext.Produto.Where(p => p.Id == id).FirstOrDefault();

            return produto;
        }

        public void Remover(Produto produto)
        {
            _dataContext.Remove(produto);

            _dataContext.SaveChanges();
        }
    }
}
