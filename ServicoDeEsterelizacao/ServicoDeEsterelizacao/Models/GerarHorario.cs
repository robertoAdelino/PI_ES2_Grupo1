using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoDeEsterelizacao.Models
{
    public class GerarHorario
    {

        [Required(ErrorMessage = "Por favor, introduza o número de pessoas para o turno 1")]
        public int NPessoasT1 { get; set; }

        [Required(ErrorMessage = "Por favor, introduza o número de pessoas para o turno 2")]
        public int NPessoasT2 { get; set; }

        [Required(ErrorMessage = "Por favor, introduza a data de ínicio da semana")]
        [DataType(DataType.Date, ErrorMessage = "Data de início de semana inválida")]
      //  [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime DataInicio { get; set; }
    }
}
