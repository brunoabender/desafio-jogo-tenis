namespace Tenis
{
    public class Partida(Jogador primeiroJogador, Jogador segundoJogador)
    {
        public Jogador PrimeiroJogador { get; set; } = primeiroJogador;
        public Jogador SegundoJogador { get; set; } = segundoJogador;
        public Jogador ProximoSaque { get; set; } = new Random().Next(0, 2) == 0 ? primeiroJogador : segundoJogador;

        public Modo Modo { get; set; } = Modo.Normal;

        public void Pontuar(Jogador jogador)
        {
            jogador.Pontos++;
            if (jogador.Pontos == Configuracoes.UltimoPonto)
                AdicionarGame(jogador);
        }

        public void AdicionarGame(Jogador jogador)
        {
            jogador.Games++;
            if (jogador.Games == Configuracoes.UltimoGame)
                PontuarSet(jogador);

            LimparPontos();
            SelecionarProximoSaque();
        }

        public void PontuarSet(Jogador jogador)
        {
            jogador.Sets++;
            if (jogador.Sets == Configuracoes.UltimoSet)
            {
                Console.WriteLine($"{jogador.Nome} venceu a partida!");
                Environment.Exit(0);
            }
            else
            {
                LimparPontos();
                LimparGame();
            }
        }

        public void NovoJogo()
        {
            PrimeiroJogador = new Jogador { Nome = "Primeiro Jogador" };
            SegundoJogador = new Jogador { Nome = "Segundo Jogador" };
        }

        private void LimparPontos()
        {
            PrimeiroJogador.Pontos = 0;
            SegundoJogador.Pontos = 0;
        }

        private void LimparGame()
        {
            PrimeiroJogador.Games = 0;
            SegundoJogador.Games = 0;
        }

        private void SelecionarProximoSaque() => ProximoSaque = (ProximoSaque == PrimeiroJogador) ? SegundoJogador : PrimeiroJogador;
    }
}