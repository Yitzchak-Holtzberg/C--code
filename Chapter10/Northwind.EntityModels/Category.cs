namespace Northwind.EntityModels;
using System.ComponentModel.DataAnnotations.Schema;

// Represents a category of products.
public class Category
{
    // Unique identifier of the category.
    public int CategoryID { get; set; }

    // Name of the category.
    public string CategoryName { get; set; } = null!;

    // Description of the category.
    [Column(TypeName = "ntext")]
    public string? Description { get; set; }

    // Collection of products in the category. This uses lazy loading to improve performance by loading data on demand.
    public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
}
