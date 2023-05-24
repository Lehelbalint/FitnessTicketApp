namespace FitnessTicketApp
{
    using FitnessTicketApp.Models;
    using Microsoft.Extensions.DependencyInjection;

    public static class EmailServiceExtensions
    {
        public static IServiceCollection AddEmailService(this IServiceCollection services)
        {
            services.AddTransient<IEmailService, EmailService>();
            return services;
        }
    }
}
