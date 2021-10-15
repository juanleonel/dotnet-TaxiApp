using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaxiApp.Domain.Interfaces;
using TaxiApp.Domain.Models;
using TaxiApp.Web.Models;

namespace TaxiApp.Web.Controllers
{
    public class TarifaController : Controller
    {

        private readonly ITarifa _Tarifa;
        private readonly ILogger<TarifaController> _logger;

        public TarifaController(ILogger<TarifaController> logger, ITarifa ITarifa)
        {
            _Tarifa = ITarifa;
            _logger = logger;
        }

        public ActionResult Index()
        {
            var tarifas = _Tarifa.GetAll();
            var models = Mapeo(tarifas);
            return View(models);
        }
       

        // GET: Tarifa/Create
        public ActionResult Create()
        {
            return View(new TarifaViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TarifaViewModel model)
        {
            try
            {
                Tarifa tarifa = Mapeo(model);
                tarifa.Id = Guid.NewGuid();
                tarifa.FechaAlta = DateTime.Now;
                tarifa.UsuarioAltaID = Guid.NewGuid();
                
                _Tarifa.Create(tarifa);

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        
        public ActionResult Edit(int id)
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult Delete(int id)
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        #region Mapeo

        private List<TarifaViewModel> Mapeo(IList<Tarifa> tarifas)
        {

            var models = tarifas.Select(x => new TarifaViewModel
            {
                Id = x.Id,
                Descripcion = x.Descripcion,
                Precio = x.Precio,
                Longitud = x.Longitud,
                Latitud = x.Latitud,
                FechaAlta = x.FechaAlta,
                UsuarioAltaID = x.UsuarioAltaID,
                Baja = x.Baja,
                FechaBaja = x.FechaBaja,
                FechaMod = x.FechaMod,
                UsuarioBajaID = x.UsuarioBajaID,
                UsuarioModID = x.UsuarioModID
            }).ToList();

            return models;
        }

        private TarifaViewModel Mapeo(Tarifa tarifa)
        {

            var model = new TarifaViewModel
            {
                Id = tarifa.Id,                
                Descripcion = tarifa.Descripcion,
                Precio = tarifa.Precio,
                Longitud = tarifa.Longitud,
                Latitud = tarifa.Latitud,
                FechaAlta = tarifa.FechaAlta,
                UsuarioAltaID = tarifa.UsuarioAltaID,
                Baja = tarifa.Baja,
                FechaBaja = tarifa.FechaBaja,
                FechaMod = tarifa.FechaMod,
                UsuarioBajaID = tarifa.UsuarioBajaID,
                UsuarioModID = tarifa.UsuarioModID
            };

            return model;
        }

        private List<Tarifa> Mapeo(IList<TarifaViewModel> models)
        {

            var taxis = models.Select(x => new Tarifa
            {
                Id = x.Id,
                Descripcion = x.Descripcion,
                Precio = x.Precio,
                Longitud = x.Longitud,
                Latitud = x.Latitud,
                FechaAlta = x.FechaAlta,
                UsuarioAltaID = x.UsuarioAltaID,
                Baja = x.Baja,
                FechaBaja = x.FechaBaja,
                FechaMod = x.FechaMod,
                UsuarioBajaID = x.UsuarioBajaID,
                UsuarioModID = x.UsuarioModID
            }).ToList();

            return taxis;
        }

        private Tarifa Mapeo(TarifaViewModel model)
        {
            var taxi = new Tarifa
            {
                Id = model.Id,
                Descripcion = model.Descripcion,
                Precio = model.Precio,          
                Longitud = model.Longitud,
                Latitud = model.Latitud,
                FechaAlta = model.FechaAlta,
                UsuarioAltaID = model.UsuarioAltaID,
                Baja = model.Baja,
                FechaBaja = model.FechaBaja,
                FechaMod = model.FechaMod,
                UsuarioBajaID = model.UsuarioBajaID,
                UsuarioModID = model.UsuarioModID
            };

            return taxi;
        }

        #endregion
    }
}