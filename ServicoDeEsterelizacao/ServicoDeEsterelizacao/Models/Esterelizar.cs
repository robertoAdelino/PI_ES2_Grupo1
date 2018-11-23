using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoDeEsterelizacao.Models
{
    public class Esterelizar
    {
        public int EsterelizarID { get; set; }

        public Equipamento Equipamento { get; set; }

        public int EquipamentoID { get; set; }

        public Materialcs Materialcs { get; set; }

        public int MaterialcsID { get; set; }
    }
}
