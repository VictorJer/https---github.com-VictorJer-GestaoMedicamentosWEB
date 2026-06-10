
using System.Runtime.CompilerServices;
using GestaoDeMedicamentos.WebApp.ModuloFornecedor.Apresentacao;
using GestaoDeMedicamentos.WebApp.ModuloFornecedor.Dominio;
using GestaoDeMedicamentos.WebApp.ModuloFornecedor.Infra;
using Microsoft.AspNetCore.Mvc;

public class FornecedorController : Controller
{
    private readonly IRepositorioFornecedor repositorioFornecedor;
    public FornecedorController(IRepositorioFornecedor repositorioFornecedor)
    {
        this.repositorioFornecedor = repositorioFornecedor;
    }

    [HttpGet]
    public ActionResult Listar()
    {
        List<Fornecedor> fornecedor = repositorioFornecedor.SelecionarTodos();

        List<ListarFornecedoresViewModel> listarVms = new List<ListarFornecedoresViewModel>();

        foreach (Fornecedor c in fornecedor)
        {
            ListarFornecedoresViewModel viewModel = new ListarFornecedoresViewModel(
                c.Id,
                c.Nome,
                c.Telefone,
                c.CNPJ
            );

            listarVms.Add(viewModel);
        }

        return View(listarVms);
    }

    [HttpGet]
    public ActionResult Cadastrar()
    {
        CadastrarFornecedorViewModel cadastarVm = new CadastrarFornecedorViewModel(
            string.Empty,
            string.Empty,
            string.Empty
        );

        return View(cadastarVm);
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastrarFornecedorViewModel cadastarVm)
    {
        if (!ModelState.IsValid)
            return View(cadastarVm);

        Fornecedor novoFornecedor = new Fornecedor(
            cadastarVm.Nome,
            cadastarVm.Telefone,
            cadastarVm.CNPJ
        );

        repositorioFornecedor.Cadastrar(novoFornecedor);

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Excluir(string id)
    {
        Fornecedor? fornecedor = repositorioFornecedor.SelecionarPorId(id);

        if (fornecedor == null)
            return RedirectToAction(nameof(Listar));

        ExcluirFornecedorViewModel excluiVm = new ExcluirFornecedorViewModel(
            id,
            fornecedor.Nome,
            fornecedor.Telefone,
            fornecedor.CNPJ
        );

        return View(excluiVm);
    }

    [HttpPost]
    public ActionResult Excluir(ExcluirFornecedorViewModel excluirVm)
    {
        repositorioFornecedor.Excluir(excluirVm.Id);

        return RedirectToAction(nameof(Listar));
    }


}
