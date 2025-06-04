
using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace ClubeDaLeitura.ConsoleApp.ModuloReserva;

public class Reserva : EntidadeBase
{

    public Amigo amigo;
    public Revista revista;
    public DateTime dataReserva;


    public Reserva(Amigo amigo, Revista revista)
    {
        this.amigo = amigo;
        this.revista = revista;
        this.dataReserva = DateTime.Now;
    }

    public override string Validar()// 
    {
        string erros = "";

        if (dataReserva > DateTime.Now)
            erros += "O campo \"Data de Emprestimo\" deve conter uma data passada.\n";

        if (amigo == null)
            erros += "Amigo está vazio";

        if (revista == null)
            erros += "Revista está vazia";

        return erros;
    }



    public override void AtualizarRegistro(EntidadeBase registroAtualizado)
    {
        throw new NotImplementedException();
    }

    
}