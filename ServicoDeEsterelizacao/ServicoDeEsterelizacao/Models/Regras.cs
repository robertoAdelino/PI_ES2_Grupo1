
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoDeEsterelizacao.Models
{
    public class Regras
    {
        public int RegrasID { get; set; }

        [Required(ErrorMessage ="Dê um nome à regra.")]
        [RegularExpression(@"([A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ\s]+)", ErrorMessage = "Introduza uma regra válida")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Regra inválida!!")]
        public string Nome { get; set; }

        [Required (ErrorMessage ="Descreva a regra.")]
        [RegularExpression(@"([A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ\s]+)", ErrorMessage = "Introduza uma descrição válida")]
        [StringLength(10000, MinimumLength = 1, ErrorMessage = "Descrição inválida!!")]
        public string Descricao { get; set; }

       
    }
}
