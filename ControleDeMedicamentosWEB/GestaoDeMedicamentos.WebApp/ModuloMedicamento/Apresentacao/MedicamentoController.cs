using GestaoDeMedicamentos.WebApp.ModuloFornecedor.Dominio;
using GestaoDeMedicamentos.WebApp.ModuloMedicamento.Apresentacao.Views;
using GestaoDeMedicamentos.WebApp.ModuloMedicamento.Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

public class MedicamentoController : Controller
{
    private readonly IRepositorioMedicamento repositorioMedicamento;
    private readonly IRepositorioFornecedor repositorioFornecedor;

    public MedicamentoController(
        IRepositorioMedicamento repositorioMedicamento,
        IRepositorioFornecedor repositorioFornecedor)
    {
        this.repositorioMedicamento = repositorioMedicamento;
        this.repositorioFornecedor = repositorioFornecedor;
    }

    [HttpGet]
    public ActionResult Listar()
    {
        List<Medicamento> medicamento = repositorioMedicamento.SelecionarTodos();

        List<ListarMedicamentoViewModel> listarVms = new List<ListarMedicamentoViewModel>();

        foreach (Medicamento c in medicamento)
        {
            ListarMedicamentoViewModel viewModel = new ListarMedicamentoViewModel(
                c.Id,
                c.Nome,
                c.Descricao,
                c.QuantidadeEmEstoque,
                c.fornecedor
            );

            listarVms.Add(viewModel);
        }

        return View(listarVms);
    }

    [HttpGet]
    public ActionResult Cadastrar()
    {
        ViewBag.Fornecedores = new SelectList(
            repositorioFornecedor.SelecionarTodos(),
            "Id",
            "Nome");

        return View(new CadastarMedicamentoViewModel(string.Empty, string.Empty, 0, string.Empty));
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastarMedicamentoViewModel cadastarVm)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Fornecedores = new SelectList(
                repositorioFornecedor.SelecionarTodos(),
                "Id",
                "Nome",
                cadastarVm.FornecedorId);

            return View(cadastarVm);
        }

        Fornecedor? fornecedorSelecionado = repositorioFornecedor.SelecionarPorId(cadastarVm.FornecedorId);

        if (fornecedorSelecionado == null)
        {
            ModelState.AddModelError("FornecedorId", "Fornecedor inválido.");

            ViewBag.Fornecedores = new SelectList(
                repositorioFornecedor.SelecionarTodos(),
                "Id",
                "Nome",
                cadastarVm.FornecedorId);

            return View(cadastarVm);
        }

        Medicamento novoMedicamento = new Medicamento(
            cadastarVm.Nome,
            cadastarVm.Descricao,
            cadastarVm.QuantidadeEmEstoque,
            fornecedorSelecionado);

        repositorioMedicamento.Cadastrar(novoMedicamento);

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Editar(string id)
    {
        Medicamento? medicamento = repositorioMedicamento.SelecionarPorId(id);

        if (medicamento == null)
            return RedirectToAction(nameof(Listar));

        EditarMedicamentoViewModel editarVm = new EditarMedicamentoViewModel(
            id,
            medicamento.Nome,
            medicamento.Descricao,
            medicamento.QuantidadeEmEstoque,
            medicamento.fornecedor.Nome
        );

        ViewBag.Fornecedores = new SelectList(
        repositorioFornecedor.SelecionarTodos(),
        "Id",
        "Nome",
        medicamento.fornecedor.Id);

        return View(editarVm);
    }

    [HttpPost]
    public ActionResult Editar(EditarMedicamentoViewModel editarVm)
    {

        Fornecedor? fornecedorSelecionado = repositorioFornecedor.SelecionarPorId(editarVm.FornecedorId);

        if (fornecedorSelecionado == null)
        {
            ModelState.AddModelError("FornecedorId", "Fornecedor inválido.");

            ViewBag.Fornecedores = new SelectList(
                repositorioFornecedor.SelecionarTodos(),
                "Id",
                "Nome",
                editarVm.FornecedorId);


        }

        if (!ModelState.IsValid)
            return View(editarVm);

        Medicamento medicamentoAtualizado = new Medicamento(
            editarVm.Nome,
            editarVm.Descricao,
            editarVm.QuantidadeEmEstoque,
            fornecedorSelecionado
        );

        repositorioMedicamento.Editar(editarVm.Id, medicamentoAtualizado);

        return RedirectToAction(nameof(Listar));
    }



    [HttpGet]
    public ActionResult Excluir(string id)
    {
        Medicamento? medicamento = repositorioMedicamento.SelecionarPorId(id);

        if (medicamento == null)
            return RedirectToAction(nameof(Listar));

        ExcluirMedicamentoViewModel excluiVm = new ExcluirMedicamentoViewModel(
            id,
            medicamento.Nome,
            medicamento.Descricao,
            medicamento.QuantidadeEmEstoque,
            medicamento.fornecedor
        );

        return View(excluiVm);
    }

    [HttpPost]
    public ActionResult Excluir(ExcluirMedicamentoViewModel excluirVm)
    {
        repositorioMedicamento.Excluir(excluirVm.Id);

        return RedirectToAction(nameof(Listar));
    }
}
