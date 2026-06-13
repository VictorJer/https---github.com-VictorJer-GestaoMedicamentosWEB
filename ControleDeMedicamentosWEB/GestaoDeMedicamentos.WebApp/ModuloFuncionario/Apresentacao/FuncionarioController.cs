using GestaoDeMedicamentos.WebApp.ModuloFuncionario.Apresentacao;
using GestaoDeMedicamentos.WebApp.ModuloFuncionario.Dominio;
using Microsoft.AspNetCore.Mvc;

public class FuncionarioController : Controller
{
    private readonly IRepositorioFuncionario repositorioFuncionario;

    public FuncionarioController(IRepositorioFuncionario repositorioFuncionario)
    {
        this.repositorioFuncionario = repositorioFuncionario;
    }

    [HttpGet]
    public ActionResult Listar()
    {
        List<Funcionario> funcionarios = repositorioFuncionario.SelecionarTodos();

        List<ListarFuncionarioviewModel> listarVm = new List<ListarFuncionarioviewModel>();

        foreach (Funcionario funcionario in funcionarios)
        {
            ListarFuncionarioviewModel viewModel = new ListarFuncionarioviewModel(
                funcionario.Id,
                funcionario.Nome,
                funcionario.Telefone,
                funcionario.CPF
            );

            listarVm.Add(viewModel);
        }

        return View(listarVm);
    }
}
