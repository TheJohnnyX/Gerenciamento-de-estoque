using Entidades;
using Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicos
{
    public interface IServVender
    {
        void Inserir(InserirVenderDTO inserirDto);

        List<Vender> BuscarTodos();

        void Remover(int id);
    }

    public class ServVender : IServVender
    {
        private IRepoVender _repoVender;

        private IRepoAssociar _repoAssociar;
        private IServAssociar _servAssociar;
        private IRepoProduto _repoProduto;
        private IServProduto _servProduto;

        public ServVender(IRepoVender repoVender, IRepoAssociar repoAssociar, IServAssociar servAssociar, IRepoProduto repoProduto, IServProduto servProduto)
        {
            _repoVender   = repoVender;
            _repoAssociar = repoAssociar;
            _servAssociar = servAssociar;
            _repoProduto  = repoProduto;
            _servProduto  = servProduto;
        }

        public void Inserir(InserirVenderDTO inserirDto)
        {
            var vender = new Vender();
            var associar_query = new Associar();

            associar_query.IdProduto = inserirDto.IdProduto;
            associar_query.IdFornecedor = inserirDto.IdFornecedor;

            //Buscar por IdProduto e IdFornecedor em associar

            var associar = new Associar();
            associar = _servAssociar.BuscarAssociacao(associar_query);

            try
            {
                vender.IdProduto = associar.IdProduto;
                vender.IdFornecedor = associar.IdFornecedor;
            }
            catch (Exception)
            {
                throw new Exception("Associação não encontrada");
            }

            var produto = new Produto();
            produto = _servProduto.BuscarPorId(inserirDto.IdProduto);

            try
            {
                vender.Valor = produto.Valor;
            }
            catch (Exception)
            {
                throw new Exception("Valor não encontrado");
            }

            vender.Quantidade = inserirDto.Quantidade;
            vender.Associar = associar;

            _repoVender.Inserir(vender);
        }

        public List<Vender> BuscarTodos()
        {
            var vender = _repoVender.BuscarTodos();

            return vender;
        }

        public void Remover(int id)
        {
            var vender = _repoVender.BuscarTodos().Where(p => p.Id == id).FirstOrDefault();

            _repoVender.Remover(vender);
        }
    }
}
