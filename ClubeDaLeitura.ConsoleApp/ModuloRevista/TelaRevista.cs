using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista;

public class TelaRevista : TelaBase
{
    private RepositorioAmigo repositorioRevista;

    public TelaRevista(RepositorioRevista repositorioRevista)
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
            Revista R = (Revista)revista[i];

            if (R == null)
                continue;

            Console.WriteLine(
               "{0, -10} | {1, -20} | {2, -30} | {3, -15}",
                R.id, R.titulo, R.numeroDeEdicao, R.anoDePublicao
            );
        }

        Console.ReadLine();
    }

    protected override Revista ObterDados()
    {
        Console.Write("Digite o nome do Amigo: ");
        string titulo = Console.ReadLine();

        Console.Write("Digite o nome do responsável pelo Amigo: ");
        string numeroDeEdicao = Console.ReadLine();

        Console.Write("Digite o telefone do Amigo: ");
        string anoDePublicao = Console.ReadLine();

        Revista revista = new Revista(titulo, numeroDeEdicao, anoDePublicao);

        return revista;
    }
}
