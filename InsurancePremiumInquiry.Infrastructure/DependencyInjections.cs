using FluentValidation;
using InsurancePremiumInquiry.Application.Cqrs.BenefitRequests.Commands.CreateBenefitRequest;
using InsurancePremiumInquiry.Application.Database;
using InsurancePremiumInquiry.Domain.Repositories;
using InsurancePremiumInquiry.Infrastructure.Database;
using InsurancePremiumInquiry.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InsurancePremiumInquiry.Infrastructure
{
    public static class DependencyInjections
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigMediator()
                    .ConfigureDatabase(configuration)
                    .ConfigureRepositories();

        }
        private static IServiceCollection ConfigMediator(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateBenefitRequestCommand).Assembly));
            services.AddValidatorsFromAssemblies(new[] { typeof(CreateBenefitRequestCommandValidator).Assembly });
            return services;
        }
        private static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<InsurancePremiumInquiryContext>(options =>
     options.UseNpgsql(configuration.GetConnectionString("InsurancePremiumInquiryContext"))
            .EnableDetailedErrors())
     .AddScoped<IInsurancePremiumInquiryContext>(provider =>
         provider.GetRequiredService<InsurancePremiumInquiryContext>());

            return services;
        }
        private static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBenefitRequestRepository, BenefitRequestRepository>();
            return services;
        }

    }
}
