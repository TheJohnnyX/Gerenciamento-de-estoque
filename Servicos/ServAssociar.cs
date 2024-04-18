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
    }

    public class ServAssociar : IServAssociar
    {
        private IRepoAssociar _repoAssociar;
        private IServProduto _servProduto;

        private IRepoProduto _repoProduto;
        private IRepoFornecedor _repoFornecedor;

        public ServAssociar(IRepoAssociar repoAssociar, IServProduto servProduto, IRepoProduto repoProduto, IRepoFornecedor repoFornecedor)
        {
            _repoAssociar = repoAssociar;
            _servProduto  = servProduto;

            _repoProduto = repoProduto;
            _repoFornecedor = repoFornecedor;
        }

        public void Inserir(InserirAssociarDTO inserirDto)
        {
            var produto = new Produto();
            var fornecedor = new Fornecedor();
            
            //produto = _repoProduto.BuscarPorId(inserirDto.IdProduto);
            //fornecedor = _repoFornecedor.BuscarPorId(inserirDto.IdFornecedor);

            produto = _servProduto.BuscarPorId(inserirDto.IdProduto);
            fornecedor = _repoFornecedor.BuscarPorId(inserirDto.IdFornecedor);

            var associar = new Associar();
            
            associar.IdProduto = produto.Id;
            associar.IdFornecedor = fornecedor.Id;
            
            _repoAssociar.Inserir(associar);
        }
    }
}
