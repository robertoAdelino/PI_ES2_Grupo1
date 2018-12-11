using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoDeEsterelizacao.Models
{
    public class Escalonamento
    {
        public int EscalonamentoId { get; set; }

        public Horario Horario { get; set; }

        public int HorarioId { get; set; }

        public Regras Regras { get; set; }

        public int RegrasId { get; set; }
    }
}
