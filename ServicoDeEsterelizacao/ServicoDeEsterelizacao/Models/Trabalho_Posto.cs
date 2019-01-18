using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoDeEsterelizacao.Models
{
    public class Trabalho_Posto
    {
        public int Trabalho_PostoID { get; set; }

        public Equipamento Equipamento { get; set; }

        public int EquipamentoID { get; set; }

        public Materialcs Materialcs { get; set; }

        public int MaterialcsID { get; set; }

        [Required(ErrorMessage ="Estado não inidcado")]
        public string Estado{ get; set; }

        public Horario Horario { get; set; }

        public int HorarioID { get; set; }

        [Required(ErrorMessage ="Data não indicada")]
        [DataType(DataType.DateTime, ErrorMessage = "Data inválida")]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime DataServico { get; set; }
    }
}
