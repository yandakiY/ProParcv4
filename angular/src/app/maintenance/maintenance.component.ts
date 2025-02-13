import { ListService, PagedResultDto } from '@abp/ng.core';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateAdapter, NgbDateNativeAdapter } from '@ng-bootstrap/ng-bootstrap';
import { MaintenanceDto, MaintenanceService } from '@proxy/maintenances';
import { VehiculeService } from '@proxy/vehicules';
import { map } from 'rxjs';

@Component({
  selector: 'app-maintenance',
  templateUrl: './maintenance.component.html',
  styleUrl: './maintenance.component.scss',
  providers: [ListService, { provide: NgbDateAdapter, useClass: NgbDateNativeAdapter }],
})
export class MaintenanceComponent implements OnInit {

    maintenance = { items: [], totalCount: 0 } as PagedResultDto<MaintenanceDto>;
    vehicules: any[]
    selectedMaintenance = {} as MaintenanceDto; // declare selectedBook
  
    form: FormGroup;
    isModalOpen = false;
  
    constructor(
      public readonly list: ListService,
      private readonly vehiculeService: VehiculeService,
      private readonly maintenanceService: MaintenanceService,
      private readonly fb: FormBuilder,
      private readonly confirmation: ConfirmationService // inject the ConfirmationService
    ) {}
  
    ngOnInit() {

      this.vehiculeService.getAll().subscribe({
        next : (res: any) => {
          console.log("Res", res)
          this.vehicules = res
        },
        error: (err) => {
          console.error("Error", err)
        }
      })
      const maintenanceStreamCreator = (query) => this.maintenanceService.getAll(query).pipe(
        map((response: MaintenanceDto[]) => ({
          items: response,
          totalCount: response.length
        }))
      );
  
      this.list.hookToQuery(maintenanceStreamCreator).subscribe((response) => {
        this.maintenance = response;

        console.log("Maintenance", this.maintenance)

        this.maintenance.items = this.maintenance.items.map(m => {
          let v = this.vehicules.map(ve => {
            if(ve.id === m.vehiculeId){
              // console.log("Vehicule correspond", ve)
              return ve
            }
          })

          v = v.filter(v => v != undefined)
          console.log("Vehicule find", v)
          console.log("vehicule", v, "correspond to", m.vehiculeId)

          return {...m, vehicule:v[0].marque +" ("+ v[0].matricule +")" }
        })

        console.log("Maintenance", this.maintenance)
      });
    }
  
    createMaintenance() {
      this.selectedMaintenance = {} as MaintenanceDto; // reset the selected book
      this.buildForm();
      this.isModalOpen = true;
    }
  
    editMaintenance(id: string) {
      this.maintenanceService.getMaintenanceById(id).subscribe((vehicule) => {
        this.selectedMaintenance = {id: id,...vehicule};
        console.log("selectedMaintenance", this.selectedMaintenance);
        this.buildForm();
        this.isModalOpen = true;
      });
    }
  
    delete(id: string) {
      this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe((status) => {
        if (status === Confirmation.Status.confirm) {
          this.maintenanceService.deleteMaintenanceById(id).subscribe(() => this.list.get());
        }
      });
    }
  
    buildForm(): void {
      this.form = this.fb.group({
        description: [this.selectedMaintenance.description || '', [Validators.required]],
        vehiculeId: [this.selectedMaintenance.vehiculeId || '', [Validators.required]],
        dateMaintenance: [this.selectedMaintenance.dateMaintenance ? new Date(this.selectedMaintenance.dateMaintenance) : null,
          Validators.required,]
      });
    }
  
    // change the save method
    save() {
      if (this.form.invalid) {
        return;
      }
      console.log("form value", this.form.value);
  
      const request = this.selectedMaintenance.id
        ? this.maintenanceService.updateMaintenance({id: this.selectedMaintenance.id,...this.form.value})
        : this.maintenanceService.createMaintenance(this.form.value);
  
      request.subscribe(() => {
        this.isModalOpen = false;
        this.form.reset();
        this.list.get();
      });
    }
}
