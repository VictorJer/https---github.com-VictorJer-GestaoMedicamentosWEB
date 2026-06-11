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
        Nome = entidadeAtualizada.Nome;
        Telefone = entidadeAtualizada.Telefone;
        CartaoSUS = entidadeAtualizada.CartaoSUS;
        CPF = entidadeAtualizada.CPF;
    }

    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if (Nome.Length < 3 && Nome.Length > 100)
            erros.Add("O campo \"Nome\" deve conter entre 3 e 100 caracteres");

        string telefoneEncurtado = Telefone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "");
        bool contemLetraOuSimbolo = false;
        int contadorDigitos = 0;

        for (int i = 0; i < telefoneEncurtado.Length; i++)
        {
            char c = telefoneEncurtado[i];
            if (char.IsDigit(c))
                contadorDigitos++;
            else
            {
                contemLetraOuSimbolo = true;
                break;
            }
        }

        if (contadorDigitos < 10 && contadorDigitos > 11)
            erros.Add("O campo Telefone deve conter entre 10 e 11 dígitos;");

        if (contemLetraOuSimbolo)
            erros.Add("O campo Telefone deve conter apenas dígitos;");

        if (CartaoSUS.Length != 15)
            erros.Add("O campo \"Cartão do SUS\" deve conter 15 caracteres!");

        if (CPF.Length != 11)
            erros.Add("O campo \"CPF\" deve conter 11 caracteres");

        return erros;
    }
}
