using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace ProParcv4.Vehicules
{
    public class Vehicule : BasicAggregateRoot<Guid>
    {
        public string Matricule { get; set; }
        public string Marque { get; set; }
        public DateTime DateFabrication { get; set; }

    }
}
