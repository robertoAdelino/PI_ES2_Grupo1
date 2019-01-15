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
        [RegularExpression(@"([A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ\s]+)", ErrorMessage = "Introduza um nome válido")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Nome invalido!!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, introduza a data de inicio")]
        [DataType(DataType.Date, ErrorMessage = "Data de inicio inválida")]
        [DisplayFormat(DataFormatString = "{0:hh:mm}", ApplyFormatInEditMode = false)]
        public int HoraInicioManha { get; set; }
        [Required(ErrorMessage = "Este campo não pode estar por preencher")]
        public int HoraFimManha { get; set; }
        [Required(ErrorMessage = "Este campo não pode estar por preencher")]
        public int HoraInicioTarde { get; set; }
        [Required(ErrorMessage = "Este campo não pode estar por preencher")]
        public int HoraFimTarde { get; set; }

        public ICollection<Horario> Horario { get; set; }
    }
}
