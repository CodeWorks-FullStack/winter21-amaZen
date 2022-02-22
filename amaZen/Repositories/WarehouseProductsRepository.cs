using System.Data;
using amaZen.Models;
using Dapper;

namespace amaZen.Repositories
{
  public class WarehouseProductsRepository
  {
    private readonly IDbConnection _db;

    public WarehouseProductsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal WarehouseProduct Create(WarehouseProduct newWarehouseProduct)
    {
      string sql = @"
     INSERT INTO warehouse_products (productId, warehouseId)
     VALUES (@ProductId, @WarehouseId);
     SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, newWarehouseProduct);
      newWarehouseProduct.Id = id;
      return newWarehouseProduct;
    }
  }
}