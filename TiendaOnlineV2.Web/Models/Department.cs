using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TiendaOnlineV2.Web.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Display(Name = "Pais")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe contener al menos un caracter")]
        public string Name { get; set; }
        public ICollection<City> Cities { get; set; }
        [Display(Name = "Numero de ciudades")]
        public int CitiesNumber => Cities == null ? 0 : Cities.Count;
    }
}
