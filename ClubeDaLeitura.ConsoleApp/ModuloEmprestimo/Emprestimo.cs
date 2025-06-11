
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
    
    public Multa Multa
    {
        get
        {
            if (DateTime.Now <= DataDevolucao)
                return null;

            TimeSpan diferencaDatas = DateTime.Now.Subtract(DataDevolucao);

            decimal valorMulta = 2.00m * diferencaDatas.Days;

            Multa multa = new Multa(valorMulta);

            return multa;
        }
    }

    public bool MultaPaga = false;

    public Emprestimo(Amigo amigo, Revista revista)
    {
        Amigo = amigo;
        Revista = revista;
        DataEmprestimo = DateTime.Now;
        Status = "Aberto";

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