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
        [StringLength(50, MinimumLength = 3)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor introduza o telefone")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Por favor introduza o E-mail.")]
        [RegularExpression(@"(\w+(\.\w+)*@[a-zA-Z_]+?\.[a-zA-Z]{2,6})",ErrorMessage = "E-mail Inválido.")]

        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor introduza a morada.")]
        public string Morada { get; set; }

        [Required(ErrorMessage = "Por favor introduza a Data de nascimento do filho mais novo.")]
        public DateTime DataNasc { get; set; }

        [Required(ErrorMessage = "Por favor introduza nº cartão de cidadao")]
        public string Cc { get; set; }






    }

}


       
