using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa;

 public class TelaCaixa : TelaBase
{
    private RepositorioCaixa repositorioCaixa;

    public TelaCaixa(RepositorioCaixa repositorioAmigo)
        : base ("Caixa", repositorioAmigo)
    {
        this.repositorioCaixa = repositorioCaixa;
    }

    public override void VisualizarRegistros(bool exibirCabecalho)
    {
        if (exibirCabecalho == true)
            ExibirCabecalho();

        Console.WriteLine("Visualização de Caixas");

        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -20} | {2, -30} | {3, -15}",
            "Id", "Eiqueta", "Cor", "Dias de empréstimo"
        );

        EntidadeBase[] caixa = repositorioCaixa.SelecionarRegistros();

        for (int i = 0; i < caixa.Length; i++)
        {
            Caixa C = (Caixa)caixa[i];

            if (C == null)
                continue;

            Console.WriteLine(
               "{0, -10} | {1, -20} | {2, -30} | {3, -15}",
                C.id, C.etiqueta, C.cor, C.diasDeEmprestimo
            );
        }

        Console.ReadLine();
    }

    protected override Caixa ObterDados()
    {
        Console.Write("Digite a etiqueta da Caixa: ");
        string etiqueta = Console.ReadLine();

        Console.Write("Digite a cor da caixa: ");
        string cor = Console.ReadLine();

        Console.Write("Digite o tempo do empréstimo: ");
        string diasDeEmprestimo = Console.ReadLine();

        Caixa caixa = new Caixa(etiqueta, cor, diasDeEmprestimo);

        return caixa;
    }
}
