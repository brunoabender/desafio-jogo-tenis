using Tenis.Entidade;
using Tenis.Enum;

namespace Tenis.Controlador
{
    internal class Controlador(Partida partida)
    {
        private readonly Partida partida = partida;

        public void Executar(Acao acao)
        {
            switch (acao)
            {
                case Acao.PontuarPrimeiroJogador:
                    partida.Pontuar(partida.PrimeiroJogador);
                    break;
                case Acao.PontuarSegundoJogador:
                    partida.Pontuar(partida.SegundoJogador);
                    break;
                case Acao.NovoJogo:
                    partida.NovoJogo();
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }   
        }
    }
}
