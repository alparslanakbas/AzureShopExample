namespace AzureShop.Cart.Function;

public class ProductEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public Guid OrderId { get; set; }
}