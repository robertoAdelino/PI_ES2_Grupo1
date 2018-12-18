using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoDeEsterelizacao.Models
{
    public class Trabalho_PostoViewList
    {
        public IEnumerable<Trabalho_Posto> Tarefa { get; set; }
        public PagingViewModel Pagination { get; set; }

        [DisplayName("Nome")]
        public string CurrentNome { get; set; }
    }
}
