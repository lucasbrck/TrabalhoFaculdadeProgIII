using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ControleVendas.Models
{
    public class PedidoModel
    {
        [Key]
        public long? PedidoModelId { get; set; }
        public string Codigo { get; set; }
        public DateTime Data { get; set; }
        public double Valor { get; set; }
        public long? ProdutoModelId { get; set; }
        public ICollection<PedidoProduto> PedidoProdutos { get; set; }
        [ForeignKey("Cliente")]
        public long? ClienteModelId { get; set; }
        public virtual ClienteModel Cliente { get; set; }

    }
}
