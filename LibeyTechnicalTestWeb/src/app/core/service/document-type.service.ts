import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DocumentType } from 'src/app/entities/document-type';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DocumentTypeService {

  constructor(private http: HttpClient) {}
  
  list(): Observable<DocumentType[]> {
    const uri = `${environment.pathLibeyTechnicalTest}DocumentType`;
    return this.http.get<DocumentType[]>(uri);
  }
}
