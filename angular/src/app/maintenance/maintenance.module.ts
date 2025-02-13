import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaintenanceRoutingModule } from './maintenance-routing.module';
import { SharedModule } from '../shared/shared.module';
import { MaintenanceComponent } from './maintenance.component';
import { NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';



@NgModule({
  declarations: [MaintenanceComponent],
  imports: [
    CommonModule,
    MaintenanceRoutingModule,
    SharedModule,
    NgbDatepickerModule,
  ]
})
export class MaintenanceModule { }
