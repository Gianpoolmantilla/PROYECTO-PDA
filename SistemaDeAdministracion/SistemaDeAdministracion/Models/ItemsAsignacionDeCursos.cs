using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeAdministracion.Models
{
    public class ItemsAsignacionDeCursos
    {
        [Key]
        public int Id { get; set; }
        public int AlumnoId { get; set; }
        public Alumno Alumno { get; set; }

        public int AsignacionDeCursosId { get; set; }
        public AsignacionDeCursos AsignacionDeCursos { get; set; }

    }
}
