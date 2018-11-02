using System;
using System.Collections.Generic;

namespace ServicoDeEsterelizacao.Models
{
    public class Horario
    {

        public int HorarioID { get; set; }

        public System.DateTime data { get; set; }

        public ICollection<Servico> Servico { get; set; }

    }
}