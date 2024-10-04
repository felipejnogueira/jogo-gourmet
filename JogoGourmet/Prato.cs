using JogoGourmet;

namespace JogoGournet
{
    public class Prato
    {
        public Prato(string pPrato, TipoPrato pTipoPrato) {
            nomePrato = pPrato;
            tipoPrato = pTipoPrato;
        }

        public TipoPrato tipoPrato { get; set; }
        public string nomePrato { get; set; }
    }
}
