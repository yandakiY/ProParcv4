using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace ProParcv4.Vehicules
{
    public interface IVehicule : IApplicationService
    {
        Task<List<VehiculeDto>> GetAll();
        Task<VehiculeDto> GetById(Guid id);
        Task<VehiculeDto> Update(VehiculeDto vehicule);
        Task<VehiculeDto> Create(VehiculeDto vehicule);
        Task Delete(Guid id);
    }
}
