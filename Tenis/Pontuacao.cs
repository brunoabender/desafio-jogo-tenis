namespace Tenis
{
    public class Pontuacao
    {
        public int Pontos { get; private set; } = 0;

        public void AdicionarPonto()
        {
            Pontos++;
        }

        public void Resetar()
        {
            Pontos = 0;
        }
    }
}