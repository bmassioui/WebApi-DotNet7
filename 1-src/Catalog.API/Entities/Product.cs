using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalog.API.Entities;

[Table("Product")]
public class Product: BaseEntity
{
    [Required(ErrorMessage = "Image Url is required.", AllowEmptyStrings = false)]
    public required Uri ImageUrl { get; set; }

    [Required(ErrorMessage = "Name is required.", AllowEmptyStrings = false)]
    [StringLength(maximumLength:200, MinimumLength = 5, ErrorMessage = "Name should be between 5 and 200 characters.")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [Range(1, 5, ErrorMessage = "Rating should be between 1 and 5.")]
    public float Rating { get; set; }

    [StringLength(maximumLength:200, ErrorMessage = "Description should be less than 200 characters.")]
    public string Description { get; set; } = string.Empty;

    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Price should be bigger than {1}")]
    [DataType(DataType.Currency)]
    public decimal Price { get; set; }
}
