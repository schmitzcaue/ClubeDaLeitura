using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa;

    public class Caixa : EntidadeBase
    {
    public string cor;
    public string etiqueta;
    public int diasDeEmprestimo;

    public Caixa(string nome, string etiqueta, int diasDeEmprestimo)
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

        else if (etiqueta.Length < 3 || etiqueta.Length > 51)
            erros += "A Etiqueta deve conter entre 3 e 50 caracteres!\n";

       
        if (string.IsNullOrWhiteSpace(cor))
            erros += "A cor é obrigatória!\n";
        else if (cor.Length < 4 || cor.Length > 99)
            erros += "A cor é obrigatória!\n";
       


       if (diasDeEmprestimo != 7 )
            erros += "Dias de empréstimo deve conter 7 dias!\n";
        
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
