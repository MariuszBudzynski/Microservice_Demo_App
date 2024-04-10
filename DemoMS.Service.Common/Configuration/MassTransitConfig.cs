public class MassTransitConfig
{
    public static void ConfigureMassTransit(IServiceCollection services, IConfiguration configuration)
    {
        var rabbitMQSettings = configuration.GetSection("RabbitMQSettings");

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
            });
        });
    }
}
