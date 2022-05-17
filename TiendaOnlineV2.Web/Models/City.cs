using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TiendaOnlineV2.Web.Models
{
    public class City
    {
        public int Id { get; set; }
        [Display(Name = "Ciudad")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe contener al menos un caracter")]
        public string Name { get; set; }

        [JsonIgnore]
        [NotMapped] //no se crea en la base de datos
        public int IdDepartment { get; set; }
    }
}
