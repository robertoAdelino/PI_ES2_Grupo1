using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoDeEsterelizacao.Models
{
    public class Maquinas
    {
        [Required]
        public int MaquinasId { get; set; }
        [Required]
        public string Capacidade { get; set; }
        [Required]
        public string Quantidade { get; set; }

        public ICollection<Materialcs> Materialcs { get; set; }

    }
}
