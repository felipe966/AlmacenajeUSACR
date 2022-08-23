using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AlmacenajeUSACR.Models
{
    public class Cliente
    {

        [Key]
        public int Id { get; set; }
        public int Codigo_cliente { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Nombre completo")]
        [MaxLength(30)]
        public string Nombre_completo { get; set; }
        [Required(ErrorMessage = "Campo requerido"), Range(100000000, 999999999)]
        [Display(Name = "Número de identificación")]
        [MaxLength(9)]
        public string Numero_identificacion { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Fecha de  nacimiento")]
        [DataType(DataType.Date)]
        public DateTime Fecha_nacimiento { get; set; }


    }
}
