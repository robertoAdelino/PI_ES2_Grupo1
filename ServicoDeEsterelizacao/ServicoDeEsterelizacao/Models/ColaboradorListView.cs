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

        [DisplayName("Colaborador")]
        public string CurrentColaborador { get; set; }


        [DisplayName("Funcao")]
        public int CurrentFuncao { get; set; }
    }
}
