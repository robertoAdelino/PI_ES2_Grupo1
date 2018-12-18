using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoDeEsterelizacao.Models
{
    public class Funcao
    {
        public int FuncaoID { get; set; }

        [Required(ErrorMessage = "Por favor introduza a função")]
        [RegularExpression(@"([A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ\s]+)", ErrorMessage = "Introduza um nome válido")]
        [StringLength(50, MinimumLength = 3,ErrorMessage ="Nome inválido!!")]
        public string Nome { get; set; }

         public ICollection<Colaborador> Colaborador { get; set; }

  
    }
}
