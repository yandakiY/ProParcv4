import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { authGuard, permissionGuard } from '@abp/ng.core';
import { VehiculeComponent } from './vehicule.component';

const routes: Routes = [
  { path: '', component: VehiculeComponent , canActivate: [authGuard, permissionGuard] },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class VehiculeRoutingModule {}
