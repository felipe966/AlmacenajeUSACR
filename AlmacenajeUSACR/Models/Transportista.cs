using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlmacenajeUSACR.Models
{
    public class Transportista
    {
        [Key]
        public int Id { get; set; }
        public int Codigo_transportista { get; set; }    
        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Nombre de la empresa")]
        [MaxLength(30)]
        public string Nombre_empresa { get; set; }    
    }
}
