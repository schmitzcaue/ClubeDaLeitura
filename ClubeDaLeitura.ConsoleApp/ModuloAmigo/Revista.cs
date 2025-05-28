using System.Net.Mail;
using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista;

public class Revista : EntidadeBase
{
    public string nome;
    public string numeroDeEdicao;
    public string anoDePublicao;
    internal int titulo;

    public Revista(string nome, string nomeResponsavel, string telefone)
    {
        this.nome = nome;
        this.numeroDeEdicao = nomeResponsavel;
        this.anoDePublicao = telefone;
    }

    public override string Validar()
    {
        string erros = "";

        if (string.IsNullOrWhiteSpace(nome))
            erros += "O nome é obrigatório!\n";

        else if (nome.Length < 4 || nome.Length > 99)
            erros += "O nome deve conter entre 3 e 100 caracteres!\n";

        if (string.IsNullOrWhiteSpace(numeroDeEdicao))
            erros += "O nome do Responsavel é obrigatório!\n";

        else if (numeroDeEdicao.Length < 4 || numeroDeEdicao.Length > 99)
            erros += "O nome do responsavel deve conter entre 3 e 100 caracteres!\n";

        if (string.IsNullOrWhiteSpace(anoDePublicao))
            erros += "O telefone é obrigatório!\n";

        else if (anoDePublicao.Length < 9)
            erros += "O telefone deve conter no mínimo 9 caracteres!\n";

        return erros;
    }

    public override void AtualizarRegistro(EntidadeBase registroAtualizado)
    {
        Revista AmigoAtualizado = (Revista)registroAtualizado;

        this.nome = AmigoAtualizado.nome;
        this.numeroDeEdicao = AmigoAtualizado.numeroDeEdicao;
        this.anoDePublicao = AmigoAtualizado.anoDePublicao;
    }
}
