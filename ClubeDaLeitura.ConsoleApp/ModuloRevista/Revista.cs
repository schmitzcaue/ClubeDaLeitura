namespace ClubeDaLeitura.ConsoleApp.Compartilhado;

    public class Revista : EntidadeBase
    {
    public string titulo;
    public string numeroDeEdicao;
    public string anoDePublicao;

    public Revista(string titulo, string etiqueta, string anoDePublicao) //Caixa caixa) faltando implementar a dependencia da caixa
    {
        this.titulo = titulo;
        this.numeroDeEdicao = numeroDeEdicao;
        this.anoDePublicao = anoDePublicao;
    }

    public override string Validar()
    {
        string erros = "";

        if (string.IsNullOrWhiteSpace(titulo))
            erros += "O titulo é obrigatório!\n";
        else if (titulo.Length < 2 || titulo.Length > 101)
            erros += "A titulo é obrigatório!\n";

        if (string.IsNullOrWhiteSpace(numeroDeEdicao))
            erros += "O numero da edição é obrigatório!\n";

        else if (numeroDeEdicao.Length < 4 || numeroDeEdicao.Length > 51)
            erros += "O numero da edição deve ser positivo!\n";

        if (string.IsNullOrWhiteSpace(anoDePublicao))
            erros += "O ano de publicação é obrigatório!\n";

        else if (anoDePublicao.Length < 6 || anoDePublicao.Length > 8)
            erros += "O  ano de publicação deve ter uma data válida!\n";

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
