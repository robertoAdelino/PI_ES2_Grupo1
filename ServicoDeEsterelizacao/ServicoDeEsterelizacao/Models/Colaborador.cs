using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.ComponentModel.DataAnnotations;
=======
>>>>>>> MenuPrincipal
using System.Linq;
using System.Threading.Tasks;

namespace ServicoDeEsterelizacao.Models
{
    public class Colaborador
    {
<<<<<<< HEAD
        public int ID { get; set; }

        [Required(ErrorMessage = "Por favor introduza o nome")]
        [StringLength(50, MinimumLength = 3)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor introduza o telefone")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Por favor introduza o E-mail.")]
        [RegularExpression(@"(\w+(\.\w+)*@[a-zA-Z_]+?\.[a-zA-Z]{2,6})",ErrorMessage = "E-mail Inválido.")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string Email { get; set; }

        public string funcao { get; set; }
    }

}

=======
        public int ColaboradorId { get; set; }

        public int Dest { get; set; }

        public string funcao { get; set; }

        public ICollection<Servico> Servico { get; set; }

        public Enfermeiros Enfermeiro { get; set; }

        public int EnfermeiroID { get; set; }

        public AssistenteOperacional AssistenteOperacional { get; set; }

        public int AssisOperID { get; set; }

        public DiretorServico DirServico { get; set; }

        public int DirID { get; set; }
    }
}
>>>>>>> MenuPrincipal
