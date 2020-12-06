using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleVendas.Models
{
    public class ProdutoDao
    {

        public ProdutoDao()
        {
        }

        private static IList<ProdutoModel> produtos = new List<ProdutoModel>()
        {
             new ProdutoModel()
        };

        public async Task<ProdutoModel> setProduto(ProdutoModel produto)
        {
            produtos.Add(produto);
            return produto;
        }

        public IList<ProdutoModel> getProduto()
        {
            return produtos;
        }
    }
}
