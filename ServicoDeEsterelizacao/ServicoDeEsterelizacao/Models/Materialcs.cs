using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoDeEsterelizacao.Models
{
    public class Materialcs
    {
        [Required(ErrorMessage = "ID necessário")]
        public int MaterialcsId { get; set; }
        [Required(ErrorMessage = "Por favor, introduza o nome.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Por favor, introduza a quantidade.")]
        public int Quantidade { get; set; }
    }
}
