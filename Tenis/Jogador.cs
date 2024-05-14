namespace Tenis
{
    public record Jogador(string Nome)
    {
        public Jogador(string nome, Pontuacao pontuacao, Game game, Set set) : this(nome)
        {
            Pontuacao = pontuacao;
            Game = game;
            Set = set;
        }

        public Pontuacao Pontuacao { get; set; } = new Pontuacao();
        public Game Game { get; set; } = new Game();
        public Set Set { get; set; } = new Set();
    }
}