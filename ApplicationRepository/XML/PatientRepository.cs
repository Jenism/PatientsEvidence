using ApplicationCore.Entities;
using ApplicationCore.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.Xml.Schema;

namespace ApplicationRepository.XML
{
    public class PatientRepository : IPatientRepository
    {

        private const string PATIENTS_XML_PATH = "..\\ApplicationRepository\\XML\\Data\\Patients.xml";
        private const string PATIENTS_SCHEMA_PATH = "..\\ApplicationRepository\\XML\\Schema\\PatientsSchema.xsd";

        public IEnumerable<Patient> GetAllPatients()
        {
            var xml = XDocument.Load(PATIENTS_XML_PATH);

            var schema = new XmlSchemaSet();
            schema.Add("", PATIENTS_SCHEMA_PATH);

            if (xml == null || !xml.ValidateDocument(schema))
                return null;

            var patients = new List<Patient>();
            var xmlPatients = xml.Element("patients")?.Elements("patient");

            foreach (var xmlPatient in xmlPatients)
            {
                patients.Add(new Patient
                {
                    Name = xmlPatient.Element("name").Value,
                    Surname = xmlPatient.Element("surname").Value,
                    Height = int.Parse(xmlPatient.Element("height").Value),
                    Weight = int.Parse(xmlPatient.Element("weight").Value),
                    DateOfBirth = DateTime.Parse(xmlPatient.Element("dateOfBirth").Value)
                });
            }

            return patients;
        }
    }
}
