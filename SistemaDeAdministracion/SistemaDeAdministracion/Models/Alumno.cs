using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeAdministracion.Models
{
    public class Alumno
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo Apellido es obligatorio")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "El campo Fecha De Nacimiento es obligatorio")]
        public DateTime FechaDeNacimiento { get; set; }
        [Required(ErrorMessage = "El campo sexo es obligatorio")]
        public string Sexo { get; set; }
        [Required(ErrorMessage = "El campo FechaDeIngreso es obligatorio")]
        public DateTime FechaDeIngreso { get; set; }
        [Required(ErrorMessage = "El campo Carrera es obligatorio")]
        public int CarreraId { get; set; }
        public Carrera Carrera { get; set; }
        [Required(ErrorMessage = "El campo Dni es obligatorio")]
        public string Dni { get; set; }
        [Required(ErrorMessage = "El campo Domicilio es obligatorio")]
        public string Domicilio { get; set; }
      
    }
}
