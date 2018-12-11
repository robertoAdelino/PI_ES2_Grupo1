using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoDeEsterelizacao.Models
{
    public class HorarioViewList
    {
        public IEnumerable<Horario> Horario { get; set; }
        public PagingViewModel Pagination { get; set; }

        [DisplayName("Colaborador")]
        public string CurrentColaborador { get; set; }
    }
}
