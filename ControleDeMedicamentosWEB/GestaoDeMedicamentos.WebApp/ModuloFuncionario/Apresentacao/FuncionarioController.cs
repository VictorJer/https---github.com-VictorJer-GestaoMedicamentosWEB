using GestaoDeMedicamentos.WebApp.ModuloFuncionario.Apresentacao;
using GestaoDeMedicamentos.WebApp.ModuloFuncionario.Dominio;
using GestaoDeMedicamentos.WebApp.ModuloFuncionario.Infra;
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

    [HttpGet]
    public ActionResult Cadastrar()
    {
        CadastrarFuncionarioViewModel cadastarVm = new CadastrarFuncionarioViewModel(
            string.Empty,
            string.Empty,
            string.Empty
        );

        return View(cadastarVm);
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastrarFuncionarioViewModel cadastrarVm)
    {
        if (!ModelState.IsValid)
            return View(cadastrarVm);

        Funcionario novoFuncionario = new Funcionario(
            cadastrarVm.Nome,
            cadastrarVm.Telefone,
            cadastrarVm.CPF
        );

        repositorioFuncionario.Cadastrar(novoFuncionario);

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Editar(string id)
    {
        Funcionario? funcionario = repositorioFuncionario.SelecionarPorId(id);

        if (funcionario == null)
            return RedirectToAction(nameof(Listar));

        EditaFuncionarioViewModel editarVm = new EditaFuncionarioViewModel(
            id,
            funcionario.Nome,
            funcionario.Telefone,
            funcionario.CPF
        );

        return View(editarVm);
    }

    [HttpPost]
    public ActionResult Editar(EditaFuncionarioViewModel editarVm)
    {
        if (!ModelState.IsValid)
            return View(editarVm);

        Funcionario funcionario = new Funcionario(
            editarVm.Nome,
            editarVm.Telefone,
            editarVm.CPF
        );

        repositorioFuncionario.Editar(editarVm.Id, funcionario);

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Excluir(string id)
    {
        Funcionario? funcionario = repositorioFuncionario.SelecionarPorId(id);

        if (funcionario == null)
            return RedirectToAction(nameof(Listar));

        ExcluirFuncionaruioviewModel excluirVm = new ExcluirFuncionaruioviewModel(
            id,
            funcionario.Nome,
            funcionario.Telefone,
            funcionario.CPF
        );

        return View(excluirVm);
    }

    [HttpPost]
    public ActionResult Excluir(ExcluirFuncionaruioviewModel excluirVm)
    {
        repositorioFuncionario.Excluir(excluirVm.Id);

        return RedirectToAction(nameof(Listar));
    }
}
