//using ClubeDaLeitura.ConsoleApp.Compartilhado;
//using ClubeDaLeitura.ConsoleApp.ModuloRevista;

//namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;

//    public class Emprestimo : EntidadeBase
//    {

//    public ModuloRevista.Amigo amigo;
//    public Compartilhado.Revista revista;
//    public DateTime dataEmprestimo;
//    public DateTime dataDevolucao;
    
//    public Emprestimo(ModuloRevista.Amigo amigo, Compartilhado.Revista revista, DateTime dataEmprestimo )
//    {
//        this.amigo = amigo;
//        this.revista = revista;
//        this.dataEmprestimo = dataEmprestimo;
//        this.dataDevolucao = dataDevolucao;
//    }
//    public override string Validar()
//    {
//        string erros = "";

//        if (dataEmprestimo > DateTime.Now)
//            erros += "O campo \"Data de Emprestimo\" deve conter uma data passada.\n";

//        if (amigo == null)
//            erros += "Amigo está vazio";
        
//        if (revista == null)
//            erros += "Revista está vazia";

//        return erros;
//    }

//    public override void AtualizarRegistro(EntidadeBase registroAtualizado)
//    {
//        Emprestimo EmprestimoAtualizado = (Emprestimo)registroAtualizado;

//        this.dataEmprestimo = EmprestimoAtualizado.dataEmprestimo;
//        this.dataDevolucao = EmprestimoAtualizado.dataDevolucao;
//    }
//}
