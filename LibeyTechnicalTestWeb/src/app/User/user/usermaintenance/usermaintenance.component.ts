import swal from 'sweetalert2';
import { Component, OnInit } from '@angular/core';
import { LibeyUser } from 'src/app/entities/libeyuser';
import { ActivatedRoute, Router } from '@angular/router';
import { LibeyUserService } from 'src/app/core/service/libeyuser/libeyuser.service';
import { Location } from '@angular/common';
import { DocumentTypeService } from 'src/app/core/service/document-type.service';
import { DocumentType } from 'src/app/entities/document-type';
import { RegionService } from 'src/app/core/service/region.service';
import { Region } from 'src/app/entities/region';
import { Province } from 'src/app/entities/province';
import { Ubigeo } from 'src/app/entities/ubigeo';
import { ProvinceService } from 'src/app/core/service/province.service';
import { UbigeoService } from 'src/app/core/service/ubigeo.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-usermaintenance',
  templateUrl: './usermaintenance.component.html',
  styleUrls: ['./usermaintenance.component.css']
})
export class UsermaintenanceComponent implements OnInit {

  usuario: LibeyUser | undefined;
  DocumentTypes: DocumentType[] = [];
  Regions: Region[] = [];
  Provinces: Province[] = [];
  Districts: Ubigeo[] = [];

  selectedRegionCode: string | null = null;
  selectedProvinceCode: string | null = null;

  documentNumber: string | null = null; 

  constructor(
    private _route: ActivatedRoute,
    private _router: Router,
    private _userService: LibeyUserService,
    private _dtService: DocumentTypeService,
    private _regionService: RegionService,
    private _provinceService: ProvinceService,
    private _districtService: UbigeoService,
    private _location: Location
  ) {}

  ngOnInit(): void {
    this.documentNumber = this._route.snapshot.paramMap.get('documentNumber');

    if (this.documentNumber != null) {
      this.loadDataForEdit(this.documentNumber);  
    }

    this.getListDocumentTypes();
    this.getListRegions();
  }

  loadDataForEdit(documentNumber: string) {
    this._userService.Find(documentNumber).subscribe(data => {
      this.usuario = data;
      this.selectedRegionCode = data.regionCode; // Cargar la región seleccionada
      this.selectedProvinceCode = data.provinceCode; // Cargar la provincia seleccionada
      
      if (this.selectedRegionCode) {
        this.getListProvinces(this.selectedRegionCode);
      }
  
      if (this.selectedProvinceCode) {
        this.getListDistricts(this.selectedProvinceCode);
      }
    });
  }

  getListDocumentTypes() {
    this._dtService.list().subscribe(
      (documentTypes) => {
        this.DocumentTypes = documentTypes;
      },
      (error) => {
        console.error('Error al obtener los tipos de documento', error);
      }
    );
  }

  getListRegions() {
    this._regionService.list().subscribe(
      (regions) => {
        this.Regions = regions;
      },
      (error) => {
        console.error('Error al obtener los tipos de documento', error);
      }
    );
  }

  getListProvinces(regionCode: string) {
    this._provinceService.list(regionCode).subscribe(
      (provinces) => {
        this.Provinces = provinces;
      },
      (error) => {
        console.error('Error al obtener los tipos de documento', error);
      }
    );
  }

  getListDistricts(provinceCode: string) {
    this._districtService.list(provinceCode).subscribe(
      (districts) => {
        this.Districts = districts;
      },
      (error) => {
        console.error('Error al obtener los tipos de documento', error);
      }
    );
  }

  // Evento al seleccionar una región
  onRegionChange(regionCode: string) {
    this.selectedRegionCode = regionCode;
    this.Provinces = []; 
    this.Districts = []; 
    if (this.usuario) {
      this.usuario!.provinceCode = "";
      this.usuario!.ubigeoCode = "";
    }
    this.selectedProvinceCode = null;
    this.getListProvinces(regionCode);
  }

  // Evento al seleccionar una provincia
  onProvinceChange(provinceCode: string) {
    this.selectedProvinceCode = provinceCode;
    this.Districts = []; 
    console.log(this.usuario)
    if (this.usuario) {
      this.usuario!.ubigeoCode = "";
    }
    this.getListDistricts(provinceCode);
  }

  Submit(userForm: NgForm){
    if (userForm.valid) {
      const datosFormulario = userForm.value; 
      
      if (this.documentNumber != null) {
        datosFormulario.documentNumber = this.documentNumber;
        this.save(datosFormulario);
      } else {
        this.insert(datosFormulario);
      }
      
    } else {
      swal.fire("Oops!", "Algunos datos del formulario no estan llenos!", "error");
    }
  }

  save(datosFormulario:any) {
    this._userService.save(datosFormulario).subscribe(
      (response) => {
        swal.fire("Éxito!", "Datos grabados correctamente", "success");
        this._router.navigate(['/user/listar']);
      },
      (error) => {
        swal.fire("Oops!", "Error al grabar los datos", "error");
      }
    );
  }

  insert(datosFormulario: any) {
    this._userService.insert(datosFormulario).subscribe(
      (response) => {
        swal.fire("Éxito!", "Datos grabados correctamente", "success");
        this._router.navigate(['/user/listar']);
      },
      (error) => {
        swal.fire("Oops!", "Error al grabar los datos", "error");
      }
    );
  }

  volver() {
    this._location.back();
  }

  clearForm(userForm: NgForm) {
    if (this.documentNumber) {
      userForm.reset({
        documentNumber: this.documentNumber
      });
    } else {
      userForm.reset();
    }
  }
}