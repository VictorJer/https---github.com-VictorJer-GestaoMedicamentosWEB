using GestaoDeMedicamentos.WebApp.Compartilhado.Dominio;
using GestaoDeMedicamentos.WebApp.Compartilhado.Infra.Arquivos;
using GestaoDeMedicamentos.WebApp.ModuloFuncionario.Dominio;

namespace GestaoDeMedicamentos.WebApp.ModuloFuncionario.Infra;

public class RepositorioFuncionarioEmArquivo : RepositorioBaseEmArquivo<Funcionario>, IRepositorioFuncionario
{
    public RepositorioFuncionarioEmArquivo(ContextoJson contexto) : base(contexto) { }
    protected override List<Funcionario> CarregarRegistros()
    {
        return contexto.Funcionario;
    }
}
