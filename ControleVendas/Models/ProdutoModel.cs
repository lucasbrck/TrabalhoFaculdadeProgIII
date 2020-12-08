using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleVendas.Models
{
    public class ProdutoModel
    {
        public long? ProdutoModelId { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public double PrecoUnit { get; set; }
        public int Estoque { get; set; }
        public ICollection<PedidoProduto> PedidoProdutos { get; set; }

        public ProdutoModel()
        {

        }

    }
}
