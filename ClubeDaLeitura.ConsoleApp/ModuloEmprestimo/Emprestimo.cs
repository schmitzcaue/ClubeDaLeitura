
using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;

public class Emprestimo : EntidadeBase
{

    public Amigo amigo;
    public Revista revista;
    public DateTime dataEmprestimo;
    public DateTime dataDevolucao;

    public Emprestimo(Amigo amigo, Revista revista)
    {
        this.amigo = amigo;
        this.revista = revista;
        this.dataEmprestimo = DateTime.Now;
        this.dataDevolucao = dataEmprestimo.AddDays(revista.caixa.diasDeEmprestimo);
    }
    public override string Validar()
    {
        string erros = "";

        if (dataEmprestimo > DateTime.Now)
            erros += "O campo \"Data de Emprestimo\" deve conter uma data passada.\n";

        if (amigo == null)
            erros += "Amigo está vazio";

        if (revista == null)
            erros += "Revista está vazia";

        return erros;
    }

    public override void AtualizarRegistro(EntidadeBase registroAtualizado)
    {
        return;
    }
}