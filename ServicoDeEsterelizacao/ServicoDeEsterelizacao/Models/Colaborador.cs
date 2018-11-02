using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoDeEsterelizacao.Models
{
    public class Colaborador
    {
        public int ColaboradorId { get; set; }

        public int Dest { get; set; }

        public string funcao { get; set; }

        public ICollection<Servico> Servico { get; set; }

        public Enfermeiros Enfermeiro { get; set; }

        public int EnfermeiroID { get; set; }

        public AssistenteOperacional AssistenteOperacional { get; set; }

        public int AssisOperID { get; set; }

        public DiretorServico DirServico { get; set; }

        public int DirID { get; set; }
    }
}
