using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa;

 public class TelaCaixa : TelaBase
{

    public TelaCaixa(RepositorioCaixa repositorioAmigo)
        : base ("Caixa", repositorioAmigo)
    {
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

        EntidadeBase[] caixa = repositorio.SelecionarRegistros();

        for (int i = 0; i < caixa.Length; i++)
        {
            Caixa C = (Caixa)caixa[i];

            if (C == null)
                continue;

            Console.WriteLine(
               "{0, -10} | {1, -20} | {2, -30} | {3, -15}",
                C.id, C.Etiqueta, C.Cor, C.DiasEmprestimo
            );
        }

        Console.ReadLine();
    }

    protected override Caixa ObterDados()
    {
        Console.Write("Digite a etiqueta da Caixa: ");
        string Etiqueta = Console.ReadLine();

        Console.Write("Digite a cor da caixa: ");
        string Cor = Console.ReadLine();

        Console.Write("Digite o tempo do empréstimo: ");
        int DiasEmprestimo = Convert.ToInt32 (Console.ReadLine());

        Caixa caixa = new Caixa(Etiqueta, Cor, DiasEmprestimo);

        return caixa;
    }
}
