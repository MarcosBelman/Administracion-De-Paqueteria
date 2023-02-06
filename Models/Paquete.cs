using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AdministracionDePaqueteria.Models
{
    public class Paquete
    {
        [Key]
        public long codRastreo  {get; set;}

        [Required]
        [MaxLength(20)]
        public string idPaquete {get; set;}

        [Required]
        public int numPieza {get; set;}

        [Required]
        public DateTime fechaHora {get; set;}

        [Required]
        [MaxLength(80)]
        public string areaServicio {get; set;}

        [Required]
        [MaxLength(80)]
        public string estadoActual {get; set;}
    }
}