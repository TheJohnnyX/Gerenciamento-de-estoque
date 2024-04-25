using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Vender
    {
        public int Id { get; set; }

        public int IdProduto { get; set; }

        public int IdFornecedor { get; set; }

        public decimal Quantidade { get; set; }

        public decimal Valor { get; set; }

        public Associar Associar { get; set; }
    }
}