using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;
using System;
//using ClubeDaLeitura.ConsoleApp.ModuloReserva;

namespace ClubeDaLeitura.ConsoleApp.Compartilhado;

public class TelaPrincipal
{
    private char opcaoEscolhida;

    private ModuloAmigo.RepositorioAmigo repositorioAmigo;
    private ModuloCaixa.RepositorioCaixa repositorioCaixa;
    private ModuloRevista.RepositorioRevista repositorioRevista;
    private ModuloEmprestimo.RepositorioEmprestimo repositorioEmprestimo;
    //private ModuloReserva.RepositorioReserva RepositorioReserva;

    private TelaAmigo telaAmigo;
    private TelaCaixa telaCaixa;
    private TelaRevista telaRevista;
    private TelaEmprestimo telaEmprestimo;

    public TelaPrincipal()
    {
        repositorioAmigo = new RepositorioAmigo();
        repositorioCaixa = new RepositorioCaixa();
        repositorioRevista = new RepositorioRevista();
        repositorioEmprestimo = new RepositorioEmprestimo();
        //RepositorioReserva = new RepositorioReserva();

        telaAmigo = new TelaAmigo(repositorioAmigo, repositorioEmprestimo);
        telaCaixa = new TelaCaixa(repositorioCaixa, repositorioRevista);
        telaRevista = new TelaRevista(repositorioRevista, repositorioCaixa);
        telaEmprestimo = new TelaEmprestimo(repositorioEmprestimo, repositorioAmigo, repositorioRevista);

        Amigo amigo = new Amigo("Tiago", "Rech", "49 99999-3333");
        repositorioAmigo.CadastrarRegistro(amigo);

        Caixa caixa = new Caixa("Quadrinhos", "Azul", 1);
        repositorioCaixa.CadastrarRegistro(caixa);

        Revista revista = new Revista("Superman", 150, 2000, caixa);
        repositorioRevista.CadastrarRegistro(revista);

        Emprestimo emprestimo = new Emprestimo(amigo, revista);
        emprestimo.DataEmprestimo = DateTime.Now.AddDays(-2);

        repositorioEmprestimo.CadastrarRegistro(emprestimo);
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
        //Console.WriteLine("5 - Controle de Reservas");
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