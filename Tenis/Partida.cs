namespace Tenis
{
    public class Partida
    {
        public Jogador PrimeiroJogador { get; private set; }
        public Jogador SegundoJogador { get; private set; }
        public Jogador ProximoSaque { get; private set; }
        public Modo Modo { get; set; } = Modo.Normal;

        public Partida(Jogador primeiroJogador, Jogador segundoJogador)
        {
            PrimeiroJogador = primeiroJogador;
            SegundoJogador = segundoJogador;
            ProximoSaque = new Random().Next(0, 2) == 0 ? primeiroJogador : segundoJogador;
        }

        public void Pontuar(Jogador jogador)
        {
            jogador.Pontuacao.AdicionarPonto();
            if (jogador.Pontuacao.Pontos == Configuracoes.UltimoPontoGame)
            {
                PontuarGame(jogador);
            }
        }

        private void PontuarGame(Jogador jogador)
        {
            jogador.Game.AdicionarGame();
            if (jogador.Game.Games == Configuracoes.UltimoGameDoSet)
                PontuarSet(jogador);
            
            LimparPontuacao();
            SelecionarProximoSaque();
        }

        private void PontuarSet(Jogador jogador)
        {
            jogador.Set.AdicionarSet();
            if (jogador.Set.Sets == Configuracoes.UltimoSet)
            {
                Console.WriteLine($"{jogador.Nome} venceu a partida!");
                Environment.Exit(0); // Pode ser substituído por um evento ou outra sinalização
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

        private void SelecionarProximoSaque()
        {
            ProximoSaque = (ProximoSaque == PrimeiroJogador) ? SegundoJogador : PrimeiroJogador;
        }

        public void NovoJogo()
        {
            PrimeiroJogador = new Jogador { Nome = "Primeiro Jogador" };
            SegundoJogador = new Jogador { Nome = "Segundo Jogador" };
        }
    }
}