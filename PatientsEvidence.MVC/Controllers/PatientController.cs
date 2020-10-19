using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BussinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PatientsEvidence.MVC.Models.Patient;

namespace PatientsEvidence.MVC.Controllers
{
  public class PatientController : Controller
  {
    IPatient patientBL;

    public PatientController(IPatient patientBL)
    {
      this.patientBL = patientBL;
    }

    public IActionResult Index()
    {
      var model = new PatientsListViewModel
      {
        Patients = patientBL.GetAllPatients().Select(p => new Patient
        {
          DbPatient = p,
          IsHeightVIsible = true
        })
      };

      return View(model);
    }

    public IActionResult Detail(int id)
    {
      id--;
      var patients = patientBL.GetAllPatients();
      var heightAverage = patients?.Where(p => p.Weight > patients.Select(pa => pa.Weight).Average()).Select(p => p.Height).Average();

      if (id < 0)
        return View(new PatientViewModel(heightAverage));

      PatientViewModel model = null;

      if (patients != null)
      {
        model = new PatientViewModel(heightAverage)
        {
          Patient = id >= 0 && patients.Count() >= id ? patients.ToList()[id] : null
        };
      }

      return View(model);
    }

  }
}