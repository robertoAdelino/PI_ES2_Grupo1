using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoDeEsterelizacao.Models
{
    public class NomeEquipamento
    {
        public int NomeEquipamentoID { get; set; }

        [Required(ErrorMessage = "Nome não expecificado")]
        [StringLength(50, MinimumLength = 5)]
        public string Nome { get; set; }

        public ICollection<Equipamento> Equipamento { get; set; }
    }
}
