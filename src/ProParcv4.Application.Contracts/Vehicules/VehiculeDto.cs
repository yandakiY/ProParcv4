using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace ProParcv4.Vehicules
{
    public class VehiculeDto: AuditedEntityDto<Guid>
    {
        public Guid Id { get; set; }
        public required string Matricule { get; set; }
        public required string Marque { get; set; }
        public required DateTime DateFabrication { get; set; }
    }
}
