using ClubeDaLeitura.ConsoleApp.Compartilhado;
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
        ExibirCabecalho();

        Console.WriteLine("------------------------------------------");
        Console.WriteLine($"Cadastro de {nomeEntidade}");
        Console.Write("------------------------------------------");

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

        Console.WriteLine($"\n{nomeEntidade} cadastrado com sucesso!");
        Console.Write("\nDigite ENTER para continuar...");
        Console.ReadLine();
    }

    public override void EditarRegistro()
    {
        ExibirCabecalho();

        Console.WriteLine($"Edição de {nomeEntidade}");

        Console.WriteLine();

        VisualizarRegistros(false);

        Console.Write("Digite o id do registro que deseja selecionar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine();

        Caixa registroAtualizado = (Caixa)ObterDados();

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
    }


    public override void VisualizarRegistros(bool exibirCabecalho)
    {
        if (exibirCabecalho == true)
            ExibirCabecalho();

        Console.WriteLine("Visualização de Caixas");

        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -20} | {2, -30} | {3, -15}",
            "Id", "Eiqueta", "Cor", "Dias de empréstimo"
        );

        EntidadeBase[] caixa = repositorio.SelecionarRegistros();

        for (int i = 0; i < caixa.Length; i++)
        {
            Caixa C = (Caixa)caixa[i];

            if (C == null)
                continue;

            Console.WriteLine(
               "{0, -10} | {1, -20} | {2, -30} | {3, -15}",
                C.Id, C.Etiqueta, C.Cor, C.DiasEmprestimo
            );
        }
        Console.Write("\nDigite ENTER para continuar...");
        Console.ReadLine();
    }
    public override void ExcluirRegistro()
        {
            ExibirCabecalho();

    Console.WriteLine($"Exclusão de {nomeEntidade}");
            Console.WriteLine();

             VisualizarRegistros(false);

    Console.Write("\nDigite o id do amigo que deseja excluir: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

    // Verificar se há revistas vinculados
    bool temRevistas = repositorioRevista.ExistemRevistasVinculadas(idSelecionado);

            if (temRevistas)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nEste amigo possui empréstimos vinculados e não pode ser excluído.");
                Console.ResetColor();
                Console.ReadLine();
                return;
            }

            bool conseguiuExcluir = repositorio.ExcluirRegistro(idSelecionado);

            if (conseguiuExcluir)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n{nomeEntidade} excluído com sucesso!");
            }
            else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nErro ao tentar excluir o {nomeEntidade}.");
        }

            Console.ResetColor();
            Console.ReadLine();
       }

    protected override Caixa ObterDados()
    {
        Console.Write("Digite a etiqueta da Caixa: ");
        string Etiqueta = Console.ReadLine();

        Console.Write("Digite a cor da caixa: ");
        string Cor = Console.ReadLine();

        Console.Write("Digite o tempo do empréstimo: ");
        int DiasEmprestimo = Convert.ToInt32 (Console.ReadLine());

        Caixa caixa = new Caixa(Etiqueta, Cor, DiasEmprestimo);

        return caixa;
    }
}
