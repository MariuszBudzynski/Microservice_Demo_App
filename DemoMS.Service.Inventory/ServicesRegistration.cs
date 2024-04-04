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

            services.AddHttpClient<CatalogClient>()
            .AddTransientHttpErrorPolicy( builder => builder.WaitAndRetryAsync(
                5,
                retryAttemp => TimeSpan.FromSeconds(Math.Pow(2,retryAttemp))))
            .AddPolicyHandler(Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(1)));


            services.AddScoped<IResponse,Response>();
            services.AddScoped<IMongoDBRepository<InventoryItem>, MongoDBRepository<InventoryItem>>();
            services.AddScoped<IAddDataUseCase<InventoryItem>, AddDataUseCase<InventoryItem>>();
            services.AddScoped<IGetDataByIDUseCase<InventoryItem>, GetDataByIDUseCase<InventoryItem>>();
            services.AddScoped<IGetAllDataUseCase<InventoryItem>, GetAllDataUseCase<InventoryItem>>();
            services.AddScoped<IUpdateDataUseCase<InventoryItem>, UpdateDataUseCase<InventoryItem>>();
            services.AddScoped<ICatalogClient, CatalogClient>();
            services.AddScoped<InventoryItemDTOHelper>();
        }
    }
}
