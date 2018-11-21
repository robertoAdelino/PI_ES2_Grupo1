using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoDeEsterelizacao.Models
{
    public class Colaborador
    {

        public int ColaboradorId { get; set; }

        public int FuncaoID { get; set; }

        public Funcao Funcao { get; set; }

        [Required(ErrorMessage = "Por favor introduza o nome")]
        [RegularExpression(@"([A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ\s]+)", ErrorMessage = "Introduza um nome válido")]
        [StringLength(50, MinimumLength = 3)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor introduza o telefone")]
        [RegularExpression(@"(2\d{8})|(9[1236]\d{7})", ErrorMessage = "Contacto inválido")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Por favor introduza o E-mail.")]
        [EmailAddress(ErrorMessage = "Email inválido")]

        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor introduza a morada.")]
        public string Morada { get; set; }

        [Required(ErrorMessage = "Por favor, introduza a data de nascimento")]
        [DataType(DataType.Date, ErrorMessage = "Data de nascimento inválida")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime DataNasc { get; set; }


        [Required]
        public bool? Filhos { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Data de nascimento inválida")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime? DataNascFilho { get; set; }

        [Required(ErrorMessage = "Por favor, introduza o nº de CC/BI")]
        [RegularExpression(@"(\d{8}\s\d{1}[A-Z0-9]{2}\d{1})", ErrorMessage = "Nº de CC/BI inválido")]
        public string Cc { get; set; }






    }

}


       
