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
    public class TaxiController : Controller
    {
        private readonly ITaxi _iTaxi;
        private readonly ILogger<TaxiController> _logger;

        public TaxiController(ILogger<TaxiController> logger, ITaxi ITaxi)
        {
            _iTaxi = ITaxi;
            _logger = logger;
        }

        #region CRUD
        public ActionResult Index()
        {
            var taxis = _iTaxi.GetAll();

            var models = Mapeo(taxis);

            return View(models);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaxiViewModel model)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return View();
                }

                // TODO: Add insert logic here
                
                Taxi taxi = Mapeo(model);
                taxi.Id = Guid.NewGuid();

                _iTaxi.Create(taxi);

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        public ActionResult Edit(Guid Id)
        {

            if (Guid.Empty == Id)
            {
                return RedirectToAction(nameof(Index));
            }

            var taxi = _iTaxi.GetByID(Id);
            if (taxi != null)
            {
                var model = Mapeo(taxi);
               
                return View(model);
            }

            return RedirectToAction(nameof(Index));

        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TaxiViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(new TaxiViewModel());
                }
                var taxi = _iTaxi.GetByID(model.Id);
                if (taxi == null)
                {
                    return View(new TaxiViewModel());
                }


                taxi.Matricula = model.Matricula;
                taxi.NumeroEconomico = model.NumeroEconomico;
                taxi.Placa = model.Placa;
                taxi.FechaMod = DateTime.Now;
                taxi.UsuarioModID = Guid.NewGuid();
 
                var result = _iTaxi.Update(taxi);

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View();
            }
        }
       
        public ActionResult Delete(Guid id)
        {
            var taxi = _iTaxi.GetByID(id);
            if (taxi == null)
            {
                return View(new TaxiViewModel());
            }

            var model = Mapeo(taxi);

            return View(model);
        }

        // POST: Taxi/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                var taxi = _iTaxi.GetByID(id);
                if (taxi == null)
                {
                    return View(new TaxiViewModel());
                }

                var result = _iTaxi.Delete(taxi);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        #endregion

        #region Mapeo

        private List<TaxiViewModel> Mapeo(IList<Taxi> taxis) {

            var models = taxis.Select(x => new TaxiViewModel
            {
                Id = x.Id,
                Placa = x.Placa,
                Matricula = x.Matricula,
                NumeroEconomico = x.NumeroEconomico,
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

        private TaxiViewModel Mapeo(Taxi taxi)
        {

           var model = new TaxiViewModel
            {
                Id = taxi.Id,
                Placa = taxi.Placa,
                Matricula = taxi.Matricula,
                NumeroEconomico = taxi.NumeroEconomico,
                FechaAlta = taxi.FechaAlta,
                UsuarioAltaID = taxi.UsuarioAltaID,
                Baja = taxi.Baja,
                FechaBaja = taxi.FechaBaja,
                FechaMod = taxi.FechaMod,
                UsuarioBajaID = taxi.UsuarioBajaID,
                UsuarioModID = taxi.UsuarioModID
            };

            return model;
        }

        private List<Taxi> Mapeo(IList<TaxiViewModel> models)
        {

            var taxis = models.Select(x => new Taxi
            {
                Id = x.Id,
                Placa = x.Placa,
                Matricula = x.Matricula,
                NumeroEconomico = x.NumeroEconomico,
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

        private Taxi Mapeo(TaxiViewModel model) {

            var taxi = new Taxi
            {
                Id = model.Id,
                Placa = model.Placa,
                Matricula = model.Matricula,
                NumeroEconomico = model.NumeroEconomico,
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