import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AppComponent } from "./app.component";
import { UsercardsComponent } from "./User/user/usercards/usercards.component";
import { UsermaintenanceComponent } from "./User/user/usermaintenance/usermaintenance.component";
import { UsertableComponent } from "./User/user/usertable/usertable.component";
const routes: Routes = [
	{
		path: "",
		redirectTo: "/user",
		pathMatch: "full",
	},
	{
		path: "user",
		children: [
			{ path: "principal", component: UsercardsComponent },
			{ path: "listar", component: UsertableComponent },
			
			{ path: "crear", component: UsermaintenanceComponent },
			{ path: "editar/:documentNumber", component: UsermaintenanceComponent },
		],
	},
	{ path: "**", component: AppComponent },
];
@NgModule({
	imports: [RouterModule.forRoot(routes)],
	exports: [RouterModule],
})
export class AppRoutingModule {}