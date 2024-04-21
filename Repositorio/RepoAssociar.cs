using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public interface IRepoAssociar
    {
        void Inserir(Associar associar);
        Associar BuscarPorId(int id);
        //void SalvarEfetivacao();
        void Remover(Associar associar);
    }

    public class RepoAssociar : IRepoAssociar
    {
        private DataContext _dataContext;

        public RepoAssociar(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Inserir(Associar associar)
        {
            _dataContext.Add(associar);

            _dataContext.SaveChanges();
        }

        public Associar BuscarPorId(int id)
        {
            var associar = _dataContext.Associar.Where(p => p.Id == id).FirstOrDefault();
        
            return associar;
        }

        public void Remover(Associar associar)
        {
            _dataContext.Remove(associar);

            _dataContext.SaveChanges();
        }

    }
}