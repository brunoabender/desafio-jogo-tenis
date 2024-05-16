using ApprovalTests.Reporters;
using ApprovalTests;
using Xunit;

namespace Tenis.Teste.Aceitacao
{

    [Collection("RecursoCompartilhado")]
    public class ConsoleTests
    {

        [Fact]
        [UseReporter(typeof(DiffReporter))]
        public void DevePontuarParaCadaJogadorEFinalizar()
        {
            // Arrange
            var writer = new StringWriter();
            Console.SetOut(writer);

            // Simular a entrada do usuário: 1 para pontuar o primeiro jogador, 2 para pontuar o segundo jogador, "exit" para sair
            var input = new StringReader("1\n2\nsaida\n");
            Console.SetIn(input);

            // Act
            Program.Main();

            // Assert
            var output = writer.ToString();
            Approvals.Verify(output);
        }

        [Fact]
        [UseReporter(typeof(DiffReporter))]
        public void DeveMostrarDeuceEFinalizar()
        {
            // Arrange
            var writer = new StringWriter();
            Console.SetOut(writer);

            var input = new StringReader("1\n1\n1\n2\n2\n2\nsaida\n");
            Console.SetIn(input);

            // Act
            Program.Main();

            // Assert
            var output = writer.ToString();
            Approvals.Verify(output);
        }
    }
}
