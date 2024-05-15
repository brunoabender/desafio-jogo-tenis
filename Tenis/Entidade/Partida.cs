using Tenis.Comum;
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

            if(Modo == Modo.TieBreak && PrimeiroJogador.Pontuacao.Pontos >= Configuracoes.GameTiebreak || SegundoJogador.Pontuacao.Pontos >= Configuracoes.GameTiebreak)
            {
                if (CalculoDiferenca.PermitirPontuar(PrimeiroJogador.Pontuacao.Pontos, SegundoJogador.Pontuacao.Pontos))
                {
                    PontuarSet(jogador);
                    Modo = Modo.Normal;
                }
                
                return;
            }   

            if(Modo == Modo.Deuce && CalculoDiferenca.PermitirPontuar(PrimeiroJogador.Pontuacao.Pontos, SegundoJogador.Pontuacao.Pontos))
            {
                PontuarGame(jogador);
                Modo = Modo.Normal;   
            }

            if (jogador.Pontuacao.Pontos == Configuracoes.UltimoPontoGame && Modo == Modo.Normal) 
                PontuarGame(jogador);

            if(Modo == Modo.Normal)
                Modo = ObterModoJogo();
        }

        private void PontuarGame(Jogador jogador)
        {
            jogador.Game.Adicionar();

            if (PrimeiroJogador.Game.Games == Configuracoes.UltimoGameDoSet && SegundoJogador.Game.Games == Configuracoes.UltimoGameDoSet)
            {
                if (CalculoDiferenca.PermitirPontuar(PrimeiroJogador.Game.Games, SegundoJogador.Game.Games))
                    PontuarSet(jogador);

                LimparPontuacao();
                return;
            }

            if (jogador.Game.Games == Configuracoes.UltimoGameDoSet && CalculoDiferenca.PermitirPontuar(PrimeiroJogador.Game.Games, SegundoJogador.Game.Games))
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

        private Modo ObterModoJogo()
        {
            if (Regras.AtivarDeuce(PrimeiroJogador, SegundoJogador, Modo.TieBreak))
            {
                LimparPontuacao();
                return Modo.Deuce;
            }
            
            if(Regras.AtivarTieBreak(PrimeiroJogador, SegundoJogador, Modo.Deuce))
            {
                LimparPontuacao();
                return Modo.TieBreak;
            }
            
            return Modo.Normal;
        }
    }
}