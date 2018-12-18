using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoDeEsterelizacao.Models
{
    public class Materialcs
    {
        public int MaterialcsId { get; set; }
        [Required(ErrorMessage = "Por favor, introduza o nome.")]
        [RegularExpression(@"([A-Za-záàâãéèêíïóôõöúçñÁÀÂÃÉÈÍÏÓÔÕÖÚÇÑ\s]+)", ErrorMessage = "Introduza um nome válido")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Nome invalido!!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Por favor, introduza a quantidade.")]
        [RegularExpression(@"([1-9999]+)", ErrorMessage = "Introduza uma quantidade válida")]
        public int Quantidade { get; set; }

        public ICollection<Trabalho_Posto> Esterilizar { get; set; }
    }
}
