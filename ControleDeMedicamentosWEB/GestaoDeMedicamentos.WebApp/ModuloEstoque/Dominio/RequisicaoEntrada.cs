using ControleDeMedicamentosWeb.WebApp.Modulos.ModuloEstoque.Dominio;

public class RequisicaoEntrada : RequisicaoBase
{
    public Medicamento Medicamento { get; set; } = null!;
    public Funcionario Funcionario { get; set; } = null!;
    public uint Quantidade { get; set; } = 0;

    public RequisicaoEntrada() { }

    public RequisicaoEntrada(Medicamento medicamento, Funcionario funcionario, uint quantidade) : this()
    {
        Medicamento = medicamento;
        Funcionario = funcionario;
        Quantidade = quantidade;
    }
}
