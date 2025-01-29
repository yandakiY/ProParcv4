import { AuthService } from '@abp/ng.core';
import { ToasterService } from '@abp/ng.theme.shared';
import { Component, OnInit } from '@angular/core';
import { VehiculeDto, VehiculeService } from '@proxy/vehicules';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {

  vehiculeItems : VehiculeDto[];
  vehicule: VehiculeDto;
  
  
  get hasLoggedIn(): boolean {
    return this.authService.isAuthenticated
  }

  constructor(private readonly authService: AuthService, private readonly vehiculeService: VehiculeService, private readonly toasterService: ToasterService) {}

  login() {
    this.authService.navigateToLogin();
  }

  ngOnInit(): void {
    console.log("init home component");
    this.vehiculeService.getAll().subscribe(response => {
      this.vehiculeItems = response;
    });
  }

  create(): void{
    this.vehiculeService.createByVehicule(this.vehicule).subscribe((result) => {
      this.vehiculeItems = this.vehiculeItems.concat(result);
      this.vehicule = {} as VehiculeDto;
    });
  }

  delete(id: string): void {
    this.vehiculeService.deleteById(id).subscribe(() => {
      this.vehiculeItems = this.vehiculeItems.filter(item => item.id !== id);
      this.toasterService.info('Deleted the todo item.');
    });
  } 

}
