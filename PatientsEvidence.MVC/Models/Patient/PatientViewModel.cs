using ApplicationCore;
using entities = ApplicationCore.Entities;

namespace PatientsEvidence.MVC.Models.Patient
{

    public class PatientViewModel
    {
        public entities.Patient Patient { get; set; }

        public double? HeightAverage { get; }

        public PatientViewModel(double? heightAverage)
        {
            HeightAverage = heightAverage;
        }
    }
}