using Microsoft.Extensions.DependencyInjection;

namespace DemoMS.Service.Inventory
{
    public static class ServicesRegistration
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration, WebApplicationBuilder builder)
        {

            var databaseConfiguration = new DatabaseConfiguration(configuration);
            var connectionString = databaseConfiguration.GetConnectionString();
            var (collectionName, databaseName) = databaseConfiguration.GetDatabaseSettings();

            // Mongo DB conversion to redable format
            BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
            BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));

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
                var catalogCollectionName = configuration["CatalogConfiguration:CollectionName"];
                var catalogDatabaseName = configuration["CatalogConfiguration:DatabaseName"];

                var context = new MongoDBContext<CatalogItem>(connectionString, catalogCollectionName, catalogDatabaseName);
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

            services.AddScoped<IGetDataByIDUseCase<CatalogItem>>(provider =>
            {
                var dbContext = provider.GetRequiredService<IMongoDBRepository<CatalogItem>>();
                return new GetDataByIDUseCase<CatalogItem>(dbContext);
            });

            services.AddScoped<IGetAllDataUseCase<CatalogItem>>(provider =>
            {
                var dbContext = provider.GetRequiredService<IMongoDBRepository<CatalogItem>>();
                return new GetAllDataUseCase<CatalogItem>(dbContext);
            });

            services.AddScoped<IUpdateDataUseCase<CatalogItem>>(provider =>
            {
                var repository = provider.GetRequiredService<IMongoDBRepository<CatalogItem>>();
                return new UpdateDataUseCase<CatalogItem>(repository);
            });

            services.AddScoped<IAddDataUseCase<CatalogItem>>(provider =>
            {
                var repository = provider.GetRequiredService<IMongoDBRepository<CatalogItem>>();
                return new AddDataUseCase<CatalogItem>(repository);
            });

            services.AddScoped<IDeleteDataUseCase<CatalogItem>>(provider =>
            {
                var repository = provider.GetRequiredService<IMongoDBRepository<CatalogItem>>();
                return new DeleteDataUseCase<CatalogItem>(repository);
            });

        }
    }
}
