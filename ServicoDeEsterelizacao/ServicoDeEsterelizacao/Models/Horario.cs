using System.Collections.Generic;

namespace ServicoDeEsterelizacao.Models
{
    public class Horario
    {

        public int HorarioID { get; set; }

        public int Data { get; set; }

        public ICollection<Colaborador> colaborador { get; set; }

        public Colaborador Colaborador { get; set; }
       
    }
}