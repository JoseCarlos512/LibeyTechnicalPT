using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Domain;
using Microsoft.EntityFrameworkCore;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Infrastructure
{
    public class LibeyUserRepository : ILibeyUserRepository
    {
        private readonly Context _context;
        public LibeyUserRepository(Context context)
        {
            _context = context;
        }

        public void Create(LibeyUser libeyUser)
        {
            _context.LibeyUsers.Add(libeyUser);
            _context.SaveChanges();
        }

        public void Update(LibeyUser libeyUser)
        {
            _context.LibeyUsers.Update(libeyUser);
            _context.SaveChanges();
        }

        public void Delete(LibeyUser libeyUser)
        {
            _context.LibeyUsers.Remove(libeyUser);
            _context.SaveChanges();
        }

        public List<LibeyUserResponse> List(CancellationToken cancellationToken = default)
        {
            var q = from libeyUser in _context.LibeyUsers.Where(x => x.Active == true)
                join ubigeo in _context.Ubigeos on libeyUser.UbigeoCode equals ubigeo.UbigeoCode
                select new LibeyUserResponse()
                {
                    DocumentNumber = libeyUser.DocumentNumber,
                    Active = libeyUser.Active,
                    Address = libeyUser.Address,
                    UbigeoCode = libeyUser.UbigeoCode,
                    DocumentTypeId = libeyUser.DocumentTypeId,
                    Email = libeyUser.Email,
                    FathersLastName = libeyUser.FathersLastName,
                    MothersLastName = libeyUser.MothersLastName,
                    Name = libeyUser.Name,
                    Password = libeyUser.Password,
                    Phone = libeyUser.Phone,
                    RegionCode = ubigeo.RegionCode, 
                    ProvinceCode = ubigeo.ProvinceCode
                };
            var list = q.ToList();
            if (list.Any()) return list;
            else return new List<LibeyUserResponse>();
        }

        public LibeyUserResponse FindResponse(string documentNumber)
        {

            var q = 
                from libeyUser in _context.LibeyUsers.Where(x => x.DocumentNumber.Equals(documentNumber) && x.Active == true)
                join ubigeo in _context.Ubigeos on libeyUser.UbigeoCode equals ubigeo.UbigeoCode
                select new LibeyUserResponse()
                    {
                        DocumentNumber = libeyUser.DocumentNumber,
                        Active = libeyUser.Active,
                        Address = libeyUser.Address,
                        UbigeoCode = libeyUser.UbigeoCode,
                        DocumentTypeId = libeyUser.DocumentTypeId,
                        Email = libeyUser.Email,
                        FathersLastName = libeyUser.FathersLastName,
                        MothersLastName = libeyUser.MothersLastName,
                        Name = libeyUser.Name,
                        Password = libeyUser.Password,
                        Phone = libeyUser.Phone,
                        RegionCode = ubigeo.RegionCode, 
                        ProvinceCode = ubigeo.ProvinceCode
                    };
            var list = q.ToList();
            if (list.Any()) return list.First();
            else return new LibeyUserResponse();
        }
        
        public bool ExistsDocumentNumber(string documentNumber)
        {
            return _context.LibeyUsers.Any(u => u.DocumentNumber == documentNumber);
        }

        public bool ExistsUbigeoCode(string ubigeoCode)
        {
            return _context.Ubigeos.Any(u => u.UbigeoCode == ubigeoCode);
        }
    }
}