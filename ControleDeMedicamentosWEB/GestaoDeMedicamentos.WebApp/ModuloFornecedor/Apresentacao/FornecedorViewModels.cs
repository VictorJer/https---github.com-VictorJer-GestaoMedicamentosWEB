using System.ComponentModel.DataAnnotations;

namespace GestaoDeMedicamentos.WebApp.ModuloFornecedor.Apresentacao;

public record ListarFornecedoresViewModel(
    string Id,
    string Nome,
    string Telefone,
    string CNPJ
);

public record CadastrarFornecedorViewModel(
    [Required(ErrorMessage = "O campo \"Nome\" deve ser preenchido.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo \"Nome\" deve conter entre 3 e 100 caracteres.")]
    string Nome,

    [Required(ErrorMessage = "O campo \"Telefone\" deve ser preenchido.")]
    [RegularExpression(@"^\d{10,11}$", ErrorMessage = "O campo \"Telefone\" deve conter entre 10 e 11 dígitos.")]
    string Telefone,

    [Required(ErrorMessage = "O campo \"Nome do Responsável\" deve ser preenchido.")]
    [StringLength(13, ErrorMessage = "O campo \"CNPJ\" deve conter 13 caracteres.")]
    string CNPJ
);

public record EditarFornecedorViewModel(
    string Id,

    [Required(ErrorMessage = "O campo \"Nome\" deve ser preenchido.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo \"Nome\" deve conter entre 3 e 100 caracteres.")]
    string Nome,

    [Required(ErrorMessage = "O campo \"Telefone\" deve ser preenchido.")]
    [RegularExpression(@"^\d{10,11}$", ErrorMessage = "O campo \"Telefone\" deve conter entre 10 e 11 dígitos.")]
    string Telefone,

    [Required(ErrorMessage = "O campo \"Nome do Responsável\" deve ser preenchido.")]
    [StringLength(14, ErrorMessage = "O campo \"CNPJ\" deve conter 13 caracteres.")]
    string CNPJ
);

public record ExcluirFornecedorViewModel(
    string Id,
    string Nome,
    string Telefone,
    string CNPJ

);
