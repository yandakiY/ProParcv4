using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace ProParcv4.Vehicules
{
    public class VehiculeService : ApplicationService, IVehicule
    {
        private readonly IRepository<Vehicule, Guid> _vehiculeRepository;

        public VehiculeService(IRepository<Vehicule, Guid> vehiculeRepository)
        {
            _vehiculeRepository = vehiculeRepository;
        }

        public async Task<VehiculeDto> Update(VehiculeDto vehicule)
        {
            var vehiculeEntity = await _vehiculeRepository.GetAsync(vehicule.Id);

            vehiculeEntity.Matricule = vehicule.Matricule;
            vehiculeEntity.Marque = vehicule.Marque;
            vehiculeEntity.DateFabrication = vehicule.DateFabrication;

            await _vehiculeRepository.UpdateAsync(vehiculeEntity);

            return vehicule;
        }

        public async Task<VehiculeDto> Create(VehiculeDto vehicule)
        {
            var vehiculeEntity = new Vehicule
            {
                Matricule = vehicule.Matricule,
                Marque = vehicule.Marque,
                DateFabrication = vehicule.DateFabrication
            };

            await _vehiculeRepository.InsertAsync(vehiculeEntity);

            return vehicule;
        }

        public async Task Delete(Guid id)
        {
            await _vehiculeRepository.DeleteAsync(id);
        }

        public async Task<VehiculeDto> GetById(Guid id)
        {
            var vehicule = await _vehiculeRepository.GetAsync(id);
            var vehiculeDto = new VehiculeDto
            {
                Id = vehicule.Id,
                Matricule = vehicule.Matricule,
                Marque = vehicule.Marque,
                DateFabrication = vehicule.DateFabrication
            };
            return vehiculeDto;
        }

        public async Task<List<VehiculeDto>> GetAll()
        {
            var vehicules = await _vehiculeRepository.GetListAsync();

            return vehicules.Select(item => new VehiculeDto
            {
                Id = item.Id,
                Matricule = item.Matricule,
                Marque = item.Marque,
                DateFabrication = item.DateFabrication
            }).ToList();
        }
    }
}
