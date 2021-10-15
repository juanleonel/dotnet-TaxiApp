using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaxiApp.Domain.Interfaces;
using TaxiApp.Webp.Models;

namespace TaxiApp.Webp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITaxi _iTaxi;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ITaxi ITaxi)
        {
            _iTaxi = ITaxi;
            _logger = logger;
        }

        public IActionResult Index()
        {
            //_iTaxi.Create(new Domain.Models.Taxi
            //{
            //    Id = Guid.NewGuid(),
            //    Placa = "res",
            //    Matricula = "ffe",
            //    NumeroEconomico = "aawads",
            //    FechaAlta = DateTime.Now,
            //    FechaBaja = DateTime.Now,
            //    FechaMod = DateTime.Now,
            //    UsuarioAltaID = Guid.NewGuid(),

            //}) ; 
            return View();

        }

        public IActionResult Privacy()
        {
            //var data = _iTaxi.GetAll();
            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
