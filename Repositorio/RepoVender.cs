using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public interface IRepoVender
    {
        void Inserir(Vender vender);
        List<Vender> BuscarTodos();
        Vender BuscarPorId(int id);
        void Remover(Vender vender);
    }

    public class RepoVender : IRepoVender
    {
        private DataContext _dataContext;

        public RepoVender(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Inserir(Vender vender)
        {
            _dataContext.Add(vender);

            _dataContext.SaveChanges();
        }

        public List<Vender> BuscarTodos()
        {
            var vender = _dataContext.Vender.ToList();

            return vender;
        }

        public Vender BuscarPorId(int id)
        {
            var vender = _dataContext.Vender.Where(p => p.Id == id).FirstOrDefault();

            return vender;
        }

        public void Remover(Vender vender)
        {
            _dataContext.Remove(vender);

            _dataContext.SaveChanges();
        }

    }
}