using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibeyTechnicalTestAPI.Controllers.LibeyUser;

[ApiController]
[Route("[controller]")]
public class DocumentTypeController : Controller
{
    private readonly IDocumentTypeAggregate _aggregate;
    
    public DocumentTypeController(IDocumentTypeAggregate aggregate)
    {
        _aggregate = aggregate;
    }
    
    [HttpGet]
    public IActionResult List()
    {
        var row = _aggregate.GetDocumentTypes();
        return Ok(row);
    }
}