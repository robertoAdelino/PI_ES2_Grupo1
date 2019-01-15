using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServicoDeEsterelizacao.Models
{
    public class Horario
    {
        public int HorarioID { get; set; }

        [Required(ErrorMessage ="Data não indicada")]
        [DataType(DataType.Date, ErrorMessage = "Data inválida")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime DataInicioManha { get; set; }
        public DateTime DataFimManha { get; set; }
        public DateTime DataInicioTarde { get; set; }
        public DateTime DataFimTarde { get; set; }

        public Turno Turno { get; set; }

        public int TurnoId { get; set; }

        public Posto Posto { get; set; }

        public int PostoId { get; set; }

        public Colaborador Colaborador { get; set; }

        public int ColaboradorId { get; set; }

        public ICollection<Trabalho_Posto> TrabalhoPosto { get; set; }
    }
}