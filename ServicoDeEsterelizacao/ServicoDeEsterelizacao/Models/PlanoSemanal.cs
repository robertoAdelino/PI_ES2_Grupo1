using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServicoDeEsterelizacao.Models
{
    public class PlanoSemanal
    {
        public int IdPlano { get; set; }

        public int ID { get; set; } 
               
        public string funcao { get; set; }

        public DateTime data { get; set; }

        public string tarefa { get; set; }
    }


}

