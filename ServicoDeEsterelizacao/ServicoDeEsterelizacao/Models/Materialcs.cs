using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoDeEsterelizacao.Models
{
    public class Materialcs
    {
        /*[Required(ErrorMessage ="Id não especificado")]
        [StringLength(2,MinimumLength =1,ErrorMessage ="ID inválido!!{1,99}")]*/
        public string MaterialcsId { get; set; }

        [Required(ErrorMessage ="Nome não especificado")]
        [StringLength(100,MinimumLength =1,ErrorMessage ="Nome inválido!!!{tam min:1;tam max:100}")]
        public string Nome { get; set; }

        [Required]
        public int Quantidade { get; set; }

        [Required]
        public ICollection<Esterelizar> Esterelizar { get; set; }
    }
}
