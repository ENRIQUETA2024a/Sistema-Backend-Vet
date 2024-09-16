using API_ZOOLOMASCOTAS.Abstractions.IApplication;
using API_ZOOLOMASCOTAS.Abstractions.IService;
using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Application.Patients
{
    public class PatientApplication : IPatientApplication
    {
        private readonly IPatientService _patientService;

        public PatientApplication(IPatientService patientService)
        {
            _patientService = patientService;
        }

        public async Task<ResultDto<int>> CreatePatient(PatientCreateRequestDto request)
        {
           return await _patientService.CreatePatient(request);
        }

        public async Task<ResultDto<int>> DeletePatient(DeleteDto request)
        {
           return await _patientService.DeletePatient(request);
        }

        public async Task<ResultDto<PatientListResponseDto>> GetPatients(PatientListRequestDto request)
        {
            return await _patientService.GetPatients(request);
        }
    }
}
