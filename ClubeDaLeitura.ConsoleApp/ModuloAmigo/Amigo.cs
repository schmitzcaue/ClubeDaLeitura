using System.Net.Mail;
using GestaoDeEquipamentos.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.Amigo;

    public class Amigo : EntidadeBase
    {
    public string nome;
    public string nomeResponsavel;
    public string telefone;

    public Amigo(string nome, string nomeResponsavel, string telefone)
    {
        this.nome = nome;
        this.nomeResponsavel = nomeResponsavel;
        this.telefone = telefone;
    }

    public override string Validar()
    {
        string erros = "";

        if (string.IsNullOrWhiteSpace(nome))
            erros += "O nome é obrigatório!\n";

        else if (nome.Length < 4 || nome.Length > 99)
            erros += "O nome deve conter entre 3 e 100 caracteres!\n";

        if (string.IsNullOrWhiteSpace(nomeResponsavel))
            erros += "O nome do Responsavel é obrigatório!\n";

        else if (nomeResponsavel.Length < 4 || nomeResponsavel.Length > 99)
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

        this.nome = AmigoAtualizado.nome;
        this.nomeResponsavel = AmigoAtualizado.nomeResponsavel;
        this.telefone = AmigoAtualizado.telefone;
    }
}
