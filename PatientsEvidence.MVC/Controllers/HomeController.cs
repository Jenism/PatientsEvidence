using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BussinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PatientsEvidence.MVC.Models;
using PatientsEvidence.MVC.Models.Patient;

namespace PatientsEvidence.MVC.Controllers
{
    public class HomeController : Controller
    {
        IPatient patientBL;

        public HomeController(IPatient patientBL)
        {
            this.patientBL = patientBL;
        }

        public IActionResult Index()
        {
            var model = new PatientsListViewModel
            {
                Patients = patientBL.GetAllPatients()
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
