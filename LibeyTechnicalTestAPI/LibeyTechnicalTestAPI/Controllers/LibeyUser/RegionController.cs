﻿using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibeyTechnicalTestAPI.Controllers.LibeyUser;

[ApiController]
[Route("[controller]")]
public class RegionController : Controller
{
    private readonly IRegionAggregate _aggregate;
    
    public RegionController(IRegionAggregate aggregate)
    {
        _aggregate = aggregate;
    }
    
    [HttpGet]
    public IActionResult List()
    {
        var row = _aggregate.GetRegions();
        return Ok(row);
    }
}