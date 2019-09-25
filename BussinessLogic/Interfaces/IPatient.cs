using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLogic.Interfaces
{
    public interface IPatient
    {
        IEnumerable<Patient> GetAllPatients();
    }
}
