namespace Tenis
{
    internal class Tiebreak
    {
        public static bool Ativo(int gamesJogadorUm, int gamesJogadorDois) => (gamesJogadorUm == Configuracoes.GameTiebreak && gamesJogadorDois == Configuracoes.GameTiebreak);
    }
}
