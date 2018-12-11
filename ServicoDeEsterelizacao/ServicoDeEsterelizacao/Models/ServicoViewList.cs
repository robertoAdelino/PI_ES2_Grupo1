using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoDeEsterelizacao.Models
{
    public class ServicoViewList
    {
        public IEnumerable<Servico> Equipamento { get; set; }
        public PagingViewModel Pagination { get; set; }

        [DisplayName("Colbaborador")]
        public string CurrentColaborador { get; set; }
    }
}
