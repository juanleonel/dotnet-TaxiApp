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
    public class ChoferController : Controller
    {

        private readonly IChofer _Chofer;
        private readonly ILogger<ChoferController> _logger;

        public ChoferController(ILogger<ChoferController> logger, IChofer IChofer)
        {
            _Chofer = IChofer;
            _logger = logger;
        }

        #region CRUD
        public ActionResult Index()
        {
            var chofers = _Chofer.GetAll();

            var models = Mapeo(chofers);

            return View(models);
        }
         
       
        public ActionResult Create()
        {
            return View(new ChoferViewModel());
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ChoferViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return RedirectToAction(nameof(Index));
                }



                var chofer = Mapeo(model);
                chofer.Id = Guid.NewGuid();
                chofer.FechaAlta = DateTime.Now;
                chofer.UsuarioAltaID = Guid.NewGuid();
                
                _Chofer.Create(chofer);

                // TODO: Add insert logic here

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

        #endregion

        #region InicioTurno

        public ActionResult  IniciaTurno() 
        {
            try
            {

                var result = _Chofer.IniciaTurno(new Guid("BDC31686-22AB-4217-8F78-4D020D70DB7D"), new Guid("5D204F1B-9AE3-4349-94FC-1A500CED8052"), DateTime.Now);
                if (result != null)
                {
                    var turno = _Chofer.GetTurnoByID(result.ID);

                }

                return null;
            }
            catch (Exception ex)
            {
                return View();
            }
            return null;
        }

        #endregion

        #region Mapeo

        private List<ChoferViewModel> Mapeo(IList<Chofer> chofers)
        {

            var models = chofers.Select(x => new ChoferViewModel
            {
                Id = x.Id,
                Nombre = x.Nombre,
                PrimerApellido = x.PrimerApellido,
                SegundoApellido = x.SegundoApellido,
                Edad = x.Edad,
                Email = x.Email,
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

        private ChoferViewModel Mapeo(Chofer chofer)
        {

            var model = new ChoferViewModel
            {
                Id = chofer.Id,
                Nombre = chofer.Nombre,
                PrimerApellido = chofer.PrimerApellido,
                SegundoApellido = chofer.SegundoApellido,
                Edad = chofer.Edad,
                Email = chofer.Email,
                FechaAlta = chofer.FechaAlta,
                UsuarioAltaID = chofer.UsuarioAltaID,
                Baja = chofer.Baja,
                FechaBaja = chofer.FechaBaja,
                FechaMod = chofer.FechaMod,
                UsuarioBajaID = chofer.UsuarioBajaID,
                UsuarioModID = chofer.UsuarioModID
            };

            return model;
        }

        private List<Chofer> Mapeo(IList<ChoferViewModel> models)
        {

            var chofers = models.Select(x => new Chofer
            {
                Id = x.Id,
                Nombre = x.Nombre,
                PrimerApellido = x.PrimerApellido,
                SegundoApellido = x.SegundoApellido,
                Edad = x.Edad,
                Email = x.Email,
                FechaAlta = x.FechaAlta,
                UsuarioAltaID = x.UsuarioAltaID,
                Baja = x.Baja,
                FechaBaja = x.FechaBaja,
                FechaMod = x.FechaMod,
                UsuarioBajaID = x.UsuarioBajaID,
                UsuarioModID = x.UsuarioModID
            }).ToList();

            return chofers;
        }

        private Chofer Mapeo(ChoferViewModel model)
        {

            var taxi = new Chofer
            {
                Id = model.Id,
                Nombre = model.Nombre,
                PrimerApellido = model.PrimerApellido,
                SegundoApellido = model.SegundoApellido,
                Edad = model.Edad,
                Email = model.Email,
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

        public static bool SaveFileToDisk(IFormFile file)
        {

         

            return true;
        }

        private void SaveFileToDisk(HttpPostedFileBase file)
        {
            WebImage img = new WebImage(file.InputStream);
            if (img.Width > 190)
            {
                img.Resize(190, img.Height);
            }
            img.Save(Constants.ProductImagePath + file.FileName);
            if (img.Width > 100)
            {
                img.Resize(100, img.Height);
            }
            img.Save(Constants.ProductThumbnailPath + file.FileName);
        }
    }
}