using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using TiendaOnlineV2.Web.Enums;
using TiendaOnlineV2.Web.Models;

namespace TiendaOnlineV2.Web.Data.Entities
{
    public class User : IdentityUser
    {
        [MaxLength(20)]
        [Required]
        public string Document { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Apellido")]
        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }

        [MaxLength(100)]
        public string Address { get; set; }

        [Display(Name = "Image")]
        public Guid ImageId { get; set; }

        //TODO: Pending to put the correct paths
        [Display(Name = "Image")]
        public string ImageFullPath => ImageId == Guid.Empty
            ? $"https://localhost:5001/images/noimage.png"
            : $"https://tiendaonlinev2.blob.core.windows.net/users/{ImageId}";

        [Display(Name = "Tipo de Usuario")]
        public UserType UserType { get; set; }

        public City City { get; set; }

        [Display(Name = "Usuario")]
        public string FullName => $"{FirstName} {LastName}";

        [Display(Name = "Usuario")]
        public string FullNameWithDocument => $"{FirstName} {LastName} - {Document}";
    }
}

