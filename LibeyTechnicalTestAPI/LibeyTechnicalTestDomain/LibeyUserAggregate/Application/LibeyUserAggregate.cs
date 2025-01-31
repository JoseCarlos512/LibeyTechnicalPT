using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Exceptions;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application
{
    public class LibeyUserAggregate : ILibeyUserAggregate
    {
        private readonly ILibeyUserRepository _repository;
        public LibeyUserAggregate(ILibeyUserRepository repository)
        {
            _repository = repository;
        }
        public List<LibeyUserResponse> List()
        {
            var list = _repository.List();
            return list;
        }
        public LibeyUserResponse FindResponse(string documentNumber)
        {
            var row = _repository.FindResponse(documentNumber);
            return row;
        }
        public void Create(UserUpdateorCreateCommand command)
        {
            if (_repository.ExistsDocumentNumber(command.DocumentNumber))
            {
                throw new CustomValidationException(
                    "DOCUMENT_NUMBER_IN_USE",
                    "El número de documento que has ingresado ya está en uso. Por favor, utiliza otro número."
                );
            }

            if (!_repository.ExistsUbigeoCode(command.UbigeoCode))
            {
                throw new CustomValidationException(
                    "INVALID_UBIGEO_CODE",
                    "El código de Ubigeo ingresado no es válido. Verifica el código y vuelve a intentarlo."
                );
            }
            
            var libeyUser = new LibeyUser(
                command.DocumentNumber,
                command.DocumentTypeId,
                command.Name,
                command.FathersLastName,
                command.MothersLastName,
                command.Address,
                command.UbigeoCode,
                command.Phone,
                command.Email,
                command.Password
            );
            _repository.Create(libeyUser);
        }

        public void Update(UserUpdateorCreateCommand command)
        {
            var libeyUser = new LibeyUser(
                command.DocumentNumber,
                command.DocumentTypeId,
                command.Name,
                command.FathersLastName,
                command.MothersLastName,
                command.Address,
                command.UbigeoCode,
                command.Phone,
                command.Email,
                command.Password
            );
            _repository.Update(libeyUser);
        }

        public void Delete(string documentNumber)
        {
            var libeyUserResponse = _repository.FindResponse(documentNumber);
            var libeyUser = new LibeyUser(
                libeyUserResponse.DocumentNumber,
                libeyUserResponse.DocumentTypeId,
                libeyUserResponse.Name,
                libeyUserResponse.FathersLastName,
                libeyUserResponse.MothersLastName,
                libeyUserResponse.Address,
                libeyUserResponse.UbigeoCode,
                libeyUserResponse.Phone,
                libeyUserResponse.Email,
                libeyUserResponse.Password
            );
            _repository.Delete(libeyUser);
        }
    }
}