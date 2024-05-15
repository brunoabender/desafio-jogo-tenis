namespace Tenis.Entidade
{
    public class Pontuacao
    {
        public Pontuacao(int pontos)
        {
            Pontos = pontos;
        }

        public int Pontos { get; private set; } = 0;
        public void Adicionar() => Pontos++;
        public void Resetar() => Pontos = 0;
    }
}