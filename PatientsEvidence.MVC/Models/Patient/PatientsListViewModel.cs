using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using entities = ApplicationCore.Entities;

namespace PatientsEvidence.MVC.Models.Patient
{
    public class PatientsListViewModel
    {
        public IEnumerable<Patient> Patients { get; set; }
    }

  public class Patient
  {
    public entities.Patient DbPatient { get; set; }
    public bool IsNameVisible { get; set; }
    public bool IsHeightVIsible { get; set; }
  }
}
