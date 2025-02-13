using ProParcv4.Vehicules;
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
        private readonly IRepository<Vehicule, Guid> _vehiculeRepository;

        private readonly VehiculeService _vehiculeService;

        public MaintenanceService(IRepository<Maintenance, Guid> maintenanceRepository, IRepository<Vehicule , Guid> vehiculeRepository)
        {
            _maintenanceRepository = maintenanceRepository;
            _vehiculeRepository = vehiculeRepository;
        }

        public async Task<MaintenanceDto> CreateMaintenance(MaintenanceDto maintenanceDto)
        {

            var maintenance = new Maintenance
            {
                Description = maintenanceDto.Description,
                VehiculeId = maintenanceDto.VehiculeId,
                DateMaintenance = maintenanceDto.DateMaintenance
            };
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

            return maintenances.Select(item => new MaintenanceDto {
                Id = item.Id,
                DateMaintenance = item.DateMaintenance,
                Description = item.Description ?? "",
                VehiculeId = item.VehiculeId,
            }).ToList();
        }

        public async Task<MaintenanceDto> GetMaintenanceById(Guid id)
        {
            var maintenance = await _maintenanceRepository.GetAsync(id);
            return new MaintenanceDto
            {
                Id = maintenance.Id,
                DateMaintenance = maintenance.DateMaintenance,
                Description = maintenance.Description ?? "",
                VehiculeId = maintenance.VehiculeId,
                Vehicule = new VehiculeDto
                {
                    Matricule = maintenance.Vehicule.Matricule,
                    Marque = maintenance.Vehicule.Marque,
                    DateFabrication = maintenance.Vehicule.DateFabrication
                }
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

        public async Task<List<MaintenanceDto>> GetListMaintenanceByVehiculeId(Guid vehiculeId)
        {
            var maintenances = await _maintenanceRepository
                .GetListAsync(m => m.VehiculeId == vehiculeId);

            return maintenances.Select(item => new MaintenanceDto
            {
                Id = item.Id,
                DateMaintenance = item.DateMaintenance,
                Description = item.Description,
                VehiculeId = item.VehiculeId,
            }).ToList();
        }
    }
}
