using System.Collections.Generic;

public class Jogador
{
    public string Nome { get; set; }
    public Pontuacao Pontuacao { get; set; } = new Pontuacao();
    public Game Game { get; set; } = new Game();
    public Set Set { get; set; } = new Set();
}

public class Game
{
    public int Games { get; private set; }

    public void AdicionarGame()
    {
        Games++;
    }

    public void Resetar()
    {
        Games = 0;
    }
}

public class Pontuacao
{
    public int Pontos { get; private set; }

    public void AdicionarPonto()
    {
        Pontos++;
    }

    public void Resetar()
    {
        Pontos = 0;
    }
}