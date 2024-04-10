namespace DemoMS.Service.Inventory
{
    public static class ServicesRegistration
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration, WebApplicationBuilder builder)
        {

            var databaseConfiguration = new DatabaseConfiguration(configuration);
            var connectionString = databaseConfiguration.GetConnectionString();
            var (collectionName, databaseName) = databaseConfiguration.GetDatabaseSettings();
            var massTransitConfig = new MassTransitConfig(configuration);

            // Mongo DB conversion to redable format
            BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
            BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));

            massTransitConfig.MassTransitConfiguration(services);
            massTransitConfig.AddMassTransitConsumer<CatalogItemDeletedConsumer>(services);
            massTransitConfig.AddMassTransitConsumer<CatalogItemUpdatedConsumer>(services);
            massTransitConfig.AddMassTransitConsumer<CatalogItemCreatedConsumer>(services);

            builder.Services.AddValidatorsFromAssemblyContaining(typeof(GrantItemsDTO));

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //configuring MongoDB to use the connection string inside the appsettings
            services.AddScoped(provider =>
            {
                var context = new MongoDBContext<InventoryItem>(connectionString, collectionName, databaseName);
                return context;
            });

            services.AddScoped(provider =>
            {
                //this needs to be testted, check if this connection string is proper

                //var catalogCollectionName = configuration["CatalogConfiguration:CollectionName"];
                //var catalogDatabaseName = configuration["CatalogConfiguration:DatabaseName"];

                //var context = new MongoDBContext<CatalogItem>(connectionString, catalogCollectionName, catalogDatabaseName);
                //return context;

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
            services.AddScoped<MassTransitConfig>();

            services.AddScoped<IMongoDBRepository<CatalogItem>, MongoDBRepository<CatalogItem>>();
            services.AddScoped<IAddDataUseCase<CatalogItem>, AddDataUseCase<CatalogItem>>();
            services.AddScoped<IGetDataByIDUseCase<CatalogItem>, GetDataByIDUseCase<CatalogItem>>();
            services.AddScoped<IGetAllDataUseCase<CatalogItem>, GetAllDataUseCase<CatalogItem>>();
            services.AddScoped<IUpdateDataUseCase<CatalogItem>, UpdateDataUseCase<CatalogItem>>();
            services.AddScoped<IDeleteDataUseCase<CatalogItem>, DeleteDataUseCase<CatalogItem>>();


        }
    }
}
