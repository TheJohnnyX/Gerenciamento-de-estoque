﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class InserirVenderDTO
    {
        public int IdProduto { get; set; }

        public int IdFornecedor { get; set; }

        public decimal Quantidade { get; set; }
    }
}
