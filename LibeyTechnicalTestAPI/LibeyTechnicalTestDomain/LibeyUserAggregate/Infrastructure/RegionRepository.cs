using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Infrastructure;

public class RegionRepository : IRegionRepository
{
    private readonly Context _context;

    public RegionRepository(Context context)
    {
        _context = context;
    }

    public List<RegionResponse> List()
    {
        var q = _context.Regions
            .Select(region => new RegionResponse
            {
                RegionCode = region.RegionCode,
                RegionDescription = region.RegionDescription
            });

        var list = q.ToList();
        if (list.Any()) return list;
        else return new List<RegionResponse>();
    }
}