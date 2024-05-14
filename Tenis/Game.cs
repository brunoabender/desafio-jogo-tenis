namespace Tenis
{
    public class Game
    {
        public int Games { get; private set; } = 0;

        public void AdicionarGame()
        {
            Games++;
        }

        public void Resetar()
        {
            Games = 0;
        }
    }
}