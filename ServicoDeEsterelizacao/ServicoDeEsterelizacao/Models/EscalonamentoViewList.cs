using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoDeEsterelizacao.Models
{
    public class EscalonamentoViewList
    {
        public IEnumerable<Escalonamento> Escalonamento { get; set; }
        public PagingViewModel Pagination { get; set; }

        [DisplayName("Horario")]
        public string CurrentHorario { get; set; }
    }
}
