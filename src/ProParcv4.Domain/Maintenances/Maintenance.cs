using ProParcv4.Vehicules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace ProParcv4.Maintenances
{
    public class Maintenance : BasicAggregateRoot<Guid>
    {
        public Guid VehiculeId { get; set; }
        public string Description { get; set; }
        public  DateTime DateMaintenance { get; set; }
        public Vehicule Vehicule { get; set; }

    }

}
