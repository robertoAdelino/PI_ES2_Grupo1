﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoDeEsterelizacao.Models
{
    public class Equipamento
    {
        public int EquipamentoID { get; set; }

        [Required(ErrorMessage ="Insira a capacidade do equipamento")]
        [RegularExpression(@"([1-9999]+)", ErrorMessage = "Introduza uma quantidade válida")]
        public int Capacidade { get; set; }

        public int TipoID { get; set; }

        public Tipo Tipo { get; set; }

        public ICollection<Trabalho_Posto> Esterilizar { get; set; }

    }
}
