using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using entities = ApplicationCore.Entities;

namespace PatientsEvidence.MVC.Models.Patient
{
    public class PatientsListViewModel
    {
        public IEnumerable<entities.Patient> Patients { get; set; }
    }
}
