import type { EntityDto } from '@abp/ng.core';

export interface MaintenanceDto extends EntityDto<string> {
  vehiculeId?: string;
  description?: string;
  dateMaintenance?: string;
  vehicule?:any;
}
