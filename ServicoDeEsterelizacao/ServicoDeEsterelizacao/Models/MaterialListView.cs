using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoDeEsterelizacao.Models
{
    public class MaterialListView
    {
        public IEnumerable<Materialcs> Materialcs { get; set; }
        public PagingViewModel Pagination { get; set; }

        [DisplayName("Material")]
        public string CurrentMaterial { get; set; }
    }
}
