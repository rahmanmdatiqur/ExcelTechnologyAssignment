using PatientInformationPage.Models;
using PatientInformationPage.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace PatientInformationPage.Controllers
{
    public class PatientEntryController : Controller
    {
        private readonly HttpClient client;
        public PatientEntryController()
        {
            WebApi api = new WebApi();
            this.client = api.Initial();
            client.BaseAddress = new Uri("http://localhost:7033");
        }

        public async Task<IActionResult> Index()
        {
            List<DiseaseInformation> diseaseList = new List<DiseaseInformation>();
            HttpResponseMessage diseaseResponse = await client.GetAsync(new Uri("/api/PatientInformations/disease-list", UriKind.Relative));
            if (diseaseResponse.IsSuccessStatusCode)
            {
                var result = diseaseResponse.Content.ReadAsStringAsync().Result;
                diseaseList = JsonConvert.DeserializeObject<List<DiseaseInformation>>(result)!;
            }
            else
            {
                return NotFound();
            }

            ViewBag.diseases = new SelectList(diseaseList, "DiseaseId", "DiseaseName");

            List<NCD> NCDList = new List<NCD>();
            var NCDresponse = await client.GetAsync(new Uri("/api/PatientInformations/NCD-list", UriKind.Relative));
            if (NCDresponse.IsSuccessStatusCode)
            {
                var result = NCDresponse.Content.ReadAsStringAsync().Result;
                NCDList = JsonConvert.DeserializeObject<List<NCD>>(result)!;
            }
            else
            {
                return NotFound();
            }

            ViewBag.NCDs = new SelectList(NCDList, "NCDId", "NCDName");

            List<Allergies> allergieList = new List<Allergies>();
            var allergieResponse = await client.GetAsync(new Uri("/api/PatientInformations/allergie-list", UriKind.Relative));
            if (allergieResponse.IsSuccessStatusCode)
            {
                var result = allergieResponse.Content.ReadAsStringAsync().Result;
                allergieList = JsonConvert.DeserializeObject<List<Allergies>>(result)!;
            }
            else
            {
                return NotFound();
            }

            ViewBag.allergies = new SelectList(allergieList, "AllergiesId", "AllergiesName");

            return View(new PatientInformationVM());
        }

        [HttpPost]
        public async Task<IActionResult> CreatePatientInformation(PatientInformationVM patientVM)
        {
            var data = patientVM;
            var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

            List<Allergies> allergieList = new List<Allergies>();
            var allergieResponse = await client
                .PostAsync(new Uri("/api/PatientInformations/add-patient", UriKind.Relative), content);
            if (allergieResponse.IsSuccessStatusCode)
            {
                List<PatientInformation> patientList = new List<PatientInformation>();
                HttpResponseMessage response = await client.GetAsync("http://localhost:7033/api/PatientInformations");
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    patientList = JsonConvert.DeserializeObject<List<PatientInformation>>(result)!;
                }

                return View("AllPatientsData", patientList);
            }
            else
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> AllPatientsData()
        {
            List<PatientInformation> patientList = new List<PatientInformation>();
            HttpResponseMessage response = await client.GetAsync("http://localhost:7200/api/PatientInformations");
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                patientList = JsonConvert.DeserializeObject<List<PatientInformation>>(result)!;
            }
            return View(patientList);

        }
    }

}
