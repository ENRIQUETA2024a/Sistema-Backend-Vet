using API_ZOOLOMASCOTAS.Abstractions.IRepository;
using API_ZOOLOMASCOTAS.Repository.Breeds;
using API_ZOOLOMASCOTAS.Repository.Categories;
using API_ZOOLOMASCOTAS.Repository.Clients;
using API_ZOOLOMASCOTAS.Repository.Consults;
using API_ZOOLOMASCOTAS.Repository.Dashboard;
using API_ZOOLOMASCOTAS.Repository.Diagnoses;
using API_ZOOLOMASCOTAS.Repository.Employees;
using API_ZOOLOMASCOTAS.Repository.Exams;
using API_ZOOLOMASCOTAS.Repository.Patients;
using API_ZOOLOMASCOTAS.Repository.Products;
using API_ZOOLOMASCOTAS.Repository.Recetas;
using API_ZOOLOMASCOTAS.Repository.Roles;
using API_ZOOLOMASCOTAS.Repository.Services;
using API_ZOOLOMASCOTAS.Repository.Species;
using API_ZOOLOMASCOTAS.Repository.Treatments;
using API_ZOOLOMASCOTAS.Repository.User;
using API_ZOOLOMASCOTAS.Repository.Ventas;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace API_ZOOLOMASCOTAS.Repository
{
    public static class RepositoryServiceRegister
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISpecieRepository, SpecieRepository>();
            services.AddScoped<IBreedRepository, BreedRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IConsultRepository, ConsultRepository>();
            services.AddScoped<IExamRepository, ExamRepository>();
            services.AddScoped<IDiagnosisRepository, DiagnosisRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ITreatmentsRepository, TreatmentsRepository>();
            services.AddScoped<IProductsTreatmentRepository, ProductTreatmentRepository>();
            services.AddScoped<IRecetasRepository, RecetasRepository>();
            services.AddScoped<IDashboardRepository, DashboardRepository>();
            services.AddScoped<IRolRepository, RolRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddScoped<IVentaRepository, VentaRepository>();

            return services;
        }
    }
}
