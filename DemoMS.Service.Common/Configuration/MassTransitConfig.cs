namespace DemoMS.Service.Common.Extensions
{
    public class MassTransitConfig
    {
        private readonly IConfiguration _configuration;

        public MassTransitConfig(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IServiceCollection MassTransitConfiguration(IServiceCollection services)
        {
            var rabbitMQSettings = _configuration.GetSection("RabbitMQSettings");

            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, configurator) =>
                {
                    var host = rabbitMQSettings["Host"];
                    var username = rabbitMQSettings["Username"];
                    var password = rabbitMQSettings["Password"];
                    var virtualHost = rabbitMQSettings["VirtualHost"];
                    configurator.Host(new Uri($"rabbitmq://{host}/{virtualHost}"), h =>
                    {
                        h.Username(username);
                        h.Password(password);
                    });

                    configurator.ConfigureEndpoints(context);
                });
            });

            return services;
        }

        public IServiceCollection AddMassTransitConsumer<TConsumer>(IServiceCollection services)
            where TConsumer : class, IConsumer
        {
            return services.AddScoped<TConsumer>()
                           .AddScoped<IConsumer>(provider => provider.GetService<TConsumer>());
        }
    }
}
