using ProParcv4.Vehicules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace ProParcv4.Maintenances
{
    public interface IMaintenance : IApplicationService
    {
        Task<List<MaintenanceDto>> GetAll();
        Task<MaintenanceDto> GetMaintenanceById(Guid id);
        Task<MaintenanceDto> UpdateMaintenance(MaintenanceDto maintenance);
        Task<MaintenanceDto> CreateMaintenance(MaintenanceDto maintenance);
        Task DeleteMaintenance(Guid id);
    }
}
