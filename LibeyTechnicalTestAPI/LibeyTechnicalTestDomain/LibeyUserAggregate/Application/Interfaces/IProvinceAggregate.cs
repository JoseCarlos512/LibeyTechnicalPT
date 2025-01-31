using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;

public interface IProvinceAggregate
{
    List<ProvinceResponse> GetProvinces(string regionCode);
}