using amaZen.Models;
using amaZen.Services;
using Microsoft.AspNetCore.Mvc;

namespace amaZen.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class WarehouseProductsController : ControllerBase
  {
    private readonly WarehouseProductsService _wps;

    public WarehouseProductsController(WarehouseProductsService wps)
    {
      _wps = wps;
    }

    [HttpPost]

    public ActionResult<WarehouseProduct> Create([FromBody] WarehouseProduct newWarehouseProduct)
    {
      try
      {
        return Ok(_wps.Create(newWarehouseProduct));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}