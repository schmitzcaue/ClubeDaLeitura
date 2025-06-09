using System;
using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;

public class TelaEmprestimo : TelaBase
{
    private RepositorioEmprestimo repositorioEmprestimo;
    private RepositorioAmigo repositorioAmigo;
    private RepositorioRevista repositorioRevista;

    public TelaEmprestimo(RepositorioEmprestimo repositorioEmprestimo, RepositorioAmigo repositorioAmigo,
        RepositorioRevista repositorioRevista) : base("Emprestimo", repositorioEmprestimo)
    {
        this.repositorioEmprestimo = repositorioEmprestimo;
        this.repositorioAmigo = repositorioAmigo;
        this.repositorioRevista = repositorioRevista;
    }
    public override char ApresentarMenu()
    {
        ExibirCabecalho();


        Console.WriteLine($"1 - Cadastro de {nomeEntidade}");
        Console.WriteLine($"2 - Visualizar {nomeEntidade}s");
        Console.WriteLine($"3 - Devolução {nomeEntidade}");
        Console.WriteLine($"S - Sair");

        Console.WriteLine();

        Console.Write("Digite uma opção válida: ");
        char opcaoEscolhida = Console.ReadLine().ToUpper()[0];

        return opcaoEscolhida;
    }
    public void CadastrarEmprestimo()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("------------------------------------------");
        Console.WriteLine($"             Cadastro de {nomeEntidade}");
        Console.Write("------------------------------------------");
        Console.ResetColor();

        Console.WriteLine();

        Emprestimo novoRegistro = (Emprestimo)ObterDados();

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

        Emprestimo[] emprestimosAtivos = repositorioEmprestimo.SelecionarEmprestimosAtivos();

        for (int i = 0; i < emprestimosAtivos.Length; i++)
        {
            Emprestimo emprestimoAtivo = emprestimosAtivos[i];

            if (novoRegistro.Amigo.Id == emprestimoAtivo.Amigo.Id)
            {
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("O amigo selecionado já tem um empréstimo ativo!");
                Console.ResetColor();

                Console.Write("\nDigite ENTER para continuar...");
                Console.ReadLine();

                return;
            }
        }

        //bool temEmprestimos = repositorioEmprestimo.ExisteEmprestimosVinculadas(novoRegistro.Amigo.Id);

        //    if (temEmprestimos)
        //{
        //    Console.ForegroundColor = ConsoleColor.Red;
        //    Console.WriteLine("\nEste amigo possui empréstimos vinculados e não pode adquirir outro.");
        //    Console.ResetColor();
        //    Console.ReadLine();
        //    return;
        //}



