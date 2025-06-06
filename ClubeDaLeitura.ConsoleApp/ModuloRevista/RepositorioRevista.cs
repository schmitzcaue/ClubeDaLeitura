using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista;

    public class RepositorioRevista : RepositorioBase
    {
    public bool ExistemRevistasVinculadas(int idRevista)
    {
        EntidadeBase[] registros = SelecionarRegistros();

        foreach (EntidadeBase registro in registros)
        {
            if (registro is Revista revista && revista.Caixa != null && revista.Caixa.Id == idRevista)
                return true;
        }

        return false;
    }
}
