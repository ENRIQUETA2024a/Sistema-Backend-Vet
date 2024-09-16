using API_ZOOLOMASCOTAS.Abstractions.IRepository;
using API_ZOOLOMASCOTAS.DTOs.Common;
using API_ZOOLOMASCOTAS.DTOs.Dashboard;
using API_ZOOLOMASCOTAS.DTOs.Diagnoses;
using Azure.Core;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_ZOOLOMASCOTAS.Repository.Dashboard
{
    public class DashboardRepository : IDashboardRepository
    {
        private string _connectionString = "";

        public DashboardRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("connection");
        }
        public async Task<ResultDto<DashboardInfoResponseDto>> GetDashboardInfo()
        {
            ResultDto<DashboardInfoResponseDto> result = new ResultDto<DashboardInfoResponseDto>();
            DashboardInfoResponseDto item = new DashboardInfoResponseDto ();

            try
            {
                using (var cn = new SqlConnection(_connectionString))
                {
                    var query = await cn.QueryAsync<DashboardInfoResponseDto>("SP_DASHBOARD_INFO", null, commandType: System.Data.CommandType.StoredProcedure);
                    item = (DashboardInfoResponseDto)query.FirstOrDefault();
                    result.IsSuccess = query.Any();
                    result.Message = query.Any() ? "Información encontrada" : "No se encontro información";
                    result.Item = item;
                }
            }
            catch (Exception ex)
            {
                result.MessageException = ex.Message;
                result.IsSuccess = false;
            }
            return result;
        }
    }
}
