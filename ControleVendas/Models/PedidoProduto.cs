using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleVendas.Models
{
    public class PedidoProduto
    {
        public long? ProdutoModelId { get; set; }
        public ProdutoModel ProdutoModel { get; set; }
        public long? PedidoModelId { get; set; }
        public PedidoModel PedidoModel { get; set; }
    }
}
