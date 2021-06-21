using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeAdministracion.Models.ViewModels
{
    public class ReporteAsignacion
    {
        public int Id { get; set; }
        public string IdCurso { get; set; }
        public string Curso { get; set; }
        public string Anio { get; set; }
        public string Semestre { get; set; }
        public string Turno { get; set; }
        public string Profesor { get; set; }       
        public string Alumno { get; set; }

    }
}
