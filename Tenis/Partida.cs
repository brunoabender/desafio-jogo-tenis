namespace Tenis
{
    internal class Partida(Jogador primeiroJogador, Jogador segundoJogador)
    {
        public Jogador PrimeiroJogador { get; set; } = primeiroJogador;
        public Jogador SegundoJogador { get; set; } = segundoJogador;
        public Jogador ProximoSaque { get; set; } = Random.Shared.Next(0, 2) == 0 ? primeiroJogador : segundoJogador;
        public ModoJogo modoJogo { get; set; } = ModoJogo.Normal;

        public void Pontuar(Jogador jogador)
        {
            jogador.Pontos++;

            if (RegraVantagem.Ativo(PrimeiroJogador.Pontos, SegundoJogador.Pontos))
            {
                if (RegraVantagem.Resolvido(PrimeiroJogador.Pontos, PrimeiroJogador.Pontos))
                    AdicionarGame(jogador);
                else
                    jogador.Pontos++;

                return;
            }

            if (jogador.Pontos == Configuracoes.UltimoPonto)
                AdicionarGame(jogador);
        }

        private void AdicionarGame(Jogador jogador)
        {
            if (jogador.Games == Configuracoes.UltimoGame)
                PontuarSet(jogador);
            else
                jogador.Games++;

            LimparPontos();
            ProximoSaque = (ProximoSaque == PrimeiroJogador) ? SegundoJogador : PrimeiroJogador;
        }

        private void PontuarSet(Jogador jogador)
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
    }
}