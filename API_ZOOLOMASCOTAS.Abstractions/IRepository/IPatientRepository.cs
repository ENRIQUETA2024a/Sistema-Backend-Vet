using API_ZOOLOMASCOTAS.DTOs.Clients;
using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Abstractions.IRepository
{
    public interface IPatientRepository
    {
        public Task<ResultDto<PatientListResponseDto>> GetPatients(PatientListRequestDto request);
        public Task<ResultDto<int>> CreatePatient(PatientCreateRequestDto request);
        public Task<ResultDto<int>> DeletePatient(DeleteDto request);
        public Task<ResultDto<PatientListResponseDto>> GetPatientDetail(DeleteDto request);
    }
}
