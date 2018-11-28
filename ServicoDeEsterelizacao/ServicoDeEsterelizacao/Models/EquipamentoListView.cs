using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoDeEsterelizacao.Models
{
    public class EquipamentoListView
    {
        public IEnumerable<Equipamento> Equipamento { get; set; }
        public PagingViewModel Pagination { get; set; }

        [DisplayName("Equipamento")]
        public string CurrentEquipamento { get; set; }
    }
}
