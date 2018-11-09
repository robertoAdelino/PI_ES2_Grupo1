using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoDeEsterelizacao.Models
{
    public class InfoModel
    {
        [Required(ErrorMessage ="Introduza o seu ID")]
        [StringLength(5,MinimumLength = 1)]
        public int ID { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Introduza a sua password")]
        [StringLength(15, MinimumLength = 1)]
        public string password { get; set; }

        [Required]
        public string funcao { get; set; }

        [Required]
        public string alteracao { get; set; }

        [Required(ErrorMessage = "Introduza uma data inicial válida")]
        public DateTime diaI { get; set; }

        [Required(ErrorMessage = "Introduza uma data final válida")]
        public DateTime diaF { get; set; }

        [Required]
        public string justificacao { get; set; }
    }
}
