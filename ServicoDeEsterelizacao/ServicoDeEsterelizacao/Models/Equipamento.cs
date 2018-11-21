using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoDeEsterelizacao.Models
{
    public class Equipamento
    {
        [Required]
        public string EquipamentoID { get; set; }

        public string Nome { get; set;}

        public int CapacidadeMax { get; set; } = 1000;

        public int CapacidadeMin { get; set; } = 50;

        [Required]
        public int Quantidade { get; set; }

        public Materialcs Material { get; set; }

        public string MaterialcsId { get; set; }
    }
}
