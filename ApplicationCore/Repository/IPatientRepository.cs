using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Repository
{
    public interface IPatientRepository
    {
        IEnumerable<Patient> GetAllPatients();
    }
}
