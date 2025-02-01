import swal from 'sweetalert2';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LibeyUserService } from 'src/app/core/service/libeyuser/libeyuser.service';
import { LibeyUser } from 'src/app/entities/libeyuser';

@Component({
  selector: 'app-usertable',
  templateUrl: './usertable.component.html',
  styleUrls: ['./usertable.component.css']
})
export class UsertableComponent implements OnInit {

  usuarios: LibeyUser[] = [];
  usuariosFiltrados: LibeyUser[] = [];
  searchText: string = '';

  constructor(
    private _userService: LibeyUserService,
    private _router: Router
  ) { }

  ngOnInit(): void {
    this.obtenerUsuarios();
  }

  obtenerUsuarios() {
    this._userService.getAllUsers().subscribe({
      next: (data) => {
        this.usuarios = data;
        this.usuariosFiltrados = data; 
      },
      error: (error) => {
        console.error("Error al obtener los usuarios", error);
      }
    });
  }

  filtrarUsuarios() {
    const texto = this.searchText.toLowerCase();
    this.usuariosFiltrados = this.usuarios.filter(user =>
      user.documentNumber.toLowerCase().includes(texto) ||
      user.name.toLowerCase().includes(texto) ||
      user.email.toLowerCase().includes(texto)
    );
  }

  eliminarUsuario(documentNumber: string) {
    swal.fire({
      title: "¿Estás seguro?",
      text: "Esta acción no se puede deshacer.",
      icon: "warning",
      showCancelButton: true,
      confirmButtonColor: "#d33",
      cancelButtonColor: "#3085d6",
      confirmButtonText: "Sí, eliminar",
      cancelButtonText: "Cancelar"
    }).then((result) => {
      if (result.isConfirmed) {
        this._userService.delete(documentNumber).subscribe({
          next: (data) => {
            this.obtenerUsuarios();
            swal.fire("Eliminado", "El usuario ha sido eliminado.", "success");
          },
          error: (error) => {
            console.error("Error al eliminar el usuario", error);
            swal.fire("Error", "No se pudo eliminar el usuario.", "error");
          }
        });
      }
    });
  }
  

  editarUsuario(usuario: LibeyUser) {
    this._router.navigate(['/user/editar', usuario.documentNumber]);

  }
}
