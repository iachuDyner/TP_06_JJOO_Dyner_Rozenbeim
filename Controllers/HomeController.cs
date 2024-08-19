using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP_JJOO_Dyner_Rozenbeim.Models;

namespace TP_JJOO_Dyner_Rozenbeim.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult Paises()
    {   
        ViewBag.ListadoPaises = BD.ListarPaises();
        return View();
    }
    public IActionResult Deportes()
    {   
        ViewBag.ListadoDeportes = BD.ListarDeporte();
        return View();
    }
    public IActionResult VerDetalleDeporte(int idDeporte){

        ViewBag.DatosDeporte = BD.VerInfoDeporte(idDeporte);
        ViewBag.ListadoDeportistasDeporte = BD.ListarDeportistasDeporte(idDeporte);
        return View();
    }
    public IActionResult VerDetallePais(int idPais){
        ViewBag.DatosPais = BD.VerInfoPais(idPais);
        ViewBag.ListadoDeportistasPais = BD.ListarDeportistasPais(idPais);
        return View();
    }
    public IActionResult VerDetalleDeportista(int idDeportista)
    {
        ViewBag.DatosDeportista = BD.VerInfoDeportista(idDeportista);
        return View();
    }
    public IActionResult AgregarDeportista()
    {
        ViewBag.ListadoPaises = BD.ListarPaises();
        ViewBag.ListadoDeportes = BD.ListarDeporte();   
        return View();
    }

    [HttpPost]
    public  IActionResult GuardarDeportista(Deportista dep){
        Console.WriteLine(dep.IdDeporte);
        Console.WriteLine(dep.IdPais);
        BD.AgregarDeportista(dep);
        return RedirectToAction("Index");
    }
    public IActionResult EliminarDeportista(int idCandidato)
    {
        BD.EliminarDeportista(idCandidato);
        return View();
    }
    public IActionResult Creditos()
    {
        return View();
    }
}
