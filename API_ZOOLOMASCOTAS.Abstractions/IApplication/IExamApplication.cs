using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Exams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Abstractions.IApplication
{
    public interface IExamApplication
    {
        public Task<ResultDto<ExamListResponseDto>> GetExams(ExamListRequestDto request);
        public Task<ResultDto<int>> CreateExam(ExamCreateRequestDto request);
        public Task<ResultDto<int>> DeleteExam(DeleteDto request);
    }
}
