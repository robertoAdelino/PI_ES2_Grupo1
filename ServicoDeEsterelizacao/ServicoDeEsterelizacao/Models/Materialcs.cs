using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoDeEsterelizacao.Models
{
    public class Materialcs
    {
        public Maquinas Maquinas { get; set; }
        [Required]
        public int MaterialcsId { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Quantidade { get; set; }

        
}
}
