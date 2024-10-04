using JogoGourmet;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Linq;
using System.Windows;


namespace JogoGournet
{
    public class Jogo
    {

        private List<Prato> _listaPratos;
        private List<TipoPrato> _listaTipos;

        public void Iniciar()
        {
            //Cria uma lista com os pratos
            MontarPratos();

            while (System.Windows.MessageBox.Show("Pense em um prato que gosta", "Jogo Gourmet", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                //Inicio do jogo
                Perguntar(_listaTipos);
            }
            
        }

        private void Perguntar(List<TipoPrato> listaTipos)
        {
            var pergunta = "O prato que voce pensou é";

            //percorre os tipos de pratos existentes
            for (int index = 0; index < listaTipos.Count; index++)
            {
                //identifica o tipo de prato
                var tipoPrato = listaTipos[index];

                //Verifica se acertou o tipo de prato
                if (System.Windows.MessageBox.Show($"{pergunta} {tipoPrato._tipoPrato} ?", "Jogo gourmet", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    VerificarPratos(listaTipos[index]);
                    break;
                }
                else if ((index + 1) == listaTipos.Count)
                {
                    UltimoPrato();
                    break;
                }
            }
        }        

        private void UltimoPrato() 
        {
            if (PerguntarPrato(_listaPratos[1]))
            {
                System.Windows.MessageBox.Show("Acertei de Novo", "Jogo Gourmet");                
            }
            else { AdicionarPrato();}
        }

        private void VerificarPratos(TipoPrato tipoPrato)
        {
            //Filtra os pratos com o mesmo tipo de prato
            List<Prato> pratos = _listaPratos.FindAll(t => t.tipoPrato != null && t.tipoPrato._tipoPrato == tipoPrato._tipoPrato);

            for (int index = 0; index < pratos.Count; index++)
            {
                //Pergunta se é o prato correto
                if (PerguntarPrato(pratos[index]))
                {
                    System.Windows.MessageBox.Show("Acertei de Novo", "Jogo Gourmet");
                    break;
                }    

                if (index+1 == pratos.Count)
                {
                    AdicionarPrato();
                    break;              
                }
            }

        }

        public bool PerguntarPrato(Prato pPrato)
        {
            //Verifica se acertou o tipo de prato
            return (System.Windows.MessageBox.Show($"O prato que voce pensou é {pPrato.nomePrato} ?", "Jogo gourmet", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes ? true : false);
        }

        private void AdicionarPrato()
        {
            //interação com as 2 perguntas necessárias para adição de novo prato
            var pratoUsuario = Interaction.InputBox("Desisto. Qual prato você pensou ?", "Prato");
            string tipoPratoUsuario = Interaction.InputBox("Complete:" + $"{pratoUsuario ?? "null"} é _______ mas {_listaPratos[1].nomePrato} não.", "Tipo de Prato");


            if (!_listaTipos.Any(t => t._tipoPrato == tipoPratoUsuario))
            {
                TipoPrato novoTipo = new TipoPrato(tipoPratoUsuario);
                _listaTipos.Add(novoTipo);
                _listaPratos.Add(new Prato(pratoUsuario, novoTipo));
            }
            else
            {
                _listaPratos.Add(new Prato(pratoUsuario, _listaTipos.Find(t => t._tipoPrato == tipoPratoUsuario)));
            }            
        }

        private void MontarPratos()
        {
            //Cria lista para os pratos e tipos
            _listaTipos = new List<TipoPrato>(); 
            _listaPratos = new List<Prato>();

            //Cria o tipo Massa e prato Lasanha
            var tipoPrato = new TipoPrato("massa");
            var Prato = new Prato("Lasanha", tipoPrato);

            //Adiciona nas listas
            _listaTipos.Add(tipoPrato);
            _listaPratos.Add(Prato);

            Prato = new Prato("Bolo de Chocolate", null);
            _listaPratos.Add(Prato);
        }


    }
}
