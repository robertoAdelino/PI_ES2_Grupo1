using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoDeEsterelizacao.Models
{
    public class TurnoViewList
    {
        public IEnumerable<Turno> Turno { get; set; }
        public PagingViewModel Pagination { get; set; }

        [DisplayName("Nome")]
        public string CurrentNome { get; set; }
    }
}
