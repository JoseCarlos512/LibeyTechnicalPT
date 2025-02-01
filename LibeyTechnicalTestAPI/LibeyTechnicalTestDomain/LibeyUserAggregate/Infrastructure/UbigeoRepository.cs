using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Infrastructure;

public class UbigeoRepository : IUbigeoRepository
{
    private readonly Context _context;

    public UbigeoRepository(Context context)
    {
        _context = context;
    }

    public List<UbigeoResponse> List(string provinceCode)
    {
        var q = from ubigeo in _context.Ubigeos.Where(x => x.ProvinceCode == provinceCode)
            select new UbigeoResponse()
            {
                UbigeoCode = ubigeo.UbigeoCode,
                RegionCode = ubigeo.RegionCode, 
                ProvinceCode = ubigeo.ProvinceCode,
                UbigeoDescription = ubigeo.UbigeoDescription
            };

        var list = q.ToList();
        if (list.Any()) return list;
        else return new List<UbigeoResponse>();
    }
}