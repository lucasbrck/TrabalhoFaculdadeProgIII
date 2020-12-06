using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleVendas.Models
{
    public class ClienteDao
    {
        public ClienteDao()
        {
        }

        private static IList<ClienteModel> clientes = new List<ClienteModel>()
        {
            new ClienteModel()
        };

        public async Task<ClienteModel> setCliente(ClienteModel cliente)
        {
            clientes.Add(cliente);
            return cliente;
        }

        public IList<ClienteModel> getCliente()
        {
            return clientes;
        }
    }
}
