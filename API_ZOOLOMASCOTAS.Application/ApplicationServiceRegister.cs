using API_ZOOLOMASCOTAS.Abstractions.IApplication;
using API_ZOOLOMASCOTAS.Application.Breed;
using API_ZOOLOMASCOTAS.Application.Categories;
using API_ZOOLOMASCOTAS.Application.Client;
using API_ZOOLOMASCOTAS.Application.Consults;
using API_ZOOLOMASCOTAS.Application.Dashboard;
using API_ZOOLOMASCOTAS.Application.Diagnoses;
using API_ZOOLOMASCOTAS.Application.Employees;
using API_ZOOLOMASCOTAS.Application.Exams;
using API_ZOOLOMASCOTAS.Application.Patients;
using API_ZOOLOMASCOTAS.Application.Products;
using API_ZOOLOMASCOTAS.Application.Recetas;
using API_ZOOLOMASCOTAS.Application.Roles;
using API_ZOOLOMASCOTAS.Application.Services;
using API_ZOOLOMASCOTAS.Application.Specie;
using API_ZOOLOMASCOTAS.Application.Treatments;
using API_ZOOLOMASCOTAS.Application.User;
using API_ZOOLOMASCOTAS.Application.Ventas;
using Microsoft.Extensions.DependencyInjection;

namespace API_ZOOLOMASCOTAS.Application
{
    public static class ApplicationServiceRegister
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUserApplication, UserApplication>();
            services.AddScoped<ISpecieApplication, SpecieApplication>();
            services.AddScoped<IBreedApplication, BreedApplication>();
            services.AddScoped<IClientApplication, ClientApplication>();
            services.AddScoped<IPatientApplication, PatientApplication>();
            services.AddScoped<IConsultApplication, ConsultApplication>();
            services.AddScoped<IExamApplication, ExamApplication>();
            services.AddScoped<IDiagnosisApplication, DiagnosisApplication>();
            services.AddScoped<ICategoryApplication, CategoryApplication>();
            services.AddScoped<IProductApplication, ProductApplication>();
            services.AddScoped<ITreatmentsApplication, TreatmentsApplication>();
            services.AddScoped<IProductsTreatmentApplication, ProductTreatmentApplication>();
            services.AddScoped<IRecetasApplication, RecetasApplication>();
            services.AddScoped<IDashboardApplication, DashboardApplication>();
            services.AddScoped<IRolApplication, RolApplication>();
            services.AddScoped<IEmployeeApplication, EmployeeApplication>();
            services.AddScoped<IServiceApplication, ServiceApplication>();
            services.AddScoped<IVentaApplication, VentaApplication>();

            return services;
        }
    }
}
