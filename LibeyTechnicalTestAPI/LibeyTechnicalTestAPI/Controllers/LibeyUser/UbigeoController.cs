using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibeyTechnicalTestAPI.Controllers.LibeyUser;

[ApiController]
[Route("[controller]")]
public class UbigeoController : Controller
{
    private readonly IUbigeoAggregate _aggregate;
    
    public UbigeoController(IUbigeoAggregate ubigeoAggregate)
    {
        _aggregate = ubigeoAggregate;
    }
    
    [HttpGet]
    [Route("{provinceCode}")]
    public IActionResult List(string provinceCode)
    {
        var row = _aggregate.GetDistricts(provinceCode);
        return Ok(row);
    }
}