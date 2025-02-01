import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "../../../../environments/environment";
import { LibeyUser } from "src/app/entities/libeyuser";
@Injectable({
	providedIn: "root",
})
export class LibeyUserService {
	
	constructor(private http: HttpClient) {}

	getAllUsers(): Observable<LibeyUser[]> {
		const uri = `${environment.pathLibeyTechnicalTest}LibeyUser`;
		return this.http.get<LibeyUser[]>(uri);
	}
	
	Find(documentNumber: string): Observable<LibeyUser> {
		const uri = `${environment.pathLibeyTechnicalTest}LibeyUser/${documentNumber}`;
		return this.http.get<LibeyUser>(uri);
	}

	insert(datos: any): Observable<any> {
		const uri = `${environment.pathLibeyTechnicalTest}LibeyUser`;
		return this.http.post<LibeyUser>(uri, datos);
	}
	
	save(datos: any): Observable<any> {
		const uri = `${environment.pathLibeyTechnicalTest}LibeyUser`;
		return this.http.put<LibeyUser>(uri, datos);
	}
	delete(documentNumber:any): Observable<any> {
		const uri = `${environment.pathLibeyTechnicalTest}LibeyUser/${documentNumber}`;
		return this.http.delete<LibeyUser>(uri);
	}
}