using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Abstractions.IService
{
    public interface IPatientService
    {
        public Task<ResultDto<PatientListResponseDto>> GetPatients(PatientListRequestDto request);
        public Task<ResultDto<int>> CreatePatient(PatientCreateRequestDto request);
        public Task<ResultDto<int>> DeletePatient(DeleteDto request);
    }
}
