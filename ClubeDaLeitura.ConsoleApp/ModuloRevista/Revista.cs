using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace ClubeDaLeitura.ConsoleApp.Compartilhado;

    public  class Revista : EntidadeBase //Não tenho ideia o prq não reconhece kk
    {
    public string titulo;
    public string numeroDeEdicao;
    public string anoDePublicao;
    Caixa caixa;

    public Revista(string titulo, string numeroDeEdicao, string anoDePublicao, Caixa caixa) 
    {
        this.titulo = titulo;
        this.numeroDeEdicao = this.numeroDeEdicao;
        this.anoDePublicao = anoDePublicao;
        this.caixa = caixa;
    }
     
    public Revista(string? titulo, string? numeroDeEdicao, string? anoDePublicao)
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

        if (string.IsNullOrWhiteSpace(numeroDeEdicao))
            erros += "O numero da edição é obrigatório!\n";

        else if (numeroDeEdicao.Length < 4 || numeroDeEdicao.Length > 51)
            erros += "O numero da edição deve ser positivo!\n";

        if (string.IsNullOrWhiteSpace(anoDePublicao))
            erros += "O ano de publicação é obrigatório!\n";

        else if (anoDePublicao.Length < 6 || anoDePublicao.Length > 8)
            erros += "O  ano de publicação deve ter uma data válida!\n";

        if (caixa == null)
            erros += "Caixa está vazia";

        return erros;
    }

    //public override void AtualizarRegistro(EntidadeBase registroAtualizado)
    //{
    //    Revista RevistaAtualizada = (Revista)registroAtualizado;

        
    //    this.titulo = RevistaAtualizada.titulo;
    //    this.numeroDeEdicao = RevistaAtualizada.numeroDeEdicao;
    //    this.anoDePublicao = RevistaAtualizada.anoDePublicao;
    //}
}
