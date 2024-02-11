using PatientInformationPortalAPI.DTOs;
using PatientInformationPortalAPI.Models;
using PatientInformationPortalAPI.Repository.Abstraction;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net;

namespace PatientInformationPortalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientInformationsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public PatientInformationsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("disease-list")]
        public async Task<ActionResult<IEnumerable<DiseaseInformation>>> GetDiseaseList()
        {
            return await _unitOfWork.DiseaseInformation.Get();
        }

        [HttpGet("NCD-list")]
        public async Task<ActionResult<IEnumerable<NCD>>> GetNCDList()
        {
            return await _unitOfWork.NCD.Get();
        }

        [HttpGet("allergie-list")]
        public async Task<ActionResult<IEnumerable<Allergies>>> GetAllergieList()
        {
            return await _unitOfWork.Allergies.Get();
        }

        // GET: api/PatientInformations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientInformation>>> GetPatientInformation()
        {
            var data = await _unitOfWork.PatientInformation.Queryable()
            .Include(x => x.DiseaseInformation).ToListAsync();
            return data;
        }

        // GET: api/PatientInformations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PatientInformation>> GetPatientInformation(int id)
        {
            
            var patientInformation = await _unitOfWork.PatientInformation.GetById(id);

            if (patientInformation == null)
            {
                return NotFound();
            }

            return patientInformation;
        }

        // PUT: api/PatientInformations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatientInformation(int id, PatientInformation patientInformation)
        {
            if (id != patientInformation.PatientId)
            {
                return BadRequest();
            }

            _unitOfWork.PatientInformation.Update(patientInformation);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientInformationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PatientInformations
        [HttpPost("add-patient")]
        public async Task<ActionResult<PatientInformation>> PostPatientInformation([FromBody] PatientInformationDTO patientDTO)
        {
            var transaction = _unitOfWork.BeginTransactionAsync();

            try
            {
                // Add patient

                PatientInformation patient = new()
                {
                    PatientName = patientDTO.PatientName,
                    DiseaseId = patientDTO.DiseaseId,
                    Epilepsy = patientDTO.Epilepsy
                };

                await _unitOfWork.PatientInformation.AddAsync(patient);
                await _unitOfWork.SaveChangesAsync();

                //Add NCD Detail
                if (patientDTO.NCDs.Any())
                {
                    List<NCD_Details> NCDList = new();
                    patientDTO.NCDs.ForEach(x =>
                    {
                        NCD_Details NCDDetails = new()
                        {
                            PatientId = patient.PatientId,
                            NCDId = x
                        };
                        NCDList.Add(NCDDetails);
                    });
                    await _unitOfWork.NCD_Details.AddRangeAsync(NCDList);
                    await _unitOfWork.SaveChangesAsync();
                }

                //Add Allergie Detail
                if (patientDTO.Allergies.Any())
                {
                    List<Allergies_Details> allergieList = new();
                    patientDTO.Allergies.ForEach(x =>
                    {
                        Allergies_Details allergieDetails = new()
                        {
                            PatientId = patient.PatientId,
                            AllergiesId = x
                        };
                        allergieList.Add(allergieDetails);
                    });
                    await _unitOfWork.Allergies_Details.AddRangeAsync(allergieList);
                    await _unitOfWork.SaveChangesAsync();
                }

                await _unitOfWork.CommitTransactionAsync();
                return StatusCode((int)HttpStatusCode.OK);

            }
            catch (Exception)
            {
                await _unitOfWork.RollBackTransactionAsync();
                return BadRequest();
            }
        }

        // DELETE: api/PatientInformations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatientInformation(int id)
        {
            if (_unitOfWork.PatientInformation == null)
            {
                return NotFound();
            }
            var patientInformation = await _unitOfWork.PatientInformation.GetById(id);
            if (patientInformation == null)
            {
                return NotFound();
            }

            _unitOfWork.PatientInformation.Delete(id);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }

        private bool PatientInformationExists(int id)
        {
            return (_unitOfWork.PatientInformation?.GetById(id) != null) ? true : false;
        }
    }
}
