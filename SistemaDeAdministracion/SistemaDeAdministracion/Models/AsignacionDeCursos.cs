using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeAdministracion.Models
{
    public class AsignacionDeCursos
    {
        public int Id { get; set; }
        public int CursoId { get; set; }
        public Curso Curso { get; set; }
        public string Anio { get; set; }
        public int Semestre { get; set; }
        public int TurnoId { get; set; }
        public Turno Turno { get; set; }
        public int ProfesorId { get; set; }
        public Profesor Profesor { get; set; }
        public List<ItemsAsignacionDeCursos> ItemsAsignacionDeCursos { get; set; }
    }
}
