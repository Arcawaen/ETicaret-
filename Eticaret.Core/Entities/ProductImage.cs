using System.ComponentModel.DataAnnotations;

namespace Eticaret.Core.Entities
{
    public class ProductImage : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Ürün")]
        public int ProductId { get; set; }
        [Display(Name = "Resim"), StringLength(100)]
        public string? Image { get; set; }
        [Display(Name = "Ürün")]
        public Product? Product { get; set; }
    }
}
