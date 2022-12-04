using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebPasajero.Models
{
    public class Pasajero
    {
        public int PasajeroId { get; set; }

        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Display(Name = "Apellido")]
        public string Apellido { get; set; }

        public string Ciudad { get; set; }
        public int FechaNacimiento { get; set; }
    }
}
