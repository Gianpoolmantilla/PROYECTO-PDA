using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaDeAdministracion.Models;
using SistemaDeAdministracion.Models.ViewModels;

namespace SistemaDeAdministracion.Controllers
{
    public class AlumnoController : Controller
    {
        private MyDBContext _context;
        private Services.AlumnoService _AlumnoService;

        public AlumnoController(MyDBContext context, Services.AlumnoService alumnoservice)
        {
            _context = context;
            _AlumnoService = alumnoservice;
        }
        /// <summary>
        /// muestro el alumno especifico que pide el requerimiento
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult MostrarDetalleDeAlumno(string id)
        {
           
            var alumno = _AlumnoService.GetDetalleAlumno(_context, id);

            return View(alumno);
        }

        #region Alta de Alumnos
        public IActionResult Create()
        {
            ViewBag.fkgenero = _AlumnoService.fkGenero();
            ViewBag.fkcarrera = _AlumnoService.FkCarrera(_context.Carrera);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,FechaDeNacimiento,Sexo,FechaDeIngreso,Dni,Domicilio,CarreraId")] Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alumno);
                await _context.SaveChangesAsync();
                if (ModelState.ErrorCount == 0)
                {
                    return RedirectToAction(nameof(Create));
                }
            }

            return View(alumno);
        }
        #endregion




    }
}
