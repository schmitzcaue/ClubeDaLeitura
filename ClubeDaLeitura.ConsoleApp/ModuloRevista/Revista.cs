using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace ClubeDaLeitura.ConsoleApp.Compartilhado;

    public class Revista : EntidadeBase 
    {
    public string titulo;
    public int numeroDeEdicao;
    public DateTime anoDePublicao;
    public Caixa caixa;

    public Revista(string titulo, int numeroDeEdicao, DateTime anoDePublicao, Caixa caixa) 
    {
        this.titulo = titulo;
        this.numeroDeEdicao = numeroDeEdicao;
        this.anoDePublicao = anoDePublicao;
        this.caixa = caixa;
    }
    public override string Validar()
    {
        string erros = "";

        if (string.IsNullOrWhiteSpace(titulo))
            erros += "O titulo é obrigatório!\n";
        else if (titulo.Length < 2 || titulo.Length > 101)
            erros += "A titulo é obrigatório!\n";

        else if (numeroDeEdicao < 4 || numeroDeEdicao > 51)
            erros += "O numero da edição deve ser positivo!\n";

        else if (anoDePublicao > DateTime.Now)
            erros += "O ano de publicação deve ter uma data válida!\n";

        if (caixa == null)
            erros += "Caixa está vazia";

        return erros;
    }

    public override void AtualizarRegistro(EntidadeBase registroAtualizado)
    {
        Revista RevistaAtualizada = (Revista)registroAtualizado;


        this.titulo = RevistaAtualizada.titulo;
        this.numeroDeEdicao = RevistaAtualizada.numeroDeEdicao;
        this.anoDePublicao = RevistaAtualizada.anoDePublicao;
    }
}
