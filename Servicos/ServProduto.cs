using Entidades;
using Repositorio;

namespace Servicos
{
    public interface IServProduto
    {
        void Inserir(InserirProdutoDTO inserirProdutoDto);
        void Editar(int id, EditarProdutoDTO editarProdutoDto);
        List<Produto> BuscarTodos();
        Produto BuscarPorId(int id);
        void Remover(int id);
    }

    public class ServProduto : IServProduto
    {
        private IRepoProduto _repoProduto;

        public ServProduto(IRepoProduto repoProduto)
        {
            _repoProduto = repoProduto;
        }

        public void Inserir(InserirProdutoDTO inserirProdutoDto)
        {
            var produto = new Produto();

            produto.Nome = inserirProdutoDto.Nome;
            produto.Descricao = inserirProdutoDto.Descricao;
            produto.Valor = inserirProdutoDto.Valor;

            //ValidacoesAntesDeInserir(produto);

            _repoProduto.Inserir(produto);
        }

        //public void ValidacoesAntesDeInserir(Pizzaria pizzaria)
        //{
        //    if (pizzaria.Nome.Length < 40)
        //    {
        //        throw new Exception("Nome inválido. Deve possuir no mínimo 40 caracteres.");
        //    }
        //}

        public void Editar(int id, EditarProdutoDTO editarProdutoDto)
        {
            var produto = _repoProduto.BuscarPorId(id);

            produto.Nome = editarProdutoDto.Nome;
            produto.Descricao = editarProdutoDto.Descricao;
            produto.Valor = editarProdutoDto.Valor;

            _repoProduto.Editar(produto);
        }

        public List<Produto> BuscarTodos()
        {
            var produtos = _repoProduto.BuscarTodos();

            return produtos;
        }

        public Produto BuscarPorId(int id)
        {
            var produto = _repoProduto.BuscarPorId(id);

            return produto;
        }


        public void Remover(int id)
        {
            var produto = _repoProduto.BuscarTodos().Where(p => p.Id == id).FirstOrDefault();

            _repoProduto.Remover(produto);
        }
    }
}
