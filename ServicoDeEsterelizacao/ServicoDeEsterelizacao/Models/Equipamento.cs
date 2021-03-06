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
        [GreaterThanZero(ErrorMessage = "Insira Capacidade positiva")]
        public int Capacidade { get; set; }

        public int TipoID { get; set; }

        public Tipo Tipo { get; set; }

        public ICollection<Trabalho_Posto> Esterilizar { get; set; }

    }
}
