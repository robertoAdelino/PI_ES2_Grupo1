﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoDeEsterelizacao.Models
{
    public class Equipamento
    {
        ~/*[Required(ErrorMessage ="ID não expecificado")]
        [StringLength(2,MinimumLength =1)]*/
        public int EquipamentoID { get; set; }


        [Required(ErrorMessage = "Nome não expecificado")]
        [StringLength(100,MinimumLength =3)]
        public string Nome { get; set;}

       /* public int CapacidadeMax = 1000;

        public int CapacidadeMin = 50;*/

        [Required(ErrorMessage ="Quantidade não expecificada")]
        [MaxLength(1000,ErrorMessage ="Quantidade superior à capacidade máxima.")]
        [MinLength(50,ErrorMessage ="Quantidade Insuficiente")]
        public string Quantidade { get; set; }

        public ICollection<Esterelizar> Esterelizar { get; set; }

        public NomeEquipamento NomeEquipamento { get; set; }

        public int NomeEquipamentoID { get; set; }
    }
}
