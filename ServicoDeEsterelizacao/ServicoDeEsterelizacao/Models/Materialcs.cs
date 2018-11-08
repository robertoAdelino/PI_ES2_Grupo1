using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoDeEsterelizacao.Models
{
    public class Materialcs
    {
        [Required]
        public int IDMaterial { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public int Quantidade { get; set; }
    }
}
