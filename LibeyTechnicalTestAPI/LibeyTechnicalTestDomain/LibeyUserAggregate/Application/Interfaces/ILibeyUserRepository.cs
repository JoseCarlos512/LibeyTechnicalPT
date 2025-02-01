using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces
{
    public interface ILibeyUserRepository
    {
        List<LibeyUserResponse> List(CancellationToken cancellationToken = default);
        LibeyUserResponse FindResponse(string documentNumber);
        void Create(LibeyUser libeyUser);
        void Update(LibeyUser libeyUser);
        void Delete(LibeyUser libeyUser);
        bool ExistsDocumentNumber(string documentNumber);
        bool ExistsUbigeoCode(string ubigeoCode);
    }
}
