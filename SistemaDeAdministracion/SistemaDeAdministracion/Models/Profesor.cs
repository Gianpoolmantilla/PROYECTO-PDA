using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeAdministracion.Models
{
    public class Profesor
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo Apellido es obligatorio")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "El campo Fecha De Nacimiento es obligatorio")]
        public DateTime FechaDeNacimiento { get; set; }
        [Required(ErrorMessage = "El campo Dni es obligatorio")]

        public string Dni { get; set; }
        [Required(ErrorMessage = "El campo Sexo  es obligatorio")]      
        public string Sexo { get; set; }

    }
}
