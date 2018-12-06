
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoDeEsterelizacao.Models
{
    public class Regras
    {
        public int RegrasID { get; set; }

        [Required(ErrorMessage ="Dê um nome à regra.")]
        public string Nome { get; set; }

        [Required (ErrorMessage ="Descreva a regra.")]
        public string descricao { get; set; }

        //public ICollection<Escalonamento> Escalonamento { get; set; }
    }
}
