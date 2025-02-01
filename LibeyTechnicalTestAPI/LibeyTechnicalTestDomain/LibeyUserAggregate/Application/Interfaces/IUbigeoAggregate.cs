using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;

public interface IUbigeoAggregate
{
    List<UbigeoResponse> GetDistricts(string provinceCode);
}