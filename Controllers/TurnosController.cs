using Microsoft.AspNetCore.Mvc;
using TurnosPeluqueria_EJ06.Models;

namespace TurnosPeluqueria_EJ06.Controllers;

public class TurnosController : Controller
{
  
    public IActionResult Index()
    {
        BD MiBase = new BD();
        ViewBag.turnos = MiBase.ObtenerTurnos();

        return View();
    }

    [HttpGet]
    public IActionResult Nuevo()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Nuevo(Turno turno)
    {
        // Estado inicial fijo
        if (string.IsNullOrWhiteSpace(turno.Estado))
            turno.Estado = "Pendiente";

        BD MiBase = new BD();
        MiBase.AgregarTurno(turno);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Atender(int id)
    {
        BD MiBase = new BD();
        MiBase.CambiarEstado(id, "Atendido");
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Cancelar(int id)
    {
        BD MiBase = new BD();
        MiBase.CambiarEstado(id, "Cancelado");
        return RedirectToAction("Index");
    }
}