using System.ComponentModel.DataAnnotations.Schema; // Used to define database schema details like table and column names, types, etc.
using System.ComponentModel.DataAnnotations; // Provides attributes that are used for validating model properties.

namespace Northwind.EntityModels;

public class Product
{
    // Unique identifier for each product. This is typically the primary key in the database.
    public int ProductId { get; set; }

    // The name of the product. It is required and has a maximum length of 40 characters.
    [Required]
    [StringLength(40)]
    public string ProductName { get; set; } = null!;

    // The cost of the product. It is optional and stored in the database as a 'money' type under the name 'UnitsPrice'.
    [Column("UnitPrice", TypeName = "money")]
    public decimal? Cost { get; set; }

    // The number of units in stock for the product. Stored in the database under the name 'UnitsInStock'.
    [Column("UnitsInStock")]
    public short Stock { get; set; }

    // Indicates whether the product is discontinued. A boolean value where true means the product is no longer available.
    public bool Discontinued { get; set; }

    // The ID of the category this product belongs to. This forms a foreign key relationship with the Category table.
    public int CategoryID { get; set; }

    // Navigation property for the category. This allows for lazy loading of the category this product belongs to.
    // 'virtual' enables EF (Entity Framework) to load the category on demand, which is useful for improving performance.
    public virtual Category Category { get; set; } = null!;
}