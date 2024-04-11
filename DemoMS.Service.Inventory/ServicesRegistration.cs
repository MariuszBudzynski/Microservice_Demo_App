namespace DemoMS.Service.Inventory
{
    public static class ServicesRegistration
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration, WebApplicationBuilder builder)
        {
            var rabbitMQSettings = configuration.GetSection("RabbitMQSettings");
            var databaseConfiguration = new DatabaseConfiguration(configuration);
            var connectionString = databaseConfiguration.GetConnectionString();

            // Mongo DB conversion to redable format
            BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
            BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));

            services.AddMassTransit(x =>
            {
                x.AddConsumer<CatalogItemDeletedConsumer>();
                x.AddConsumer<CatalogItemUpdatedConsumer>();
                x.AddConsumer<CatalogItemCreatedConsumer>();


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

                    configurator.ReceiveEndpoint("Delete", e =>
                    {
                        e.Consumer<CatalogItemDeletedConsumer>(context);
                    });

                    configurator.ReceiveEndpoint("Update", e =>
                    {
                        e.Consumer<CatalogItemUpdatedConsumer>(context);
                    });

                    configurator.ReceiveEndpoint("Create", e =>
                    {
                        e.Consumer<CatalogItemCreatedConsumer>(context);
                    });

                });
            });

            builder.Services.AddValidatorsFromAssemblyContaining(typeof(GrantItemsDTO));

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //configuring MongoDB to use the connection string inside the appsettings
            services.AddScoped(provider =>
            {
                var inventoryItemsConfig = configuration.GetSection("Configuration:InventoryItems");
                var collectionName = inventoryItemsConfig["CollectionName"];
                var databaseName = inventoryItemsConfig["DatabaseName"];

                var context = new MongoDBContext<InventoryItem>(connectionString, collectionName, databaseName);
                return context;
            });

            services.AddScoped(provider =>
            {
                var catalogItemsConfig = configuration.GetSection("Configuration:CatalogItems");
                var collectionName = catalogItemsConfig["CollectionName"];
                var databaseName = catalogItemsConfig["DatabaseName"];

                var context = new MongoDBContext<CatalogItem>(connectionString, collectionName, databaseName);
                return context;

            });

            //As I am implementing a service broker this is no longer valid but I am leaving it as a refrence

            services.AddHttpClient<CatalogClient>();
            //.AddTransientHttpErrorPolicy( builder => builder.Or<TimeoutRejectedException>().WaitAndRetryAsync(
            //    5,
            //    retryAttemp => TimeSpan.FromSeconds(Math.Pow(2,retryAttemp))))
            //.AddTransientHttpErrorPolicy(builder => builder.Or<TimeoutRejectedException>().CircuitBreakerAsync(3,TimeSpan.FromSeconds(15)))
            //.AddPolicyHandler(Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(1)));

            services.AddScoped<IConsumer<CatalogItemDeleted>, CatalogItemDeletedConsumer>();
            services.AddScoped<IConsumer<CatalogItemUpdated>, CatalogItemUpdatedConsumer>();
            services.AddScoped<IConsumer<CatalogItemCreated>, CatalogItemCreatedConsumer>();

            services.AddScoped<IReturnResponse, ReturnResponse>();
            services.AddScoped<IMongoDBRepository<InventoryItem>, MongoDBRepository<InventoryItem>>();
            services.AddScoped<IAddDataUseCase<InventoryItem>, AddDataUseCase<InventoryItem>>();
            services.AddScoped<IGetDataByIDUseCase<InventoryItem>, GetDataByIDUseCase<InventoryItem>>();
            services.AddScoped<IGetAllDataUseCase<InventoryItem>, GetAllDataUseCase<InventoryItem>>();
            services.AddScoped<IUpdateDataUseCase<InventoryItem>, UpdateDataUseCase<InventoryItem>>();
            services.AddScoped<ICatalogClient, CatalogClient>();
            services.AddScoped<InventoryItemDTOHelper>();

            services.AddScoped<IMongoDBRepository<CatalogItem>, MongoDBRepository<CatalogItem>>();
            services.AddScoped<IAddDataUseCase<CatalogItem>, AddDataUseCase<CatalogItem>>();
            services.AddScoped<IGetDataByIDUseCase<CatalogItem>, GetDataByIDUseCase<CatalogItem>>();
            services.AddScoped<IGetAllDataUseCase<CatalogItem>, GetAllDataUseCase<CatalogItem>>();
            services.AddScoped<IUpdateDataUseCase<CatalogItem>, UpdateDataUseCase<CatalogItem>>();
            services.AddScoped<IDeleteDataUseCase<CatalogItem>, DeleteDataUseCase<CatalogItem>>();


        }
    }
}
