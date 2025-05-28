using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa;

class TelaCaixa : TelaBase
{
    public TelaCaixa(string nomeEntidade, RepositorioBase repositorio) : base(nomeEntidade, repositorio)
    {
    }

    public override void VisualizarRegistros(bool exibirCabecalho)
    {
        throw new NotImplementedException();
    }

    protected override EntidadeBase ObterDados()
    {
        throw new NotImplementedException();
    }
}
