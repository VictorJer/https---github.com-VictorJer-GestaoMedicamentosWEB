
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


}
