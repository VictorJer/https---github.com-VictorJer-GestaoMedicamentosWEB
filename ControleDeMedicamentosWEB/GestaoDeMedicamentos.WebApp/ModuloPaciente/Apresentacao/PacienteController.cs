using GestaoDeMedicamentos.WebApp.ModuloPaciente.Apresentacao;
using GestaoDeMedicamentos.WebApp.ModuloPaciente.Dominio;
using GestaoDeMedicamentos.WebApp.ModuloPaciente.Infra;
using Microsoft.AspNetCore.Mvc;

public class PacienteController : Controller
{
    private readonly IRepositorioPaciente repositorioPaciente;
    public PacienteController(IRepositorioPaciente repositorioPaciente)
    {
        this.repositorioPaciente = repositorioPaciente;
    }

    [HttpGet]
    public ActionResult Listar()
    {
        List<Paciente> pacientes = repositorioPaciente.SelecionarTodos();

        List<ListarPacienteViewModel> listarVms = new List<ListarPacienteViewModel>();

        foreach (Paciente paciente in pacientes)
        {
            ListarPacienteViewModel viewModel = new ListarPacienteViewModel(
                paciente.Id,
                paciente.Nome,
                paciente.Telefone,
                paciente.CartaoSUS,
                paciente.CPF
            );

            listarVms.Add(viewModel);
        }

        return View(listarVms);
    }

    [HttpGet]
    public ActionResult Cadastrar()
    {
        CadastrarPacienteViewModel cadastrarVm = new CadastrarPacienteViewModel(
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty
        );
        return View(cadastrarVm);
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastrarPacienteViewModel cadastarVm)
    {
        if (!ModelState.IsValid)
            return View(cadastarVm);

        Paciente novoPaciente = new Paciente(
            cadastarVm.Nome,
            cadastarVm.Telefone,
            cadastarVm.CartaoSUS,
            cadastarVm.CPF
        );

        repositorioPaciente.Cadastrar(novoPaciente);

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Editar(string id)
    {
        Paciente? paciente = repositorioPaciente.SelecionarPorId(id);

        if (paciente == null)
            return RedirectToAction(nameof(Listar));

        EditarPacienteViewModel editarVm = new EditarPacienteViewModel(
            id,
            paciente.Nome,
            paciente.Telefone,
            paciente.CartaoSUS,
            paciente.CPF
        );

        return View(editarVm);
    }

    [HttpPost]
    public ActionResult Editar(EditarPacienteViewModel editarVm)
    {
        if (!ModelState.IsValid)
            return View(editarVm);

        Paciente paciente = new Paciente(
            editarVm.Nome,
            editarVm.Telefone,
            editarVm.CartaoSUS,
            editarVm.CPF
        );

        repositorioPaciente.Editar(editarVm.Id, paciente);

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Excluir(string id)
    {
        Paciente? paciente = repositorioPaciente.SelecionarPorId(id);

        if (paciente == null)
            return RedirectToAction(nameof(Listar));

        ExcluirPacienteViewModel excluirVm = new ExcluirPacienteViewModel(
            id,
            paciente.Nome,
            paciente.Telefone,
            paciente.CartaoSUS,
            paciente.CPF
        );

        return View(excluirVm);
    }

    [HttpPost]
    public ActionResult Excluir(ExcluirPacienteViewModel excluirVm)
    {
        repositorioPaciente.Excluir(excluirVm.Id);

        return RedirectToAction(nameof(Listar));
    }
}
