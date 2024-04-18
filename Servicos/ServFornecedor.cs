using Entidades;
using Repositorio;

namespace Servicos
{
    public interface IServFornecedor
    {
        void Inserir(InserirFornecedorDTO inserirFornecedorDto);
        void Editar(int id, EditarFornecedorDTO editarFornecedorDto);
        List<Fornecedor> BuscarTodos();
        Fornecedor BuscarPorId(int id);
        void Remover(int id);
    }

    public class ServFornecedor : IServFornecedor
    {
        private IRepoFornecedor _repoFornecedor;

        public ServFornecedor(IRepoFornecedor repoFornecedor)
        {
            _repoFornecedor = repoFornecedor;
        }

        public void Inserir(InserirFornecedorDTO inserirFornecedorDto)
        {
            var fornecedor = new Fornecedor();

            fornecedor.Nome = inserirFornecedorDto.Nome;
            fornecedor.Descricao = inserirFornecedorDto.Descricao;
            fornecedor.Valor = inserirFornecedorDto.Valor;

            //ValidacoesAntesDeInserir(produto);

            _repoFornecedor.Inserir(fornecedor);
        }

        //public void ValidacoesAntesDeInserir(Pizzaria pizzaria)
        //{
        //    if (pizzaria.Nome.Length < 40)
        //    {
        //        throw new Exception("Nome inválido. Deve possuir no mínimo 40 caracteres.");
        //    }
        //}

        public void Editar(int id, EditarFornecedorDTO editarFornecedorDto)
        {
            var fornecedor = _repoFornecedor.BuscarPorId(id);

            fornecedor.Nome = editarFornecedorDto.Nome;
            fornecedor.Descricao = editarFornecedorDto.Descricao;
            fornecedor.Valor = editarFornecedorDto.Valor;

            _repoFornecedor.Editar(fornecedor);
        }

        public List<Fornecedor> BuscarTodos()
        {
            var fornecedor = _repoFornecedor.BuscarTodos();

            return fornecedor;
        }

        public Fornecedor BuscarPorId(int id)
        {
            var fornecedor = _repoFornecedor.BuscarPorId(id);

            return fornecedor;
        }

        public void Remover(int id)
        {
            var fornecedor = _repoFornecedor.BuscarTodos().Where(p => p.Id == id).FirstOrDefault();

            _repoFornecedor.Remover(fornecedor);
        }
    }
}
