using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application;

public class UbigeoAggregate : IUbigeoAggregate
{
    private readonly IUbigeoRepository _repository;
    
    public UbigeoAggregate(IUbigeoRepository repository)
    {
        _repository = repository;
    }
    
    public List<UbigeoResponse> GetDistricts(string provinceCode)
    {
        var list = _repository.List(provinceCode );
        return list;
    }
}