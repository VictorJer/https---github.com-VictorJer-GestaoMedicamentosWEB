using GestaoDeMedicamentos.WebApp.Compartilhado.Dominio;

public class Medicamento : EntidadeBase<Medicamento>
{

    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public int QuantidadeEmEstoque { get; set; } = 0;
    public Fornecedor fornecedor { get; set; }

    public Medicamento() { }

    public Medicamento(string nome, string descricao, int quantidadeEmEstoque, Fornecedor fornecedor)
    {
        Nome = nome;
        Descricao = descricao;
        QuantidadeEmEstoque = quantidadeEmEstoque;
        this.fornecedor = fornecedor;
    }

    public override void Atualizar(Medicamento entidadeAtualizada)
    {
        Nome = entidadeAtualizada.Nome;
        Descricao = entidadeAtualizada.Descricao;
        QuantidadeEmEstoque = entidadeAtualizada.QuantidadeEmEstoque;
        this.fornecedor = fornecedor;
    }

    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if (String.IsNullOrWhiteSpace(Nome))
            erros.Add("Nome não pode ser Null;");

        else if (Nome.Length < 3 && Nome.Length > 100)
            erros.Add("Nome deve conter entre 3 a 100 caracteres!;");

        if (String.IsNullOrWhiteSpace(Descricao))
            erros.Add("Descrição não pode ser Null;");

        else if (Descricao.Length < 5 && Descricao.Length > 255)
            erros.Add("Descrição deve conter entre 5 a 255 caracteres!;");

        if (QuantidadeEmEstoque < 0)
            erros.Add("Quantidade Em Estoque deve conter um valor positivo!");

        if (fornecedor == null)
            erros.Add("Deve conter um fornecedor!");

        return erros;
    }
}
