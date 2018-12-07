using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoDeEsterelizacao.Models
{
    public class Esterilizar
    {
        public int EsterilizarID { get; set; }

        public Equipamento Equipamento { get; set; }

        public int EquipamentoID { get; set; }

        public Materialcs Materialcs { get; set; }

        public int MaterialcsID { get; set; }

        public ICollection<Servico> Servico { get; set; }
    }
}
