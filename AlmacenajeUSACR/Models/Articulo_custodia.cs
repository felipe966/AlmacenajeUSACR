using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlmacenajeUSACR.Models
{
    public class Articulo_custodia
    {

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo requerido"), Range(1000, 9999)]
        [Display(Name = "Código del cliente")]
        public int Codigo_cliente { get; set; }
        [Required(ErrorMessage = "Campo requerido"), Range(100, 999)]
        [Display(Name = "Código del transportista")]
        public int Codigo_transportista { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [MaxLength(18)]
        public string TrackingID { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Descripción")]
        [MaxLength(100)]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Peso en Kg")]
        public float Peso { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Precio del articulo en USD")]
        public float Precio_articulo { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Fecha de ingreso")]
        [DataType(DataType.Date)]
        public DateTime Fecha_ingreso { get; set; }

        public string Estado { get; set; } = "Pendiente retiro";


        [DataType(DataType.Date)]
        [Display(Name = "Fecha de retiro")]
        public DateTime Fecha_retiro { get; set; }


    }
}
