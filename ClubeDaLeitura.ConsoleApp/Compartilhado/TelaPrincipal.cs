using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
//using ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace ClubeDaLeitura.ConsoleApp.Compartilhado;

public class TelaPrincipal
{
    private char opcaoEscolhida;

    private ModuloRevista.RepositorioAmigo RepositorioAmigo;
    private ModuloCaixa.RepositorioCaixa RepositorioCaixa;
    private RepositorioRevista RepositorioRevista;

    private TelaAmigo telaAmigo;
    private TelaCaixa telaCaixa;
    private TelaRevista telaRevista;

    public TelaPrincipal()
    {
        RepositorioAmigo = new ModuloRevista.RepositorioAmigo();
        RepositorioCaixa = new ModuloCaixa.RepositorioCaixa();
        RepositorioRevista = new RepositorioRevista();

        telaAmigo = new TelaAmigo(RepositorioAmigo);
        telaCaixa = new TelaCaixa(RepositorioCaixa);

       
    }

    public void ApresentarMenuPrincipal()
    {
        Console.Clear();

        Console.WriteLine("----------------------------------------");
        Console.WriteLine("|        Gestão de Equipamentos        |");
        Console.WriteLine("----------------------------------------");

        Console.WriteLine();

        Console.WriteLine("1 - Controle de Amigos");
        Console.WriteLine("2 - Controle de Caixas");
        Console.WriteLine("3 - Controle de Revistas");
        Console.WriteLine("S - Sair");

        Console.WriteLine();

        Console.Write("Escolha uma das opções: ");
        opcaoEscolhida = Console.ReadLine()[0];
    }

    public TelaBase ObterTela()
    {
        if (opcaoEscolhida == '1')
            return telaAmigo;

        else if (opcaoEscolhida == '2')
            return  telaCaixa;

        else if (opcaoEscolhida == '3')
            return telaRevista;

        return null;
    }
}