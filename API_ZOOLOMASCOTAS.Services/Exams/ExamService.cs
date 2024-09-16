using API_ZOOLOMASCOTAS.Abstractions.IRepository;
using API_ZOOLOMASCOTAS.Abstractions.IService;
using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Exams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Services.Exams
{
    public class ExamService : IExamService
    {
        private readonly IExamRepository examRepository;

        public ExamService(IExamRepository examRepository)
        {
            this.examRepository = examRepository;
        }
        public async Task<ResultDto<int>> CreateExam(ExamCreateRequestDto request)
        {
            return await this.examRepository.CreateExam(request);
        }

        public async Task<ResultDto<int>> DeleteExam(DeleteDto request)
        {
            return await this.examRepository.DeleteExam(request);
        }

        public async Task<ResultDto<ExamListResponseDto>> GetExams(ExamListRequestDto request)
        {
            return await this.examRepository.GetExams(request);
        }
    }
}
