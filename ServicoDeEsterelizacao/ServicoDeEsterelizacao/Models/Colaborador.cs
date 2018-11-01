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

        public ICollection<Horario> Horario { get; set; }

        public Horario horario;
    }
}
