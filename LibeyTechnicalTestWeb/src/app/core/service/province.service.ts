import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Province } from 'src/app/entities/province';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProvinceService {

  constructor(private http: HttpClient) {}

  list(regionCode:string): Observable<Province[]> {
    const uri = `${environment.pathLibeyTechnicalTest}Province/${regionCode}`;
    return this.http.get<Province[]>(uri);
  }
}
