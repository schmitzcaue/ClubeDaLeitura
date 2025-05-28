using System.Net.Mail;
using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo;

public class Amigo : EntidadeBase
{
    public string cor;
    public string etiqueta;
    public string telefone;

    public Amigo(string nome, string nomeResponsavel, string telefone)
    {
        this.cor = nome;
        this.etiqueta = nomeResponsavel;
        this.telefone = telefone;
    }

    public override string Validar()
    {
        string erros = "";

        if (string.IsNullOrWhiteSpace(cor))
            erros += "O nome é obrigatório!\n";

        else if (cor.Length < 4 || cor.Length > 99)
            erros += "O nome deve conter entre 3 e 100 caracteres!\n";

        if (string.IsNullOrWhiteSpace(etiqueta))
            erros += "O nome do Responsavel é obrigatório!\n";

        else if (etiqueta.Length < 4 || etiqueta.Length > 99)
            erros += "O nome do responsavel deve conter entre 3 e 100 caracteres!\n";

        if (string.IsNullOrWhiteSpace(telefone))
            erros += "O telefone é obrigatório!\n";

        else if (telefone.Length < 9)
            erros += "O telefone deve conter no mínimo 9 caracteres!\n";

        return erros;
    }

    public override void AtualizarRegistro(EntidadeBase registroAtualizado)
    {
        Amigo AmigoAtualizado = (Amigo)registroAtualizado;

        this.cor = AmigoAtualizado.cor;
        this.etiqueta = AmigoAtualizado.etiqueta;
        this.telefone = AmigoAtualizado.telefone;
    }
}
