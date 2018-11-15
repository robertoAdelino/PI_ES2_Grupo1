﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoDeEsterelizacao.Models
{
    public class DiretorServico
    {
        [Required(ErrorMessage = "Introduza o um ColaboradorId válido")]
        [StringLength(5, MinimumLength = 1)]
        public int DiretorServicoID { get; set; }

        [Required(ErrorMessage = "Introduza o um Nome válido")]
        [StringLength(5, MinimumLength = 1)]
        public string Nome { get; set; }

        public ICollection<Colaborador> Colaborador { get; set; }
    }
}