using Entidades;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicos
{
    public interface IServAssociar
    {
        void Inserir(InserirAssociarDTO inserirDto);

        //void Efetivar(int id);
    }

    public class ServAssociar : IServAssociar
    {
        private IRepoAssociar _repoAssociar;
        private IServProduto _servProduto;

        public ServAssociar(IRepoAssociar repoAssociar, IServProduto servProduto)
        {
            _repoAssociar = repoAssociar;
            _servProduto  = servProduto;
        }

        public void Inserir(InserirAssociarDTO inserirDto)
        {
            //var associar = new Associar();

            //associar.IdProduto = inserirDto.IdProduto;
            //associar.IdFornecedor = inserirDto.IdFornecedor;

            //_repoAssociar.Inserir(associar);
            
            //_servAssociar.AtualizarInformacoesDaPromocao(associar.IdProduto, associar.IdFornecedor);
            
            //_repoPromover.SalvarEfetivacao();
        }

        //public void Efetivar(int id)
        //{
        //   var promover = _repoPromover.BuscarPorId(id);
        //
        //    promover.Status = EnumStatusPromover.Efetivado;
        //
        //    _servPizzaria.AtualizarInformacoesDaPromocao(promover.CodigoPizzaria, promover.DataVigencia, promover.Valor);
        //
        //    _repoPromover.SalvarEfetivacao();
        //}
    }
}
