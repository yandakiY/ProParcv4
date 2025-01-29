import type { VehiculeDto } from './models';
import { RestService, Rest } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class VehiculeService {
  apiName = 'Default';
  

  createByVehicule = (vehicule: VehiculeDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, VehiculeDto>({
      method: 'POST',
      url: '/api/app/vehicule',
      body: vehicule,
    },
    { apiName: this.apiName,...config });
  

  deleteById = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/vehicule/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getAll = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, VehiculeDto[]>({
      method: 'GET',
      url: '/api/app/vehicule',
    },
    { apiName: this.apiName,...config });
  

  getByIdById = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, VehiculeDto>({
      method: 'GET',
      url: `/api/app/vehicule/${id}/by-id`,
    },
    { apiName: this.apiName,...config });
  

  updateByVehicule = (vehicule: VehiculeDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, VehiculeDto>({
      method: 'PUT',
      url: '/api/app/vehicule',
      body: vehicule,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
