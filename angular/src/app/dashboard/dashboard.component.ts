import { Component } from '@angular/core';
import { MaintenanceService } from '@proxy/maintenances';
import { VehiculeService } from '@proxy/vehicules';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss'
})
export class DashboardComponent {
vehiculeCount: number = 0;
  maintenanceCount: number = 0;

  constructor(
    private readonly vehiculeService: VehiculeService,
    private readonly maintenanceService: MaintenanceService
  ) {}

  ngOnInit(): void {
    this.loadCounts();
  }

  loadCounts(): void {
    this.vehiculeService.getAll().subscribe(response => {
      this.vehiculeCount = response.length;
    });

    this.maintenanceService.getAll().subscribe(response => {
      this.maintenanceCount = response.length;
    });
  }

  ajouterVehicule(): void {
    console.log("Rediriger vers l'ajout d'un véhicule...");
    window.location.href = "/vehicules"
  }

  ajouterMaintenance(): void {
    console.log("Rediriger vers l'ajout d'une maintenance...");
    window.location.href = "/maintenances"

  }
}
