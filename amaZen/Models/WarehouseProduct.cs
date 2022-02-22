namespace amaZen.Models
{
  public class WarehouseProduct
  {
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int WarehouseId { get; set; }
  }

  // NOTE many to many viewmodel for client side data
  public class WarehouseProductViewModel : Product
  {
    // NOTE this is our relationship id
    public int WarehouseProductId { get; set; }
    public string Location { get; set; }
    public int ProductId { get; set; }
    public int WarehouseId { get; set; }
  }
}