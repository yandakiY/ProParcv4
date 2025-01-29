import type { AuditedEntityDto } from '@abp/ng.core';

export interface VehiculeDto extends AuditedEntityDto<string> {
  id?: string;
  matricule?: string;
  marque?: string;
  dateFabrication?: string;
}
