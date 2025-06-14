﻿using System;
using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo;

public class TelaAmigo : TelaBase
{
    private RepositorioEmprestimo repositorioEmprestimo;
    public TelaAmigo(RepositorioAmigo repositorio, RepositorioEmprestimo repositorioEmprestimo)
             :   base("Amigo", repositorio)
        {
            this.repositorioEmprestimo = repositorioEmprestimo;
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

        Amigo novoRegistro = (Amigo)ObterDados();

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
            Amigo amigoRegistrado = (Amigo)registros[i];

            if (amigoRegistrado == null)
                continue;

            if (amigoRegistrado.Nome == novoRegistro.Nome || amigoRegistrado.Telefone == novoRegistro.Telefone)
            {
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Um amigo com este nome ou telefone já foi cadastrado!");
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
    public override void EditarRegistro()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("------------------------------------------");
        Console.WriteLine($"            Edição de {nomeEntidade}");
        Console.WriteLine("------------------------------------------");
        Console.ResetColor();
        Console.WriteLine();

        VisualizarRegistros(false);
        Console.ForegroundColor = ConsoleColor.DarkYellow;

        Console.Clear();
        Console.WriteLine();
        Console.Write("Digite o id do registro que deseja selecionar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());
        Console.Clear();
        Console.WriteLine("------------------------------------------");
        Console.WriteLine($"            Edição de {nomeEntidade}");
        Console.WriteLine("------------------------------------------");
        Console.ResetColor();

        Amigo registroAtualizado = (Amigo)ObterDados();

        string erros = registroAtualizado.Validar();

        if (erros.Length > 0)
        {
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(erros);
            Console.ResetColor();

            Console.Write("\nDigite ENTER para continuar...");
            Console.ReadLine();

            EditarRegistro();

            return;
        }
        

    EntidadeBase[] registros = repositorio.SelecionarRegistros();

        for (int i = 0; i < registros.Length; i++)
        {
            Amigo amigoRegistrado = (Amigo)registros[i];

            if (amigoRegistrado == null)
                continue;

            if (
                amigoRegistrado.Id != idSelecionado &&
                (amigoRegistrado.Nome == registroAtualizado.Nome ||
                amigoRegistrado.Telefone == registroAtualizado.Telefone)
            )
            {
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("------------------------------------------");
                Console.WriteLine("Um amigo com este nome ou telefone já foi cadastrado!");
                Console.Write("------------------------------------------");

                Console.ResetColor();

                Console.Write("\nDigite ENTER para continuar...");
                Console.ReadLine();

                EditarRegistro();

                return;
            }
        }

        repositorio.EditarRegistro(idSelecionado, registroAtualizado);

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("------------------------------------------");
        Console.WriteLine($"{nomeEntidade} editado com sucesso!");
        Console.WriteLine("------------------------------------------");
        Console.WriteLine("Digite ENTER para continuar...");
        Console.Write("------------------------------------------");
        Console.WriteLine();

        Console.ResetColor();
        Console.ReadLine();
    }
    public override void VisualizarRegistros(bool exibirCabecalho)
    {
        if (exibirCabecalho == true)
            ExibirCabecalho();
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("------------------------------------------");
        Console.WriteLine("         Visualização de Amigos");
        Console.WriteLine("------------------------------------------");


        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -20} | {2, -30} | {3, -15} | {4, -15}",
            "Id", "Nome", "Nome do responsável", "Telefone", "Multa Ativa"
        );

        EntidadeBase[] amigo = repositorio.SelecionarRegistros();

        EntidadeBase[] emprestimos = repositorioEmprestimo.SelecionarRegistros();


        for (int i = 0; i < amigo.Length; i++)
        {
            Amigo A = (Amigo)amigo[i];

            if (A == null)
                continue;

            EntidadeBase[] emprestimo = repositorioEmprestimo.SelecionarRegistros();

            for (int j = 0; j < emprestimos.Length; j++)
            {
                Emprestimo e = (Emprestimo)emprestimos[j];

            }

            bool amigoTemMultaAtiva = false;

            for (int j = 0; j < emprestimos.Length; j++)
            {
                Emprestimo e = (Emprestimo)emprestimos[j];

                if (e == null)
                    continue;

                if (A == e.Amigo && e.Multa != null)
                {
                    if (!e.MultaPaga)
                        amigoTemMultaAtiva = true;
                }
            }

            string stringMultaAtiva = amigoTemMultaAtiva ? "Sim" : "Não";


            Console.WriteLine(
               "{0, -10} | {1, -20} | {2, -30} | {3, -15} | {4, -15}",
                A.Id, A.Nome, A.NomeResponsavel, A.Telefone, stringMultaAtiva
            );
        }
        Console.WriteLine();
        Console.Write("------------------------------------------");
        Console.WriteLine("\nDigite ENTER para continuar...");
        Console.Write("------------------------------------------");
        Console.ReadLine();
        Console.ResetColor();
    }
    protected override Amigo ObterDados()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Digite o nome do Amigo: ");
        string nome = Console.ReadLine();
        Console.WriteLine("------------------------------------------");

        Console.Write("Digite o nome do responsável pelo Amigo: ");
        string nomeResponsavel = Console.ReadLine();
        Console.WriteLine("------------------------------------------");

        Console.Write("Digite o telefone do Amigo: ");
        string telefone = Console.ReadLine();
        Console.WriteLine("------------------------------------------");
        Console.ResetColor();

        Amigo amigo = new Amigo(nome, nomeResponsavel, telefone);

        return amigo;
    }
}
