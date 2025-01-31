using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibeyTechnicalTestAPI.Controllers.LibeyUser;

[ApiController]
[Route("[controller]")]
public class ProvinceController : Controller
{
    private readonly IProvinceAggregate _aggregate;
    public ProvinceController(IProvinceAggregate aggregate)
    {
        _aggregate = aggregate;
    }
    
    [HttpGet]
    [Route("{regionCode}")]
    public IActionResult FindResponse(string regionCode)
    {
        var row = _aggregate.GetProvinces(regionCode);
        return Ok(row);
    }
}