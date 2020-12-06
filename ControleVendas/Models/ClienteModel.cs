using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleVendas.Models
{
    public class ClienteModel
    {

        public long? ClienteModelId { get; set; }
        private string _cpf;
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }


        public ClienteModel()
        {

        }

        public string Cpf 
        {
            get { return _cpf; }
            set
            {
                if(value.Length == 11)
                {
                    _cpf = value;
                }
                
            }
        }
    }
}
