﻿using API_ZOOLOMASCOTAS.DTOs.Clients;
using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Consults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Abstractions.IRepository
{
    public interface IConsultRepository
    {
        public Task<ResultDto<ConsultListResponseDto>> GetConsults(ConsultListRequestDto request);
        public Task<ResultDto<int>> CreateConsult(ConsultCreateRequestDto request);
        public Task<ResultDto<int>> DeleteConsult(DeleteDto request);
    }
}
