using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeAdministracion.Models.ViewModels
{
    public class MostrarAlumnos
    {
        public string Id { get; set; }

        public string Nombre { get; set; }
     
        public string Apellido { get; set; }
   
        public string FechaDeNacimiento { get; set; }

        public string GeneroId { get; set; }
        public string GeneroDescripcion { get; set; }
       
        public string FechaDeIngreso { get; set; }       
        public string CarreraId { get; set; }
        public string CarreraDescripcion { get; set; }
        public string Dni { get; set; }
  
        public string Domicilio { get; set; }
        public string Sexo { get; set; }
    }
}
