using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa;

    public class Caixa : EntidadeBase
    {
    public string cor;
    public string etiqueta;
    public string diasDeEmprestimo;

    public Caixa(string nome, string etiqueta, string diasDeEmprestimo)
    {
        this.cor = nome;
        this.etiqueta = etiqueta;
        this.diasDeEmprestimo = diasDeEmprestimo;
    }

    public override string Validar()
    {
        string erros = "";

        
        if (string.IsNullOrWhiteSpace(etiqueta))
            erros += "A Etiqueta é obrigatória!\n";

        else if (etiqueta.Length < 4 || etiqueta.Length > 51)
            erros += "A Etiqueta deve conter entre 3 e 50 caracteres!\n";

       
        if (string.IsNullOrWhiteSpace(cor))
            erros += "A cor é obrigatória!\n";
        else if (cor.Length < 4 || cor.Length > 99)
            erros += "A cor é obrigatória!\n";
       


        if (string.IsNullOrWhiteSpace(diasDeEmprestimo))
            erros += "O telefone é obrigatório!\n";

        else if (diasDeEmprestimo.Length < 6 || diasDeEmprestimo.Length > 8)
            erros += "O dias de empréstimo deve conter 7 caracteres!\n";
        
        return erros;
    }

    public override void AtualizarRegistro(EntidadeBase registroAtualizado)
    {
        Caixa CaixaAtualizada = (Caixa)registroAtualizado;

        this.etiqueta = CaixaAtualizada.etiqueta;
        this.cor = CaixaAtualizada.cor;
        this.diasDeEmprestimo = CaixaAtualizada.diasDeEmprestimo;
    }
}
