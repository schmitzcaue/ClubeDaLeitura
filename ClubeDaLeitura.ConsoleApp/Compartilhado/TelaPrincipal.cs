using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;

namespace ClubeDaLeitura.ConsoleApp.Compartilhado;

public class TelaPrincipal
{
    private char opcaoEscolhida;

    private ModuloAmigo.RepositorioAmigo RepositorioAmigo;
    private ModuloCaixa.RepositorioCaixa RepositorioCaixa;
    private ModuloRevista.RepositorioRevista RepositorioRevista;
    private ModuloEmprestimo.RepositorioEmprestimo RepositorioEmprestimo;

    private TelaAmigo telaAmigo;
    private TelaCaixa telaCaixa;
    private TelaRevista telaRevista;
    private TelaEmprestimo telaEmprestimo;

    public TelaPrincipal()
    {
        RepositorioAmigo = new RepositorioAmigo();
        RepositorioCaixa = new RepositorioCaixa();
        RepositorioRevista = new RepositorioRevista();
        RepositorioEmprestimo = new RepositorioEmprestimo();

        telaAmigo = new TelaAmigo(RepositorioAmigo);
        telaCaixa = new TelaCaixa(RepositorioCaixa);
        telaRevista = new TelaRevista(RepositorioRevista, RepositorioCaixa);
        telaEmprestimo = new TelaEmprestimo(RepositorioEmprestimo, RepositorioAmigo, RepositorioRevista);

       
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
        Console.WriteLine("4 - Controle de Emprestimo");
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

        else if (opcaoEscolhida == '4')
            return telaEmprestimo;

        return null;
    }
}