namespace Tenis
{
    internal static class Deuce
    {
        public static bool Ativo(Jogador jogador1, Jogador jogador2) => jogador1.Pontos == 40 && jogador2.Pontos == 40;
        public static bool Resolvido(Jogador jogador1, Jogador jogador2) => Math.Abs(jogador1.Pontos - jogador2.Pontos) == 2;
    }
}
