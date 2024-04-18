using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Associar
    {
        public int Id { get; set; }

        public int IdProduto { get; set; }

        public int IdFornecedor { get; set; }

        public Produto Produto { get; set; }

        public Fornecedor Fornecedor { get; set; }
    }
}
