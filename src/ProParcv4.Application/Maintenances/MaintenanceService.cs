using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ProParcv4.Maintenances
{
    public class MaintenanceService : ApplicationService, IMaintenance
    {
        private readonly IRepository<Maintenance, Guid> _maintenanceRepository;
        public async Task<MaintenanceDto> CreateMaintenance(MaintenanceDto maintenanceDto)
        {
            var maintenance = ObjectMapper.Map<MaintenanceDto, Maintenance>(maintenanceDto);
            await _maintenanceRepository.InsertAsync(maintenance);
            return maintenanceDto;
        }

        public async Task DeleteMaintenance(Guid id)
        {
            await _maintenanceRepository.DeleteAsync(id);
        }

        public async Task<List<MaintenanceDto>> GetAll()
        {
            var maintenances = await _maintenanceRepository.GetListAsync();
            //return ObjectMapper.Map<List<Maintenance>, List<MaintenanceDto>>(maintenances);
            return (List<MaintenanceDto>)maintenances.Select(item => new MaintenanceDto { 
                Id = item.Id,
                DateMaintenance = item.DateMaintenance,
                Description = item.Description,
                VehiculeId = item.VehiculeId,
            });
        }

        public async Task<MaintenanceDto> GetMaintenanceById(Guid id)
        {
            var maintenance = await _maintenanceRepository.GetAsync(id);
            return new MaintenanceDto
            {
                Id = maintenance.Id,
                DateMaintenance = maintenance.DateMaintenance,
                Description = maintenance.Description,
                VehiculeId = maintenance.VehiculeId,
            };
        }

        public async Task<MaintenanceDto> UpdateMaintenance(MaintenanceDto maintenanceDto)
        {
            var maintenance = await _maintenanceRepository.GetAsync(maintenanceDto.Id);
            maintenance.DateMaintenance = maintenanceDto.DateMaintenance;
            maintenance.Description = maintenanceDto.Description;
            maintenance.VehiculeId = maintenanceDto.VehiculeId;

            await _maintenanceRepository.UpdateAsync(maintenance);
            return maintenanceDto;
        }
    }
}
