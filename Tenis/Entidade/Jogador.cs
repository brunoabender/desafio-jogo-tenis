using Tenis.Entidade;

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
        public Pontuacao Pontuacao { get; set; } = new Pontuacao(0);
        public Game Game { get; set; } = new Game(0);
        public Set Set { get; set; } = new Set(0);
    }
}