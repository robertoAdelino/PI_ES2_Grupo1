using System;
using System.Collections.Generic;

namespace ServicoDeEsterelizacao.Models
{
    public class Horario
    {
        public int HorarioID { get; set; }

        public System.DateTime data { get; set; }

        public ICollection<Escalonamento> Escalonamento { get; set; }

        //public ICollection<Servico> Servico {get; set;}

        public Turno Turno { get; set; }

        public int TurnoId { get; set; }

        public Posto Posto { get; set; }

        public int PostoId { get; set; }

        public Colaborador Colaborador { get; set; }

        public int ColaboradorId { get; set; }
    }
}