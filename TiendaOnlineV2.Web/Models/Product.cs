using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TiendaOnlineV2.Web.Models
{
    public class Product
    {
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        [Display(Name = "Productos")]
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Price { get; set; }
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
        [Display(Name = "Is Starred")]
        public bool IsStarred { get; set; }
        public Category Category { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; }
        [Display(Name = "Product Images Number")]
        public int ProductImagesNumber => ProductImages == null ? 0 : ProductImages.Count;
        //TODO: Pending to put the correct paths
        [Display(Name = "Imagen")]
        public string ImageFullPath => ProductImages == null || ProductImages.Count == 0 ?
            $"https://localhost:44390/images/noimage.png" : ProductImages.FirstOrDefault().ImageFullPath;
    }
}
