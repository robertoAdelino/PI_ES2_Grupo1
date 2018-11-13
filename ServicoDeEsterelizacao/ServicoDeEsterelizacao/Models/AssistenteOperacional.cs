using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoDeEsterelizacao.Models
{
    public class AssistenteOperacional
    {
        [Required(ErrorMessage = "Introduza um ColaboradorId válido")]
        [StringLength(5, MinimumLength = 1)]
        public int AssistenteOperacionalID { get; set; }

        [Required(ErrorMessage = "Introduza um Nome válido")]
        [StringLength(5, MinimumLength = 1)]
        public string Nome { get; set; }

        public ICollection<Colaborador> Colaborador { get; set; }
    }
}
