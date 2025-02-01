import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Ubigeo } from 'src/app/entities/ubigeo';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UbigeoService {

  constructor(private http: HttpClient) {}

  list(provinceCode: string): Observable<Ubigeo[]> {
    const uri = `${environment.pathLibeyTechnicalTest}Ubigeo/${provinceCode}`;
    return this.http.get<Ubigeo[]>(uri);
  }
}
