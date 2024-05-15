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

            if(Modo == Modo.TieBreak)
            {
                if(PrimeiroJogador.Pontuacao.Pontos >= Configuracoes.GameTiebreak || SegundoJogador.Pontuacao.Pontos >= Configuracoes.GameTiebreak)
                {
                    if (Math.Abs(PrimeiroJogador.Pontuacao.Pontos - SegundoJogador.Pontuacao.Pontos) >= Configuracoes.MelhorDe)
                    {
                        PontuarGame(jogador);
                        Modo = Modo.Normal;
                    }
                }
                
                return;
            }   

            if(Modo == Modo.Deuce)
            {
                if (Math.Abs(PrimeiroJogador.Pontuacao.Pontos - SegundoJogador.Pontuacao.Pontos) >= Configuracoes.MelhorDe)
                {
                    PontuarGame(jogador);
                    Modo = Modo.Normal;
                }
            }

            if (jogador.Pontuacao.Pontos == Configuracoes.UltimoPontoGame && Modo == Modo.Normal) 
                PontuarGame(jogador);

            Modo = VerificarModoJogo();
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
            if (Regras.AtivarDeuce(PrimeiroJogador, SegundoJogador) && Modo != Modo.TieBreak)
                return Modo.Deuce;
            
            if(Regras.AtivarTieBreak(PrimeiroJogador, SegundoJogador) && Modo != Modo.Deuce)
                return Modo.TieBreak;
            
            return Modo.Normal;
        }
    }
}