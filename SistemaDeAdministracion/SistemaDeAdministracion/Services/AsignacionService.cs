using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaDeAdministracion.Models;
using SistemaDeAdministracion.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeAdministracion.Services
{
    public class AsignacionService
    {
        private MyDBContext _context;

        /// <summary>
        /// recupero datos de tabla de curso
        /// </summary>
        /// <param name="Curso"></param>
        /// <returns></returns>
        public List<SelectListItem> GetFkCurso(DbSet<Curso> Curso)
        {
            var Fkcurso = (from t in Curso
                           select new Curso
                           {
                               Id = t.Id,
                               Nombre = t.Nombre
                           }).ToList();

            List<SelectListItem> itemsCurso = Fkcurso.ConvertAll(t =>
            {
                return new SelectListItem()
                {
                    Text = t.Nombre.ToString(),
                    Value = t.Id.ToString(),
                    Selected = false
                };
            });
            return itemsCurso;
        }

        /// <summary>
        /// recupero los datos de la tabla Asignacion De cursos.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="Curso"></param>
        /// <returns></returns>
        public List<ReporteAsignacion> GetListaDeAsignados(DbContext context, string Curso)
        {
           _context = (MyDBContext)context;

            var list = (from As in _context.AsignacionDeCursos
                        join it in _context.ItemsAsignacionDeCursos
                        on As.Id equals it.AsignacionDeCursosId
                        join alum in _context.Alumno
                         on it.AlumnoId equals alum.Id
                        join cur in _context.Curso
                       on As.CursoId equals cur.Id
                        join prof in _context.Profesor
                       on As.ProfesorId equals prof.Id
                        join tur in _context.Turno
                         on As.TurnoId equals tur.Id
                         

                        select new ReporteAsignacion
                        {
                            Id = As.Id,
                            IdCurso = cur.Id.ToString(),
                            Curso = cur.Nombre,
                            Anio = As.Anio.ToString(),
                            Semestre = As.Semestre.ToString(),
                            Turno = tur.Descripcion,
                            Profesor = prof.Nombre,
                            Alumno = alum.Nombre                     
                           
                        });

            if (!string.IsNullOrEmpty(Curso))
            {
                list = list.Where(t => t.IdCurso == Curso);
            }

            return list.ToList();
        }


    }



}

