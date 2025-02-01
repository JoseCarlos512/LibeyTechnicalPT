using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;
using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application;

public class DocumentTypeAggregate : IDocumentTypeAggregate
{
    private readonly IDocumentTypeRepository _repository;

    public DocumentTypeAggregate(IDocumentTypeRepository repository)
    {
        _repository = repository;
    }

    public List<DocumentTypeResponse> GetDocumentTypes()
    {
        var list = _repository.List();
        return list;
    }
}