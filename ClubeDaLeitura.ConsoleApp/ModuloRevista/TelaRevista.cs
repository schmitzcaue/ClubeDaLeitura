using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista;

public class TelaRevista : TelaBase
{
    private RepositorioRevista repositorioRevista;
    private RepositorioCaixa repositorioCaixa;

    public TelaRevista(RepositorioRevista repositorioRevista, RepositorioCaixa repositorioCaixa) : base("Revista", repositorioRevista)
    {
        this.repositorioRevista = repositorioRevista;
        this.repositorioCaixa = repositorioCaixa;
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

    public void VisualizarCaixas()
    {
        Console.WriteLine();

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


    protected override Revista ObterDados()
    {
       
        Console.Write("Digite o título: ");
        string titulo = Console.ReadLine();

        Console.Write("Digite o numero da Edição: ");
        int numeroDeEdicao = Convert.ToInt32(Console.ReadLine());

        Console.Write("Digite o ano de publicação: ");
        DateTime anoDePublicao = DateTime.Parse(Console.ReadLine());

        VisualizarCaixas();

        Console.Write("Digite o id da Caixa: ");
        int idCaixa = Convert.ToInt32(Console.ReadLine());


        Caixa CaixaSelecionado = (Caixa)repositorioCaixa.SelecionarRegistroPorId(idCaixa);

        //Revista revista = new Revista(titulo, numeroDeEdicao, anoDePublicao);
        Revista revista = new Revista(titulo, numeroDeEdicao, anoDePublicao, CaixaSelecionado);

        return revista;
    }
}
