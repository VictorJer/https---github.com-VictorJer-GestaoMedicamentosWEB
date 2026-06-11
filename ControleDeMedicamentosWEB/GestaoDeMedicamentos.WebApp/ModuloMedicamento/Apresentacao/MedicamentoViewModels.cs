using System.ComponentModel.DataAnnotations;

namespace GestaoDeMedicamentos.WebApp.ModuloMedicamento.Apresentacao.Views;


public record ListarMedicamentoViewModel(
    string Id,
    string Nome,
    string Descricao,
    int QuantidadeEmEstoque,
    Fornecedor Fornecedor
);

public record CadastarMedicamentoViewModel(
    [Required]
    [StringLength(100, ErrorMessage = "O campo \"Nome\" deve conter entre 3 e 100 caracteres.", MinimumLength = 3)]
    string Nome,

    [Required]
    [StringLength(255, ErrorMessage = "O campo \"Descrição\" deve conter entre 5 e 255 caracteres.", MinimumLength = 5)]
    string Descricao,

    [Range(1, int.MaxValue, ErrorMessage = "O campo \"Quantidade Em Estoque\" deve ter um valor maior que 0. ")]
    int QuantidadeEmEstoque,

    [Required(ErrorMessage = "O Fornecedor é obrigatório.")]
    string FornecedorId
);

public record EditarMedicamentoViewModel(
    string Id,

    [Required]
    [StringLength(100, ErrorMessage = "O campo \"Nome\" deve conter entre 3 e 100 caracteres.", MinimumLength = 3)]
    string Nome,

    [Required]
    [StringLength(255, ErrorMessage = "O campo \"Descrição\" deve conter entre 5 e 255 caracteres.", MinimumLength = 5)]
    string Descricao,

    [Range(1, int.MaxValue, ErrorMessage = "O campo \"Quantidade Em Estoque\" deve ter um valor maior que 0. ")]
    int QuantidadeEmEstoque,

    [Required(ErrorMessage = "O Fornecedor é obrigatório.")]
    string FornecedorId
);

public record ExcluirMedicamentoViewModel(
    string Id,
    string Nome,
    string Descricao,
    int QuantidadeEmEstoque,
    Fornecedor Fornecedor
);
