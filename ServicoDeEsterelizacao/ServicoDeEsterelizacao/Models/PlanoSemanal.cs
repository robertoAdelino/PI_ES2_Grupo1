using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoDeEsterelizacao.Models
{
    public class PlanoSemanal
    {
        public int IdPlano { get; set; }

        [Required(ErrorMessage = "Por favor introduza o nome")]
        [StringLength(50, MinimumLength = 3)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor introduza o telefone")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Por favor introduza o E-mail.")]
        
        public string Email { get; set; }

        public string Funcao { get; set; }
    }


}

