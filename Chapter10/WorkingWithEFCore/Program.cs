var resultAdd = AddProduct(categoryId: 1, productName: "Test Product", price: 10.0M, stock: 10);

if (resultAdd.affected > 0)
{
  Info($"Product added with ID: {resultAdd.productId}");
}
else
{
  Fail("Product not added.");
}


ListProducts(new int[] { resultAdd.productId });


var resultUpdate = ChangeProductPrice("Test", 20.0M);

if (resultUpdate.affected > 0)
{
  Info($"Product updated with ID: {resultUpdate.productId}");
}
else
{
  Fail("Product not updated.");
}

ListProducts(new int[] { resultUpdate.productId });

