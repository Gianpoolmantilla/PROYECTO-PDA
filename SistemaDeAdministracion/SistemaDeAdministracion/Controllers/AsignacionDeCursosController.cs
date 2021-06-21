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
    public class AsignacionDeCursosController : Controller
    {
        private  MyDBContext _context;
        private  Services.AsignacionService _AsignacionService;
        public AsignacionDeCursosController(MyDBContext context, Services.AsignacionService AsignacionService)
        {
            _context = context;
            _AsignacionService = AsignacionService;
        }

        [HttpGet]
        public IActionResult ListaDeAsignados()
        {
            ViewBag.Curso = _AsignacionService.GetFkCurso(_context.Curso);         
            List<ReporteAsignacion> DsAsignacionDeCursos = _AsignacionService.GetListaDeAsignados(_context, "0");
            return View(DsAsignacionDeCursos);
        }

        [HttpPost]
        public IActionResult ListaDeAsignados(string Curso)
        {
            ViewBag.Curso = _AsignacionService.GetFkCurso(_context.Curso);
            List<ReporteAsignacion> reporte = _AsignacionService.GetListaDeAsignados(_context, Curso);
            return View(reporte);
        }   
     
    }
}
