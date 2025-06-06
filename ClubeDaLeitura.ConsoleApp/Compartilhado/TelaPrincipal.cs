using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;
using ClubeDaLeitura.ConsoleApp.ModuloReserva;

namespace ClubeDaLeitura.ConsoleApp.Compartilhado;

public class TelaPrincipal
{
    private char opcaoEscolhida;

    private ModuloAmigo.RepositorioAmigo RepositorioAmigo;
    private ModuloCaixa.RepositorioCaixa RepositorioCaixa;
    private ModuloRevista.RepositorioRevista RepositorioRevista;
    private ModuloEmprestimo.RepositorioEmprestimo RepositorioEmprestimo;
    private ModuloReserva.RepositorioReserva RepositorioReserva;

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
        RepositorioReserva = new RepositorioReserva();

        telaAmigo = new TelaAmigo(RepositorioAmigo, RepositorioEmprestimo);
        telaCaixa = new TelaCaixa(RepositorioCaixa, RepositorioRevista);
        telaRevista = new TelaRevista(RepositorioRevista, RepositorioCaixa);
        telaEmprestimo = new TelaEmprestimo(RepositorioEmprestimo, RepositorioAmigo, RepositorioRevista);

       
    }

    public void ApresentarMenuPrincipal()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("|        Clube da leitura              |");
        Console.WriteLine("----------------------------------------");
        Console.ResetColor();

        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("1 - Controle de Amigos");
        Console.WriteLine("2 - Controle de Caixas");
        Console.WriteLine("3 - Controle de Revistas");
        Console.WriteLine("4 - Controle de Emprestimo");
        Console.WriteLine("5 - Controle de Reservas");
        Console.WriteLine("S - Sair");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();
        Console.Write("Escolha uma das opções: ");
        opcaoEscolhida = Console.ReadLine()[0];
        Console.ResetColor();

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

         //else if (opcaoEscolhida == '5')
           // return telaReserva;

        return null;
    }
}