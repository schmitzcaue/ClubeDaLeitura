using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;

    public class RepositorioEmprestimo : RepositorioBase
{

    public bool ExisteEmprestimosVinculadas(int idAmigo)
    {
        EntidadeBase[] registros = SelecionarRegistros();

        foreach (EntidadeBase registro in registros)
        {
            if (registro is Emprestimo emprestimo && emprestimo.amigo != null && emprestimo.amigo.Id == idAmigo)
                return true;
        }

        return false;
    }

}
