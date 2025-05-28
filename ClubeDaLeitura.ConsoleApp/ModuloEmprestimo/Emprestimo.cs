using ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace ClubeDaLeitura.ConsoleApp.Compartilhado;

    public class Emprestimo : EntidadeBase
    {

    public Amigo amigo;
    public Revista revista;
    public DateTime dataEmprestimo;
    public DateTime dataDevolucao;
    
    public Emprestimo(EntidadeBase registroAtualizado)
    {
        this.amigo = amigo;
        this.revista = revista;
        this.dataEmprestimo = dataEmprestimo;
        this.dataDevolucao = dataDevolucao;
    }
    public override string Validar()
    {
        string erros = "";

        if (dataEmprestimo > DateTime.Now)
            erros += "O campo \"Data de Emprestimo\" deve conter uma data passada.\n";

        if (dataDevolucao > DateTime.Now)//(now = after)
            erros += "O campo \"Data de Devolução\" deve conter uma data futura.\n";

        return erros;
    }

    public override void AtualizarRegistro(EntidadeBase registroAtualizado)
    {
        Emprestimo EmprestimoAtualizado = (Emprestimo)registroAtualizado;

        this.dataEmprestimo = EmprestimoAtualizado.dataEmprestimo;
        this.dataDevolucao = EmprestimoAtualizado.dataDevolucao;
    }
}
