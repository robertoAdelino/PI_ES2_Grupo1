using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoDeEsterelizacao.Models
{
    public class InfoModel
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string password { get; set; }

        [Required]
        public string funcao { get; set; }
    }
}
