using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoDeEsterelizacao.Models
{
    public class Turno
    {
        public int TurnoId { get; set; }

        [Required(ErrorMessage = "Por favor, insira um nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, introduza a data de inicio")]
        [DataType(DataType.Date, ErrorMessage = "Data de inicio inválida")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime Horainicio { get; set; }

        [Required(ErrorMessage = "Por favor, introduza a data de fim")]
        [DataType(DataType.Date, ErrorMessage = "Data de fim inválida")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime Horafim { get; set; }

        public ICollection<Horario> Horario { get; set; }
    }
}
