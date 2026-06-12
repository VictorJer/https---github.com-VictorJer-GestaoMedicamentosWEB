using System.ComponentModel.DataAnnotations;

namespace GestaoDeMedicamentos.WebApp.ModuloPaciente.Apresentacao;

public record ListarPacienteViewModel(

    string Id,
    string Nome,
    string Telefone,
    string CartaoSUS,
    string CPF

);

public record EditarPacienteViewModel(

    string Id,

    [Required]
    [StringLength(100, ErrorMessage = "O campo \"Nome\" deve conter entre 3 e 100 caracteres", MinimumLength = 3)]
    string Nome,

    [Required(ErrorMessage = "O campo \"Telefone\" deve ser preenchido.")]
    [RegularExpression(@"^\d{10,11}$", ErrorMessage = "O campo \"Telefone\" deve conter entre 10 e 11 dígitos.")]
    string Telefone,

    [Required]
    [StringLength(15, ErrorMessage = "O campo \"Cartão Do SUS\" deve conter 15 caracteres")]
    string CartaoSUS,

    [Required]
    [StringLength(11, ErrorMessage = "O campo \"CPF\" deve conter 11 caracteres")]
    string CPF

);

public record CadastrarPacienteViewModel(

    [Required]
    [StringLength(100, ErrorMessage = "O campo \"Nome\" deve conter entre 3 e 100 caracteres", MinimumLength = 3)]
    string Nome,

    [Required(ErrorMessage = "O campo \"Telefone\" deve ser preenchido.")]
    [RegularExpression(@"^\d{10,11}$", ErrorMessage = "O campo \"Telefone\" deve conter entre 10 e 11 dígitos.")]
    string Telefone,

    [Required]
    [StringLength(15, ErrorMessage = "O campo \"Cartão Do SUS\" deve conter 15 caracteres")]
    string CartaoSUS,

    [Required]
    [StringLength(11, ErrorMessage = "O campo \"CPF\" deve conter 11 caracteres")]
    string CPF

);

public record ExcluirPacienteViewModel(

    string Id,
    string Nome,
    string Telefone,
    string CartaoSUS,
    string CPF

);

