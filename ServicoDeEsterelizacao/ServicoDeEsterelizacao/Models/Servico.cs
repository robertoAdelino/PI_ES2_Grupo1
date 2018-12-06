namespace ServicoDeEsterelizacao.Models
{
    public class Servico
    {
        public int ServicoID { get; set; }

        public System.DateTime data { get; set; }

        public Colaborador Colaborador { get; set; }

        public int ColaboradorID { get; set; }

        public Horario Horario { get; set; }

        public int HorarioID { get; set; }

        public Esterilizar Esterilizar { get; set; }

        public int EsteriloizarID { get; set; }
    }
}