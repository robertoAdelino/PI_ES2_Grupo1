using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoDeEsterelizacao.Models
{
    public class Filhos
    {
        public string FilhosID { get; set; }

        public string Nome { get; set; }

        public string idade { get; set; }

        public ICollection<Colaborador> pai { get; set; }
    }
}
