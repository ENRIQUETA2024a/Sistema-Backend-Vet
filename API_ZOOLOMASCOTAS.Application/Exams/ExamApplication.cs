using API_ZOOLOMASCOTAS.Abstractions.IApplication;
using API_ZOOLOMASCOTAS.Abstractions.IService;
using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Exams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Application.Exams
{
    public class ExamApplication : IExamApplication
    {
        private readonly IExamService examService;

        public ExamApplication(IExamService examService)
        {
            this.examService = examService;
        }
        public async Task<ResultDto<int>> CreateExam(ExamCreateRequestDto request)
        {
            return await this.examService.CreateExam(request);
        }

        public async Task<ResultDto<int>> DeleteExam(DeleteDto request)
        {
           return await this.examService.DeleteExam(request);
        }

        public async Task<ResultDto<ExamListResponseDto>> GetExams(ExamListRequestDto request)
        {
           return await this.examService.GetExams(request);
        }
    }
}
