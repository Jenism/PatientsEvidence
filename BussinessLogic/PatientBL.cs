using ApplicationCore.Entities;
using ApplicationCore.Repository;
using BussinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLogic
{
    public class PatientBL : IPatient
    {
        IPatientRepository patientRepository; 

        public PatientBL(IPatientRepository patientRepository)
        {
            this.patientRepository = patientRepository;
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            var patients = patientRepository.GetAllPatients();

            //future BL operations on patients here...

            return patients;
        }
    }
}
