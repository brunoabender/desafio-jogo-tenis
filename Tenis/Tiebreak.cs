namespace Tenis
{
    internal class Tiebreak
    {
        public bool Ativo(int gamesJogadorUm, int gamesJogadorDois) => (gamesJogadorUm == Configuracoes.GameTiebreak && gamesJogadorDois == Configuracoes.GameTiebreak);
    }
}
