using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeAdministracion.Services
{
    public class AlumnoService
    {
        private Models.MyDBContext _context;
        public Models.ViewModels.MostrarAlumnos GetDetalleAlumno(DbContext context, string id)
        {
            _context = (Models.MyDBContext)context;
            var LsAlumno = (from alumn in _context.Alumno
                            join carr in _context.Carrera
                            on alumn.CarreraId equals carr.Id
                            where alumn.Id == int.Parse(id)
                            select new Models.ViewModels.MostrarAlumnos
                            {
                                Nombre = alumn.Nombre,
                                Apellido = alumn.Apellido,
                                FechaDeNacimiento = alumn.FechaDeNacimiento.ToString("dd/MM/yyyy"),
                                Sexo = alumn.Sexo,
                                FechaDeIngreso = alumn.FechaDeIngreso.ToString("dd/MM/yyyy"),
                                CarreraDescripcion = carr.Nombre
                            });
            return LsAlumno.FirstOrDefault();
        }


        public List<SelectListItem> fkGenero()
        {
            List<Models.Sexo> lista = new List<Models.Sexo>();
            lista.Add(new Models.Sexo { descripcion = "Masculino" });
            lista.Add(new Models.Sexo { descripcion = "Femenino" });

            List<SelectListItem> list = lista.ConvertAll(t =>
            {
                return new SelectListItem()
                {
                    Text = t.descripcion,
                    Value = t.descripcion,
                    Selected = false
                };
            });
            return list;

        }

        public List<SelectListItem> FkCarrera(DbSet<Models.Carrera> carrera)
        {

            var Lscarrera = (from gn in carrera
                             select new Models.Carrera
                             {
                                 Id = gn.Id,
                                 Nombre = gn.Nombre
                             }).ToList();


            List<SelectListItem> list = Lscarrera.ConvertAll(t =>
            {
                return new SelectListItem()
                {
                    Text = t.Nombre.ToString(),
                    Value = t.Id.ToString(),
                    Selected = false
                };
            });
            return list;

        }
    }
}
