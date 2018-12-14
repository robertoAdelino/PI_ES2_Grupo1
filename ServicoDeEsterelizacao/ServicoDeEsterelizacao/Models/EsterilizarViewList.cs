using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoDeEsterelizacao.Models
{
    public class EsterilizarViewList
    {
        public IEnumerable<Trabalho_Posto> Esterilizar { get; set; }
        public PagingViewModel Pagination { get; set; }

        [DisplayName("Equipamento")]
        public string CurrentEquipamento { get; set; }
    }
}
