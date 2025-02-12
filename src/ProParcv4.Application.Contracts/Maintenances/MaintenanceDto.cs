using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace ProParcv4.Maintenances
{
    public class MaintenanceDto : EntityDto<Guid>
    {
        public required Guid VehiculeId { get; set; }
        public required string Description { get; set; }
        public required DateTime DateMaintenance { get; set; }
    }

}
