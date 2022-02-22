using System.Collections.Generic;
using System.Data;
using System.Linq;
using amaZen.Models;
using Dapper;

namespace amaZen.Repositories
{
  public class WarehousesRepository
  {
    private readonly IDbConnection _db;

    public WarehousesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<Warehouse> GetAll()
    {
      string sql = @"SELECT * FROM warehouses";
      return _db.Query<Warehouse>(sql).ToList();
    }

    internal List<WarehouseProductViewModel> GetProductsByWarehouse(int id)
    {
      string sql = @"
      SELECT
      p.*,
      w.location,
      wp.id AS warehouseProductId,
      wp.productId,
      wp.warehouseId
      FROM warehouse_products wp
      JOIN warehouses w ON w.id = wp.warehouseId
      JOIN products p on p.id = wp.productId
      WHERE wp.warehouseId = @id;";
      return _db.Query<WarehouseProductViewModel>(sql, new { id }).ToList();
    }
  }
}