using Tenis.Configuracao;
using Tenis.Enum;

namespace Tenis.Entidade
{
    public class Partida(Jogador primeiroJogador, Jogador segundoJogador)
    {
        public Jogador PrimeiroJogador { get; private set; } = primeiroJogador;
        public Jogador SegundoJogador { get; private set; } = segundoJogador;
        public Jogador ProximoSaque { get; private set; } = new Random().Next(0, 2) == 0 ? primeiroJogador : segundoJogador;
        public Modo Modo { get; set; } = Modo.Normal;

        public void Pontuar(Jogador jogador)
        {
            jogador.Pontuacao.Adicionar();

            Modo = VerificarModoJogo();

            if (jogador.Pontuacao.Pontos == Configuracoes.UltimoPontoGame)
                PontuarGame(jogador);
        }

        private void PontuarGame(Jogador jogador)
        {
            jogador.Game.Adicionar();

            if (PrimeiroJogador.Game.Games == Configuracoes.UltimoGameDoSet - 1 && SegundoJogador.Game.Games == Configuracoes.UltimoGameDoSet - 1)
            {
                if (Math.Abs(PrimeiroJogador.Game.Games - SegundoJogador.Game.Games) == 2)
                    PontuarSet(jogador);

                LimparPontuacao();
                return;
            }

            if (jogador.Game.Games == Configuracoes.UltimoGameDoSet)
                PontuarSet(jogador);

            LimparPontuacao();
            SelecionarProximoSaque();
        }

        private void PontuarSet(Jogador jogador)
        {
            jogador.Set.Adicionar();
            if (jogador.Set.Sets == Configuracoes.UltimoSet)
            {
                Console.WriteLine($"{jogador.Nome} venceu a partida!");
                Environment.Exit(0);
            }
            else
            {
                LimparPontuacao();
                LimparGames();
            }
        }

        private void LimparPontuacao()
        {
            PrimeiroJogador.Pontuacao.Resetar();
            SegundoJogador.Pontuacao.Resetar();
        }

        private void LimparGames()
        {
            PrimeiroJogador.Game.Resetar();
            SegundoJogador.Game.Resetar();
        }

        public void NovoJogo()
        {
            PrimeiroJogador = new Jogador("Primeiro Jogador");
            SegundoJogador = new Jogador("Segundo Jogador");
        }
        private void SelecionarProximoSaque() => ProximoSaque = ProximoSaque == PrimeiroJogador ? SegundoJogador : PrimeiroJogador;

        private Modo VerificarModoJogo()
        {
            if (!Regras.EstaEmDeuce(PrimeiroJogador, segundoJogador) && Regras.EstaEmTimeBreak(PrimeiroJogador, SegundoJogador))
                return Modo.TieBreak;
            
            if(Regras.EstaEmDeuce(PrimeiroJogador, segundoJogador) && !Regras.EstaEmTimeBreak(PrimeiroJogador, SegundoJogador))
                return Modo.Deuce;
            
            return Modo.Normal;
        }
    }
}