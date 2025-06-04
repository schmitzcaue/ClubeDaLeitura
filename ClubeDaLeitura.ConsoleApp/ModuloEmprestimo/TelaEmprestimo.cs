using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;

//O sistema deve permitir registrar devoluções
//O sistema deve permitir visualizar empréstimos abertos e fechados

//Status possíveis: Aberto / Concluído / Atrasado
//● Cada amigo só pode ter um empréstimo ativo por vez
//● Empréstimos atrasados devem ser destacados visualmente

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
        Console.WriteLine($"3 - Excluir {nomeEntidade}");
        Console.WriteLine($"4 - Devolução ");
        Console.WriteLine($"S - Sair");

        Console.WriteLine();

        Console.Write("Digite uma opção válida: ");
        char opcaoEscolhida = Console.ReadLine().ToUpper()[0];

        return opcaoEscolhida;
    }
    public  void VisualizarAmigo()
    {
        Console.WriteLine();

        Console.WriteLine("Visualização de Amigos");

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
                A.id, A.Nome, A.NomeResponsavel, A.Telefone
            );
        }

        Console.ReadLine();
    }
    public void VisualizarRevistas()
    {
        Console.WriteLine();

        Console.WriteLine("Visualização de Revistas");

        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -20} | {2, -30} | {3, -15}| {4, -15}",
            "Id", "titulo", "Nome do responsável", "Telefone", "status"
        );

        EntidadeBase[] revista = repositorioRevista.SelecionarRegistros();

        for (int i = 0; i < revista.Length; i++)
        {
            Revista R = (Revista)revista[i];

            if (R == null)
                continue;

            Console.WriteLine(
               "{0, -10} | {1, -20} | {2, -30} | {3, -15}| {4, -15}",
                R.id, R.Titulo, R.NumeroDeEdicao, R.AnoDePublicao, R.status
            );
        }

        Console.ReadLine();
    }

    public override void VisualizarRegistros(bool exibirCabecalho)
    {
        if (exibirCabecalho == true)
            ExibirCabecalho();

        Console.WriteLine("Visualização de Emprestimos");

        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -20} | {2, -30} | {3, -15} | {3, -15}",
            "Id", "Amigo", "Revista", "data do empréstimo", "data da devolução"
        );

        EntidadeBase[] revista = repositorioEmprestimo.SelecionarRegistros();

        for (int i = 0; i < revista.Length; i++)
        {
            Emprestimo R = (Emprestimo)revista[i];

            if (R == null)
                continue;

            Console.WriteLine(
               "{0, -10} | {1, -20} | {2, -30} | {3, -15} | {3, -15}",
                R.id, R.amigo.Nome, R.revista.Titulo, R.dataEmprestimo.ToShortDateString(), R.dataDevolucao.ToShortDateString()
            );
        }

        Console.ReadLine();
    }

    public void CadastrarDevolucao()
    {
        VisualizarRegistros(false);

        Console.Write("Digite o id do emprestimo: ");
        int IdEmprestimo = Convert.ToInt32(Console.ReadLine());
        Emprestimo emprestimoSelecionado = (Emprestimo)repositorioEmprestimo.SelecionarRegistroPorId(IdEmprestimo);

        emprestimoSelecionado.dataDevolucao = DateTime.Now;

        emprestimoSelecionado.revista.status = "Disponível";

        Console.WriteLine($"Devolução realizada com sucesso!");
        Console.ReadLine();

    }

    //public void CadastrarReserva()
    //{
    //    VisualizarRegistros(false);

    //    Console.Write("Digite o id do emprestimo: ");
    //    int IdEmprestimo = Convert.ToInt32(Console.ReadLine());
    //    Emprestimo emprestimoSelecionado = (Emprestimo)repositorioEmprestimo.SelecionarRegistroPorId(IdEmprestimo);

    //    emprestimoSelecionado.dataDevolucao = DateTime.Now;

    //    emprestimoSelecionado.revista.Status = "Disponível";

    //    Console.WriteLine($"Emprestimo realizada com sucesso!");
    //    Console.ReadLine();

    //}

    protected override Emprestimo ObterDados()
    {
        VisualizarAmigo();
        Console.Write("Digite o id do amigo: ");
        int IdAmigo = Convert.ToInt32(Console.ReadLine());
        Amigo amigoSelecionado = (Amigo)repositorioAmigo.SelecionarRegistroPorId(IdAmigo);

        VisualizarRevistas();
        Console.Write("Digite o id da revista: ");
        int IdRevista = Convert.ToInt32(Console.ReadLine());
        Revista revistaSelecionado = (Revista)repositorioRevista.SelecionarRegistroPorId(IdRevista);

        Console.WriteLine("Digite a data da reserva");
        DateTime dataEmprestimo = Convert.ToDateTime( Console.ReadLine());

        Emprestimo emprestimo = new Emprestimo(amigoSelecionado, revistaSelecionado, dataEmprestimo);

        return emprestimo;
    }
}
