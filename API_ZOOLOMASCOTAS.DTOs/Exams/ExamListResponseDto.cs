using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.DTOs.Exams
{
    public class ExamListResponseDto
    {
        public int id { get; set; }
        public DateTime exam_date { get; set; }
        public string mucosa { get; set; }
        public string piel { get; set; }
        public string conjuntival { get; set; }
        public string oral { get; set; }
        public string sis_reproductor { get; set; }
        public string rectal { get; set; }
        public string ojos { get; set; }
        public string nodulos_linfaticos { get; set; }
        public string locomocion { get; set; }
        public string sis_cardiovascular { get; set; }
        public string sis_respiratorio { get; set; }
        public string sis_digestivo { get; set; }
        public string sis_urinario { get; set; }
        public int totalRecords { get; set; }
    }
}
