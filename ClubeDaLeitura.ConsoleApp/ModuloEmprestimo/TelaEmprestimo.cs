using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista;

public class TelaEmprestimo : TelaBase
{
    private RepositorioAmigo repositorioRevista;

    public TelaEmprestimo(RepositorioEmprestimo repositorioRevista)
        : base("Revista", repositorioRevista)
    {
        this.repositorioRevista = this.repositorioRevista;
    }

    public override void VisualizarRegistros(bool exibirCabecalho)
    {
        if (exibirCabecalho == true)
            ExibirCabecalho();

        Console.WriteLine("Visualização de Revistas");

        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -20} | {2, -30} | {3, -15}",
            "Id", "titulo", "Nome do responsável", "Telefone"
        );

        EntidadeBase[] revista = repositorioRevista.SelecionarRegistros();

        for (int i = 0; i < revista.Length; i++)
        {
            Amigo R = (Amigo)revista[i];

            if (R == null)
                continue;

            Console.WriteLine(
               "{0, -10} | {1, -20} | {2, -30} | {3, -15}",
                R.id, R.titulo, R.numeroDeEdicao, R.anoDePublicao
            );
        }

        Console.ReadLine();
    }

    protected override Amigo ObterDados()
    {
        Console.Write("Digite o nome do Amigo: ");
        string titulo = Console.ReadLine();

        Console.Write("Digite o nome do responsável pelo Amigo: ");
        string numeroDeEdicao = Console.ReadLine();

        Console.Write("Digite o telefone do Amigo: ");
        string anoDePublicao = Console.ReadLine();

        Amigo revista = new Amigo(titulo, numeroDeEdicao, anoDePublicao);

        return revista;
    }
}
