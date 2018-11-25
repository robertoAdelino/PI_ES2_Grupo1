using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoDeEsterelizacao.Models
{
    public class Tipo
    {
        public int TipoID { get; set; }

        [Required(ErrorMessage ="Porfavor insira o nome")]
        public string Nome { get; set; }

        public ICollection<Equipamento> Equipamento { get; set; }
    }
}
