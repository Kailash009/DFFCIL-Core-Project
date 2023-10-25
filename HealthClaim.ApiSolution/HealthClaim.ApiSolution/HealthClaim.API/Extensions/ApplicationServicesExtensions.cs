using HealthClaim.BAL.Repository.Concrete;
using HealthClaim.BAL.Repository.Interface;
using Microsoft.OpenApi.Models;

namespace HealthClaim.API.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddAppliationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeefamilyRepository, EmployeefamilyRepository>();
            services.AddScoped<IEmpAccountDetailRepository, EmpAccountDetailRepository>();
            services.AddScoped<IEmpAdvanceRepository, EmpAdvanceRepository>();
            services.AddScoped<ICommanRepository, CommanRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IOrgClaimLimitRepository, OrgClaimLimitRepository>();
            services.AddScoped<IDoctorReviewRepository, DoctorReviewRepository>();
            services.AddScoped<IFinanceRepository, FinanceRepository>();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "DFCCIL Services", Version = "v1" });
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                     Type=ReferenceType.SecurityScheme,
                                       Id="Bearer"
                                }
                              },
                            new string[]{}
                    }
                });
            });
            // Named Policy
            services.AddCors(options =>
            {
                options.AddPolicy(name: "AllowOrigin",
                    builder =>
                    {
                        builder.WithOrigins("https://localhost:7063", "https://uat.dfccil.cetpainfotech.com")
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                    });
            });


            return services;
        }
    }
}
