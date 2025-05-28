using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;

public class TelaEmprestimo : TelaBase
{
    private RepositorioEmprestimo repositorioEmprestimoa;

    public TelaEmprestimo(RepositorioEmprestimo repositorioEmprestimo)
        : base("Emprestimo", repositorioEmprestimo)
    {
        this.repositorioEmprestimoa = this.repositorioEmprestimoa;
    }

    public override void VisualizarRegistros(bool exibirCabecalho)
    {
        if (exibirCabecalho == true)
            ExibirCabecalho();

        Console.WriteLine("Visualização de Emprestimos");

        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -20} | {2, -30} | {3, -15} | {3, -15}",
            "Id", "Amigo", "Revista", "data do empréstimo", "data da devolução"
        );

        EntidadeBase[] revista = repositorioEmprestimoa.SelecionarRegistros();

        for (int i = 0; i < revista.Length; i++)
        {
            Emprestimo R = (Emprestimo)revista[i];

            if (R == null)
                continue;

            Console.WriteLine(
               "{0, -10} | {1, -20} | {2, -30} | {3, -15} | {3, -15}",
                R.id, R.amigo, R.revista, R.dataEmprestimo, R.dataDevolucao
            );
        }

        Console.ReadLine();
    }

    protected override Emprestimo ObterDados()
    {
        Console.Write("Digite o nome do Amigo: ");
        string amigo = Console.ReadLine();

        Console.Write("Digite o nome da Revista : ");
        string revista = Console.ReadLine();

         Console.Write("Digite a data do emprestimo: ");
        string dataEmprestimo = Console.ReadLine();

         Console.Write("Digite a data de devolução: ");
        string dataDevolucao = Console.ReadLine();
       
        Emprestimo emprestimo = new Emprestimo(amigo, revista, dataEmprestimo, dataDevolucao);

        return Emprestimo;
    }
}
