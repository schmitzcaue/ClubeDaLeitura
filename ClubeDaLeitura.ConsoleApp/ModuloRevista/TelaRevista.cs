using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista;

public class TelaRevista : TelaBase
{
    private RepositorioCaixa repositorioCaixa;

    public TelaRevista(RepositorioRevista repositorioRevista, RepositorioCaixa repositorioCaixa) : base("Revista", repositorioRevista)
    {
        this.repositorioCaixa = repositorioCaixa;
    }

    public override char ApresentarMenu()
    {
        ExibirCabecalho();

        Console.WriteLine($"1 - Cadastro de {nomeEntidade}");
        Console.WriteLine($"2 - Visualizar {nomeEntidade}s");
        Console.WriteLine($"3 - Edição {nomeEntidade}s");
        Console.WriteLine($"4 - Excluir {nomeEntidade}");
        Console.WriteLine($"S - Sair");

        Console.WriteLine();

        Console.Write("Digite uma opção válida: ");
        char opcaoEscolhida = Console.ReadLine().ToUpper()[0];

        return opcaoEscolhida;
    }

    public override void VisualizarRegistros(bool exibirCabecalho)
    {
        if (exibirCabecalho == true)
            ExibirCabecalho();

        Console.WriteLine("Visualização de Revistas");

        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -30} | {2, -20} | {3, -20} | {4, -20} | {5, -20}",
            "Id", "Título", "Edição", "Ano de Publicação", "Caixa", "Status"
        );

        EntidadeBase[] revistas = repositorio.SelecionarRegistros();

        for (int i = 0; i < revistas.Length; i++)
        {
            Revista r = (Revista)revistas[i];

            if (r == null)
                continue;

            Console.WriteLine(
             "{0, -10} | {1, -30} | {2, -20} | {3, -20} | {4, -20} | {5, -20}",
                r.id, r.Titulo, r.NumeroDeEdicao, r.AnoDePublicao, r.Caixa.Etiqueta, r.status
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
                C.id, C.Etiqueta, C.Cor, C.DiasEmprestimo
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

        Revista revista = new Revista(titulo, numeroDeEdicao, anoDePublicao, CaixaSelecionado);

        return revista;
    }
}
