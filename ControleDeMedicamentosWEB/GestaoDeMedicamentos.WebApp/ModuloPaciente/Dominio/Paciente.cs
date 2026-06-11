using GestaoDeMedicamentos.WebApp.Compartilhado.Dominio;

public class Paciente : EntidadeBase<Paciente>
{

    public string Nome { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string CartaoSUS { get; set; } = string.Empty;
    public string CPF { get; set; } = string.Empty;

    public Paciente() { }
    public Paciente(string nome, string telefone, string cartaoSUS, string cPF)
    {
        Nome = nome;
        Telefone = telefone;
        CartaoSUS = cartaoSUS;
        CPF = cPF;
    }

    public override void Atualizar(Paciente entidadeAtualizada)
    {
        throw new NotImplementedException();
    }

    public override List<string> Validar()
    {
        throw new NotImplementedException();
    }
}
