using LibeyTechnicalTestDomain.EFCore;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate;

public class DocumentTypeRepository : IDocumentTypeRepository
{
    private readonly Context _context;
    
    public DocumentTypeRepository(Context context)
    {
        _context = context;
    }
    
    public List<DocumentTypeResponse> List()
    {
        var q = _context.DocumentTypes
            .Select(dt => new DocumentTypeResponse()
            {
                DocumentTypeId = dt.DocumentTypeId,
                DocumentTypeDescription = dt.DocumentTypeDescription
            });
        var list = q.ToList();
        if (list.Any()) return list;
        else return new List<DocumentTypeResponse>();
    }
}