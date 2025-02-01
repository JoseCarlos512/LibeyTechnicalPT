using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Infrastructure;

public class ProvinceRepository : IProvinceRepository
{
    private readonly Context _context;

    public ProvinceRepository(Context context)
    {
        _context = context;
    }

    public List<ProvinceResponse> List(string regionCode)
    {
        var q = from province in _context.Provinces.Where(x => x.RegionCode == regionCode)
            select new ProvinceResponse()
            {
                ProvinceCode = province.ProvinceCode,
                RegionCode = province.RegionCode,
                ProvinceDescription = province.ProvinceDescription
            };

        var list = q.ToList();
        if (list.Any()) return list;
        else return new List<ProvinceResponse>();
    }
}