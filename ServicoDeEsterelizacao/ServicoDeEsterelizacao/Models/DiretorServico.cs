using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoDeEsterelizacao.Models
{
    public class DiretorServico
    {
        public int DiretorServicoID { get; set; }

        public string Nome { get; set; }

        public ICollection<Colaborador> Colaborador { get; set; }
    }
}
