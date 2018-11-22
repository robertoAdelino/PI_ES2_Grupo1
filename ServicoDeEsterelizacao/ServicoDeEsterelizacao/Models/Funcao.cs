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
        [StringLength(50, MinimumLength = 3)]
        public string Nome { get; set; }

         public ICollection<Colaborador> Colaborador { get; set; }

        public static implicit operator Funcao(string v)
        {
            throw new NotImplementedException();
        }
    }
}
