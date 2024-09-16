using API_ZOOLOMASCOTAS.Abstractions.IRepository;
using API_ZOOLOMASCOTAS.Abstractions.IService;
using API_ZOOLOMASCOTAS.Services.Breed;
using API_ZOOLOMASCOTAS.Services.Categories;
using API_ZOOLOMASCOTAS.Services.Client;
using API_ZOOLOMASCOTAS.Services.Common;
using API_ZOOLOMASCOTAS.Services.Consults;
using API_ZOOLOMASCOTAS.Services.Dashboard;
using API_ZOOLOMASCOTAS.Services.Diagnoses;
using API_ZOOLOMASCOTAS.Services.Employees;
using API_ZOOLOMASCOTAS.Services.Exams;
using API_ZOOLOMASCOTAS.Services.Patients;
using API_ZOOLOMASCOTAS.Services.Products;
using API_ZOOLOMASCOTAS.Services.Recetas;
using API_ZOOLOMASCOTAS.Services.Roles;
using API_ZOOLOMASCOTAS.Services.Services;
using API_ZOOLOMASCOTAS.Services.Specie;
using API_ZOOLOMASCOTAS.Services.Treatments;
using API_ZOOLOMASCOTAS.Services.User;
using API_ZOOLOMASCOTAS.Services.Ventas;
using Microsoft.Extensions.DependencyInjection;

namespace API_ZOOLOMASCOTAS.Services
{
    public static class ServicesServiceRegister
    {
        public static IServiceCollection AddServiceServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISpecieService, SpecieService>();
            services.AddScoped<IBreedService, BreedService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<ICommonService, CommonService>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IConsultService, ConsultService>();
            services.AddScoped<IExamService, ExamService>();
            services.AddScoped<IDiagnosisService, DiagnosisService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ITreatmentsService, TreatmentService>();
            services.AddScoped<IProductsTreatmentService, ProductTreatmentService>();
            services.AddScoped<IRecetasService, RecetasService>();
            services.AddScoped<IDashboardService, DashboardService>();
            services.AddScoped<IRolService, RolService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IServiceService, ServiceService>();
            services.AddScoped<IVentaService, VentaService>();

            return services;
        }
    }
}
