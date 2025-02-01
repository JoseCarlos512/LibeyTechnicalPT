﻿using LibeyTechnicalTestDomain.LibeyUserAggregate.Application.DTO;

namespace LibeyTechnicalTestDomain.LibeyUserAggregate.Application.Interfaces;

public interface IDocumentTypeAggregate
{
    List<DocumentTypeResponse> GetDocumentTypes();
}