        novoRegistro.Revista.Status = "Emprestada";
        repositorio.CadastrarRegistro(novoRegistro);
        //
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("------------------------------------------");
        Console.WriteLine($"\n{nomeEntidade} cadastrado com sucesso!");
        Console.Write("------------------------------------------");
        Console.WriteLine("\nDigite ENTER para continuar...");
        Console.Write("------------------------------------------");
        Console.ReadLine();
        Console.ResetColor();
        //
    }
    public void CadastrarDevolucao()
    {
        //Console.Clear();
        //VisualizarRegistros(false);

        //Console.Write("Digite o id do emprestimo: ");
        //int IdEmprestimo = Convert.ToInt32(Console.ReadLine());
        //Console.Clear();

        //Emprestimo emprestimoSelecionado = (Emprestimo)repositorioEmprestimo.SelecionarRegistroPorId(IdEmprestimo);

        //emprestimoSelecionado.DataDevolucao = DateTime.Now;

        //emprestimoSelecionado.Revista.Status = "Disponível";

        Console.WriteLine($"Devolução de {nomeEntidade}"); 

        Console.WriteLine();

        VisualizarEmprestimosAtivos();

        Console.Write("Digite o ID do emprestimo que deseja concluir: ");
        int idEmprestimo = Convert.ToInt32(Console.ReadLine());

        Emprestimo emprestimoSelecionado = (Emprestimo)repositorio.SelecionarRegistroPorId(idEmprestimo);

        if (emprestimoSelecionado == null)
        {
            Console.Clear();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("------------------------------------------");
            Console.WriteLine("O empréstimo selecionado não existe!");
            Console.Write("------------------------------------------");
            Console.WriteLine("\nDigite ENTER para continuar...");
            Console.Write("------------------------------------------");
            Console.ResetColor();

            return;
        }

        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write("\nDeseja confirmar a conclusão do empréstimo? Esta ação é irreversível. (s/N): ");
        Console.ResetColor();

        string resposta = Console.ReadLine()!;

        if (resposta.ToUpper() == "S")
        {
            emprestimoSelecionado.Status = "Concluído";
            emprestimoSelecionado.Revista.Status = "Disponível";



            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("------------------------------------------");
            Console.WriteLine($"Devolução realizada com sucesso!");
            Console.Write("------------------------------------------");
            Console.WriteLine("\nDigite ENTER para continuar...");
            Console.Write("------------------------------------------");
            Console.ReadLine();
            Console.ResetColor();
        }
    }
    public override void VisualizarRegistros(bool exibirCabecalho)
    {
        if (exibirCabecalho == true)
            ExibirCabecalho();
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("------------------------------------------");
        Console.WriteLine("     Visualização de Emprestimos");
        Console.Write("------------------------------------------");
        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -20} | {2, -15} | {3, -20} | {4, -15} | {5, -15}",
            "Id", "Amigo", "Revista", "data do empréstimo", "data da devolução","Status"
        );

        EntidadeBase[] revista = repositorioEmprestimo.SelecionarRegistros();

        for (int i = 0; i < revista.Length; i++)
        {
            Emprestimo E = (Emprestimo)revista[i];

            if (E == null)
                continue;

            if (E.Status =="Atrasado")
                Console.ForegroundColor= ConsoleColor.DarkRed;


            Console.WriteLine(
               "{0, -10} | {1, -20} | {2, -15} | {3, -20} | {4, -15} | {5, -15}",
                E.Id, E.Amigo.Nome, E.Revista.Titulo, E.DataEmprestimo.ToShortDateString(), E.DataDevolucao.ToShortDateString(), E.Status
            );
            Console.ResetColor();

        }
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.Write("------------------------------------------");
        Console.WriteLine("\nDigite ENTER para continuar...");
        Console.Write("------------------------------------------");
        Console.ReadLine();
        Console.ResetColor();
    }
    protected override Emprestimo ObterDados()
    {
        VisualizarAmigo();
        Console.Write("Digite o id do amigo: ");
        int IdAmigo = Convert.ToInt32(Console.ReadLine());
        Amigo AmigoSelecionado = (Amigo)repositorioAmigo.SelecionarRegistroPorId(IdAmigo);
        Console.Clear();

        VisualizarRevistasDisponiveis();
        Console.Write("Digite o id da revista: ");
        int IdRevista = Convert.ToInt32(Console.ReadLine());
        Revista RevistaSelecionado = (Revista)repositorioRevista.SelecionarRegistroPorId(IdRevista);
        Console.Clear();

        Emprestimo emprestimo = new Emprestimo(AmigoSelecionado, RevistaSelecionado);

        return emprestimo;
    }
    private void VisualizarEmprestimosAtivos()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("------------------------------------------");
        Console.WriteLine(" Visualização de Empréstimos Ativos");
        Console.Write("------------------------------------------");


        Console.WriteLine();

        Console.WriteLine(
            "{0, -5} | {1, -15} | {2, -15} | {3, -20} | {4, -25} | {5, -15}",
            "Id", "Amigo", "Revista", "Data do Empréstimo", "Data Prev. Devolução", "Status"
        );

        EntidadeBase[] emprestimosAtivos = repositorioEmprestimo.SelecionarEmprestimosAtivos();

        for (int i = 0; i<emprestimosAtivos.Length; i++)
        {
            Emprestimo e = (Emprestimo)emprestimosAtivos[i];

            if (e == null)
                continue;

            if (e.Status == "Atrasado")
                Console.ForegroundColor = ConsoleColor.DarkYellow;

            Console.WriteLine(
             "{0, -5} | {1, -15} | {2, -15} | {3, -20} | {4, -25} | {5, -15}",
                e.Id, e.Amigo.Nome, e.Revista.Titulo, e.DataEmprestimo.ToShortDateString(), e.DataDevolucao.ToShortDateString(), e.Status
            );

            Console.ResetColor();
        }

Console.WriteLine();
    }
    public void VisualizarAmigo()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("------------------------------------------");
        Console.WriteLine("         Visualização de Amigos");
        Console.WriteLine("------------------------------------------");

        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -20} | {2, -30} | {3, -15}",
            "Id", "Nome", "Nome do responsável", "Telefone"
        );

        EntidadeBase[] amigo = repositorioAmigo.SelecionarRegistros();

        for (int i = 0; i < amigo.Length; i++)
        {
            Amigo A = (Amigo)amigo[i];

            if (A == null)
                continue;

            Console.WriteLine(
               "{0, -10} | {1, -20} | {2, -30} | {3, -15}",
                A.Id, A.Nome, A.NomeResponsavel, A.Telefone
            );
        }
        Console.WriteLine();
        Console.Write("------------------------------------------");
        Console.WriteLine("\nDigite ENTER para continuar...");
        Console.Write("------------------------------------------");
        Console.ReadLine();
        Console.ResetColor();

    }
    private void VisualizarRevistasDisponiveis()
    {
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("------------------------------------------");
        Console.WriteLine("    Visualização de Revistas disponiveis");
        Console.WriteLine("------------------------------------------");


        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -20} | {2, -30} | {3, -15}| {4, -15}",
            "Id", "titulo", "Nome do responsável", "Data de publicao", "status"
        );

        EntidadeBase[] revistasDisponiavies = repositorioRevista.SelecionarRevistasDisponiveis();

        for (int i = 0; i < revistasDisponiavies.Length; i++)
        {
            Revista R = (Revista)revistasDisponiavies[i];

            if (R == null)
                continue;

            Console.WriteLine(
               "{0, -10} | {1, -20} | {2, -30} | {3, -15}| {4, -15}",
                R.Id, R.Titulo, R.NumeroDeEdicao, R.AnoDePublicao, R.Status
            );
        }
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("------------------------------------------");
        Console.WriteLine("\nDigite ENTER para continuar...");
        Console.Write("------------------------------------------");
        Console.ReadLine();
        Console.ResetColor();
    }
}
