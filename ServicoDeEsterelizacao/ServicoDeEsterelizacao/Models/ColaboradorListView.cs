using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoDeEsterelizacao.Models
{
    public class ColaboradorListView
    {
        public IEnumerable<Colaborador> Colaborador { get; set; }
        public PagingViewModel Pagination { get; set; }
        public IEnumerable<Colaborador> Colaborador1 { get; set; }
        [DisplayName("Colaborador")]
        public string CurrentColaborador { get; set; }


        [DisplayName("Funcao")]
        public string CurrentFuncao { get; set; }
    }
}
