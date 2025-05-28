using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace ClubeDaLeitura.ConsoleApp.Compartilhado;

public class TelaPrincipal
{
    private char opcaoEscolhida;

    private RepositorioAmigo RepositorioAmigo;
    private RepositorioCaixa RepositorioCaixa;
    private RepositorioRevista RepositorioRevista;

    private RepositorioAmigo repositorioAmigo;
    private TelaEquipamento telaEquipamento;
    private TelaChamado telaChamado;

    public TelaPrincipal()
    {
        RepositorioAmigo = new RepositorioAmigo();
        RepositorioCaixa = new RepositorioCaixa();
        RepositorioCaixa = new RepositorioRevista();

        repositorioAmigo = new TelaAmigo(repositorioFabricante);

        telaEquipamento = new TelaEquipamento(
            repositorioEquipamento,
            repositorioFabricante
        );

        telaChamado = new TelaChamado(repositorioChamado, repositorioEquipamento);
    }

    public void ApresentarMenuPrincipal()
    {
        Console.Clear();

        Console.WriteLine("----------------------------------------");
        Console.WriteLine("|        Gestão de Equipamentos        |");
        Console.WriteLine("----------------------------------------");

        Console.WriteLine();

        Console.WriteLine("1 - Controle de Equipamentos");
        Console.WriteLine("2 - Controle de Chamados");
        Console.WriteLine("3 - Controle de Fabricantes");
        Console.WriteLine("S - Sair");

        Console.WriteLine();

        Console.Write("Escolha uma das opções: ");
        opcaoEscolhida = Console.ReadLine()[0];
    }

    public TelaBase ObterTela()
    {
        if (opcaoEscolhida == '1')
            return telaEquipamento;

        else if (opcaoEscolhida == '2')
            return telaChamado;

        else if (opcaoEscolhida == '3')
            return repositorioAmigo;

        return null;
    }
}