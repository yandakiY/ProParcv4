import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { VehiculeComponent } from './vehicule.component';
import { VehiculeRoutingModule } from './vehicule-routing.module';
import { SharedModule } from '../shared/shared.module';
import { NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';




@NgModule({
  declarations: [VehiculeComponent],
  imports: [
    CommonModule,
    VehiculeRoutingModule,
    SharedModule,
    NgbDatepickerModule,
  ]
})
export class VehiculeModule { }
