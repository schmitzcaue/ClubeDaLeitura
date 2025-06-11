
using System.ComponentModel.Design;
using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;

public class Emprestimo : EntidadeBase
{

    public Amigo Amigo { get; set; }
    public Revista Revista { get; set; }
    public DateTime DataEmprestimo { get; set; }
    public DateTime DataDevolucao
    {
        get
        {
            return DataEmprestimo.AddDays(Revista.Caixa.DiasEmprestimo);
        }
    }
    public string Status { get; set; }
    public Multa Multa { get; set; }

    public Emprestimo(Amigo amigo, Revista revista)
    {
        Amigo = amigo;
        Revista = revista;
        DataEmprestimo = DateTime.Now;
        Status = "Aberto";
        Multa = null;

    }
    public override string Validar()
    {
        string erros = string.Empty;

        if (Amigo == null)
            erros += "Amigo está vazio";

        if (Revista == null)
            erros += "Revista está vazia";

        return erros;
    }

    public override void AtualizarRegistro(EntidadeBase registroAtualizado)
    {
        Status = "Concluído";
    }

    
}