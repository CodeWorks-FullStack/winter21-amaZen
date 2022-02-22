using System.Collections.Generic;
using System.Data;
using System.Linq;
using amaZen.Interfaces;
using amaZen.Models;
using Dapper;

namespace amaZen.Repositories
{
  public class ProductsRepository : IRepo<Product>
  {
    private readonly IDbConnection _db;

    public ProductsRepository(IDbConnection db)
    {
      _db = db;
    }

    public Product Create(Product data)
    {
      throw new System.NotImplementedException();
    }

    public Product GetById(int id)
    {
      throw new System.NotImplementedException();
    }

    public Product Update(Product data)
    {
      throw new System.NotImplementedException();
    }

    internal List<Product> GetAll()
    {
      string sql = "SELECT * FROM products";
      return _db.Query<Product>(sql).ToList();
    }

    List<Product> IRepo<Product>.GetAll()
    {
      throw new System.NotImplementedException();
    }
  }
}