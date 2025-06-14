﻿using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa;

 public class TelaCaixa : TelaBase
{
    private RepositorioRevista repositorioRevista;
    public TelaCaixa(RepositorioCaixa repositorioAmigo, RepositorioRevista repositorioRevista)
        : base ("Caixa", repositorioAmigo)
    {
        this.repositorioRevista = repositorioRevista;
    }
    public override void CadastrarRegistro()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("------------------------------------------");
        Console.WriteLine($"             Cadastro de {nomeEntidade}");
        Console.Write("------------------------------------------");
        Console.ResetColor();

        Console.WriteLine();

        Caixa novoRegistro = (Caixa)ObterDados();

        string erros = novoRegistro.Validar();

        if (erros.Length > 0)
        {
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(erros);
            Console.ResetColor();

            Console.Write("\nDigite ENTER para continuar...");
            Console.ReadLine();

            CadastrarRegistro();

            return;
        }

        EntidadeBase[] registros = repositorio.SelecionarRegistros();

        for (int i = 0; i < registros.Length; i++)
        {
            Caixa caixaRegistrado = (Caixa)registros[i];

            if (caixaRegistrado == null)
                continue;

            if (caixaRegistrado.Etiqueta == novoRegistro.Etiqueta)
            {

                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Uma etiqueta com este nome já foi cadastrada!");
                Console.ResetColor();

                Console.Write("\nDigite ENTER para continuar...");
                Console.ReadLine();

                CadastrarRegistro();
                return;
            }
        }

        repositorio.CadastrarRegistro(novoRegistro);

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("------------------------------------------");
        Console.WriteLine($"\n{nomeEntidade} cadastrado com sucesso!");
        Console.Write("------------------------------------------");
        Console.WriteLine("\nDigite ENTER para continuar...");
        Console.Write("------------------------------------------");
        Console.ReadLine();
        Console.ResetColor();
    }
    public override void VisualizarRegistros(bool exibirCabecalho)
    {
        if (exibirCabecalho == true)
            ExibirCabecalho();

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("------------------------------------------");
        Console.WriteLine("Visualização de Caixas");
        Console.WriteLine("------------------------------------------");

        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -20} | {2, -15} | {3, -15}",
            "Id", "Eiqueta", "Cor", "Dias de empréstimo"
        );

        EntidadeBase[] caixa = repositorio.SelecionarRegistros();

        for (int i = 0; i < caixa.Length; i++)
        {
            Caixa C = (Caixa)caixa[i];

            if (C == null)
                continue;

            Console.WriteLine(
               "{0, -10} | {1, -20} | {2, -15} | {3, -15}",
                C.Id, C.Etiqueta, C.Cor, C.DiasEmprestimo
            );
        }
        Console.WriteLine();
        Console.Write("------------------------------------------");
        Console.WriteLine("\nDigite ENTER para continuar...");
        Console.Write("------------------------------------------");
        Console.ReadLine();
        Console.ResetColor();
        Console.Clear();
    }
    protected override Caixa ObterDados()
    {
        Console.Write("Digite a etiqueta da Caixa: ");
        string Etiqueta = Console.ReadLine();
        Console.WriteLine("------------------------------------------");

        Console.Write("Digite a cor da caixa: ");
        string Cor = Console.ReadLine();
        Console.WriteLine("------------------------------------------");

        Console.Write("Digite o tempo do empréstimo (opcional): ");
        int DiasEmprestimo = Convert.ToInt32 (Console.ReadLine());
        Console.WriteLine("------------------------------------------");

        Caixa caixa = new Caixa(Etiqueta, Cor, DiasEmprestimo);

        return caixa;
    }
}
