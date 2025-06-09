using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista;

    public class RepositorioRevista : RepositorioBase
    {
    //public bool ExistemRevistasVinculadas(int idRevista)
    //{
    //    EntidadeBase[] registros = SelecionarRegistros();

    //    foreach (EntidadeBase registro in registros)
    //    {
    //        if (registro is Revista revista && revista.Caixa != null && revista.Caixa.Id == idRevista)
    //            return true;
    //    }

    //    return false;
    //}

    public Revista[] SelecionarRevistasDisponiveis()
    {
        int contadorRevistasDisponiveis = 0;

        for (int i = 0; i<registros.Length; i++)
        {
            Revista revistaAtual = (Revista)registros[i];

            if (revistaAtual == null)
                continue;

            if (revistaAtual.Status == "Disponível")
                contadorRevistasDisponiveis++;
        }

        Revista[] revistasDisponiveis = new Revista[contadorRevistasDisponiveis];

    int contadorAuxiliar = 0;

        for (int i = 0; i<registros.Length; i++)
        {
            Revista revistaAtual = (Revista)registros[i];

            if (revistaAtual == null)
                continue;

            if (revistaAtual.Status == "Disponível")
            {
                revistasDisponiveis[contadorAuxiliar++] = (Revista) registros[i];
            }
        }

        return revistasDisponiveis;
    }
}