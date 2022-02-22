using amaZen.Models;
using amaZen.Repositories;

namespace amaZen.Services
{
  public class WarehouseProductsService
  {
    private readonly WarehouseProductsRepository _repo;

    public WarehouseProductsService(WarehouseProductsRepository repo)
    {
      _repo = repo;
    }

    internal WarehouseProduct Create(WarehouseProduct newWarehouseProduct)
    {
      return _repo.Create(newWarehouseProduct);
    }
  }
}