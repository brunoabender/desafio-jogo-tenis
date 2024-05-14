namespace Tenis
{
    internal class Partida(Jogador primeiroJogador, Jogador segundoJogador)
    {
        public Jogador PrimeiroPlayer { get; set; } = primeiroJogador;
        public Jogador SegundoPlayer { get; set; } = segundoJogador;

        private Jogador ProximoSaque = Random.Shared.Next(0, 1) == 0 ? primeiroJogador : segundoJogador;

        private readonly Placar placar = new(primeiroJogador, segundoJogador);

        public void Pontuar(Jogador jogador)
        {
            jogador.Pontos++;

            if (RegraVantagem.Ativo(PrimeiroPlayer.Pontos, SegundoPlayer.Pontos))
            {
                if (RegraVantagem.Resolvido(PrimeiroPlayer.Pontos, PrimeiroPlayer.Pontos))
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

            PrimeiroPlayer.Pontos = 0;
            SegundoPlayer.Pontos = 0;

            ProximoSaque = (ProximoSaque == PrimeiroPlayer) ? SegundoPlayer : PrimeiroPlayer;
        }

        private void PontuarSet(Jogador jogador)
        {
            var set = jogador.Sets + 1;
            jogador.Sets++;

            if (set == Configuracoes.UltimoSet)
            {
                Console.WriteLine($"{jogador.Nome} venceu a partida!");
                Environment.Exit(0);
            }
            else
            {
                PrimeiroPlayer.Pontos = 0;
                PrimeiroPlayer.Games = 0;
                SegundoPlayer.Pontos = 0;
                SegundoPlayer.Games = 0;
            }
        }

        public void NovoJogo()
        {
            this.PrimeiroPlayer = new Jogador { Nome = "Primeiro Jogador" };
            this.SegundoPlayer = new Jogador { Nome = "Segundo Jogador" };
        }
    }
}