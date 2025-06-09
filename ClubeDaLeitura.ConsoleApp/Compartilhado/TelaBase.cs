using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;

namespace ClubeDaLeitura.ConsoleApp.Compartilhado;

public abstract class TelaBase
{
    protected string nomeEntidade;
    protected RepositorioBase repositorio;

    protected TelaBase(string nomeEntidade, RepositorioBase repositorio)
    {
        this.nomeEntidade = nomeEntidade;
        this.repositorio = repositorio;
    }

    public virtual char ApresentarMenu()
    {
        Console.Clear();
        ExibirCabecalho();
        
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"1 - Cadastro de {nomeEntidade}");
        Console.WriteLine($"2 - Visualizar {nomeEntidade}s");
        Console.WriteLine($"3 - Editar {nomeEntidade}");
        Console.WriteLine($"4 - Excluir {nomeEntidade}");
        Console.WriteLine($"S - Sair");

        Console.WriteLine();

        Console.Write("Digite uma opção válida: ");
        char opcaoEscolhida = Console.ReadLine().ToUpper()[0];
        Console.ResetColor();
        return opcaoEscolhida;
    }

    public virtual void CadastrarRegistro()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("------------------------------------------");
        Console.WriteLine($"             Cadastro de {nomeEntidade}");
        Console.Write("------------------------------------------");
        Console.ResetColor();

        Console.WriteLine();

        EntidadeBase novoRegistro = ObterDados();

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

        repositorio.CadastrarRegistro(novoRegistro);
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("------------------------------------------");
        Console.WriteLine($"{nomeEntidade} cadastrado com sucesso!");
        Console.WriteLine("------------------------------------------");
        Console.WriteLine("Digite ENTER para continuar...");
        Console.Write("------------------------------------------");
        Console.ReadLine();
        Console.ResetColor();

    }

    public virtual void EditarRegistro()
    {
        ExibirCabecalho();
        Console.WriteLine("------------------------------------------");
        Console.WriteLine($"        Edição de {nomeEntidade}");
        Console.WriteLine("------------------------------------------");


        Console.WriteLine();

        VisualizarRegistros(false);

        Console.Write("Digite o id do registro que deseja selecionar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());
        Console.Clear();

        Console.WriteLine();

        EntidadeBase registroAtualizado = ObterDados();

        repositorio.EditarRegistro(idSelecionado, registroAtualizado);


        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("------------------------------------------");
        Console.WriteLine($"{nomeEntidade} editado com sucesso!");
        Console.Write("------------------------------------------");
        Console.WriteLine("Digite ENTER para continuar...");
        Console.Write("------------------------------------------");
        Console.ResetColor();
        Console.ReadLine();
    }

    public virtual void ExcluirRegistro()
    {
        ExibirCabecalho();

        Console.WriteLine($"Exclusão de {nomeEntidade}");

        Console.WriteLine();

        VisualizarRegistros(false);

        Console.Write("Digite o id do registro que deseja selecionar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine();

        repositorio.ExcluirRegistro(idSelecionado);

        Console.Clear();
        Console.Write("------------------------------------------");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine($"{nomeEntidade} excluído com sucesso!");
        Console.Write("------------------------------------------");
        Console.WriteLine("Digite ENTER para continuar...");
        Console.Write("------------------------------------------");
        Console.ReadLine();
        Console.ResetColor();

    }

    public abstract void VisualizarRegistros(bool exibirCabecalho);

    protected void ExibirCabecalho()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("------------------------------------------");
        Console.WriteLine($"             Gestão de {nomeEntidade}s");
        Console.WriteLine("------------------------------------------");
        Console.ResetColor();
    }

    protected abstract EntidadeBase ObterDados();
}