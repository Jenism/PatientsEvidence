using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using BussinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PatientsEvidence.Angular.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PatientsEvidence.Controllers
{
    [Route("api/[controller]")]
    public class PatientController : BaseController
    {
        public PatientController(IPatient patientBL) : base(patientBL) { }

        [HttpGet("[action]")]
        public IEnumerable<Patient> GetAllPatients()
        {
            return patientBL.GetAllPatients();
        }

        [HttpGet("[action]")]
        public PatientViewModel GetPatientDetail(int id)
        {
            var patients = patientBL.GetAllPatients();

            if (patients == null || id < 0 || id >= patients?.Count())
                return null;

            var heightAverage = patients.Where(p => p.Weight > patients.Select(pa => pa.Weight).Average()).Select(p => p.Height).Average();

            if (id >= 0 && patients?.Count() >= id)
            {
                var patient = patients.ToList()[0];
                return new PatientViewModel(heightAverage)
                {
                    Name = patient.Name,
                    Surname = patient.Surname,
                    Height = patient.Height,
                    Weight = patient.Weight,
                    DateOfBirth = patient.DateOfBirth
                };
            }

            return null;

        }

    }
}
