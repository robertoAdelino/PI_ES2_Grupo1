using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoDeEsterelizacao.Models
{
    public class Posto
    {
        public int PostoId { get; set; }

        [Required(ErrorMessage ="Por favor, introduza um nome")]
        public string Nome { get; set; }

        public ICollection<Horario> Horario { get; set; }
    }
}
