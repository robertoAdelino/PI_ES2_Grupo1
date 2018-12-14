using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoDeEsterelizacao.Models
{
    public class Trabalho_Posto
    {
        public int Trabalho_PostoID { get; set; }

        public Equipamento Equipamento { get; set; }

        public int EquipamentoID { get; set; }

        public Materialcs Materialcs { get; set; }

        public int MaterialcsID { get; set; }

        public bool? Estado{ get; set; }

        public Horario Horario { get; set; }

        public int HorarioID { get; set; }

        public DateTime DataServico { get; set; }
    }
}
