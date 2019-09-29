using ApplicationCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using entities = ApplicationCore.Entities;

namespace PatientsEvidence.Angular.Models
{
    public class PatientViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age => DateOfBirth.GetAge();

        public double HeightAverage { get; }

        public PatientViewModel(double heightAverage)
        {
            HeightAverage = heightAverage;
        }
    }
}
