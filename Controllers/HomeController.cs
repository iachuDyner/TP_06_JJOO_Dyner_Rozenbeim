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
}
