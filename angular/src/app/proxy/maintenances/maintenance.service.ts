import type { MaintenanceDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class MaintenanceService {
  apiName = 'Default';
  

  createMaintenance = (maintenanceDto: MaintenanceDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, MaintenanceDto>({
      method: 'POST',
      url: '/api/app/maintenance/maintenance',
      body: maintenanceDto,
    },
    { apiName: this.apiName,...config });
  

  deleteMaintenanceById = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/maintenance/${id}/maintenance`,
    },
    { apiName: this.apiName,...config });
  

  getAll = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, MaintenanceDto[]>({
      method: 'GET',
      url: '/api/app/maintenance',
    },
    { apiName: this.apiName,...config });
  

  getListMaintenanceByVehicule = (vehiculeId: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, MaintenanceDto[]>({
      method: 'GET',
      url: `/api/app/maintenance/maintenance-by-vehicule-id/${vehiculeId}`,
    },
    { apiName: this.apiName,...config });
  

  getMaintenanceById = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, MaintenanceDto>({
      method: 'GET',
      url: `/api/app/maintenance/${id}/maintenance-by-id`,
    },
    { apiName: this.apiName,...config });
  

  updateMaintenance = (maintenanceDto: MaintenanceDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, MaintenanceDto>({
      method: 'PUT',
      url: '/api/app/maintenance/maintenance',
      body: maintenanceDto,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
