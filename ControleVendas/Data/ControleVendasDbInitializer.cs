using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleVendas.Data
{
    public class ControleVendasDbInitializer
    {
        public static void Initialize(ControleVendasContext context) 
        {
            context.Database.EnsureCreated();
        }
    }
}
