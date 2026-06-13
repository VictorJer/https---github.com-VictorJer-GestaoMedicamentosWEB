using System.ComponentModel.DataAnnotations;

namespace GestaoDeMedicamentos.WebApp.ModuloFuncionario.Apresentacao;

public record ListarFuncionarioviewModel(

    string Id,
    string Nome,
    string Telefone,
    string CPF

);

public record EditaFuncionarioViewModel(

    string Id,

    [Required]
    [StringLength(100, ErrorMessage = "O campo \"Nome\" deve conter entre 3 e 100 caracteres", MinimumLength = 3)]
    string Nome,

    [Required]
    [StringLength(11, ErrorMessage = "O campo \"Telefone\" deve conter 11 cararteres")]
    string Telefone,

    [Required]
    [StringLength(11, ErrorMessage = "O campo \"CPF\" deve ter 11 caracteres")]
    string CPF

);

public record CadastrarFuncionarioViewModel(

    [Required]
    [StringLength(100, ErrorMessage = "O campo \"Nome\" deve conter entre 3 e 100 caracteres", MinimumLength = 3)]
    string Nome,

    [Required]
    [StringLength(11, ErrorMessage = "O campo \"Telefone\" deve conter 11 caracterers")]
    string Telefone,

    [Required]
    [StringLength(11, ErrorMessage = "O campo \"CPF\" deve ter 11 caracteres")]
    string CPF

);

public record ExcluirFuncionaruioviewModel(

    string Id,
    string Nome,
    string Telefone,
    string CPF

);
