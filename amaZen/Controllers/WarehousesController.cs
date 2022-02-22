using System.Collections.Generic;
using amaZen.Models;
using amaZen.Services;
using Microsoft.AspNetCore.Mvc;

namespace amaZen.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class WarehousesController : ControllerBase
  {
    private readonly WarehousesService _ws;

    public WarehousesController(WarehousesService ws)
    {
      _ws = ws;
    }

    [HttpGet]
    public ActionResult<List<Warehouse>> GetAll()
    {
      try
      {
        return Ok(_ws.GetAll());
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}/products")]
    public ActionResult<List<WarehouseProductViewModel>> GetProductsByWarehouse(int id)
    {
      try
      {
        return Ok(_ws.GetProductsByWarehouse(id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}