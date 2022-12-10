using System.ComponentModel.DataAnnotations;

namespace Catalog.API.Models;

public record ReadProduct
{
    public Guid Id { get; set; }
    public required Uri ImageUrl { get; set; }
    public required string Name { get; set; }
    public float Rating { get; set; }
    public string? Description { get; set; }
    [DataType(DataType.Currency)]
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdateAt { get; set; }
    public bool IsDeleted { get; set; }
}
