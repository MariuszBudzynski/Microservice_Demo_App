namespace DemoMS.Service.Common.Extensions;
public static class Extensions
    {
        public static TMappedObj Mapp<TSource, TMappedObj>(this TSource source, Func<TSource, TMappedObj> mappfunction)
        {
            return mappfunction(source);
        }

    public static IServiceCollection MassTransitConfiguration(this IServiceCollection services, IConfiguration configuration)
    {

        var rabbitMQSettings = configuration.GetSection("RabbitMQSettings");

        services.AddMassTransit(x =>
        {
            x.AddConsumers(Assembly.GetEntryAssembly());

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

        return services;
    }

}
