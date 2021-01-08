using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroCedulas.Models
{
    public class CaixaEletronico
    {
        public int Id { get; set; }
        public string NumeroCaixa { get; set; }
        public int ValorSaque { get; set; }
        public int CedulaId { get; set; }
        public IEnumerable<Cedula> Cedulas { get; set; }
    }
}
