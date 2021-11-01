using System.ComponentModel.DataAnnotations;

namespace NasaWeb.Api.Models
{
    public class Asteroids
    {
        [Required]
        public string Nombre { get; set; }

        public double Diametro { get; set; }

        [Required]
        public double Velocidad { get; set; }

        [Required]
        public string Fecha { get; set; }

        [Required]
        public string Planeta { get; set; }
    }
}
