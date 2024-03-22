namespace DemoMS.Service.Inventory
{
    public static class ServicesRegistration
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {

            var databaseConfiguration = new DatabaseConfiguration(configuration);
            var connectionString = databaseConfiguration.GetConnectionString();
            var (collectionName, databaseName) = databaseConfiguration.GetDatabaseSettings();

            // Mongo DB conversion to redable format
            BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
            BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));

            //configuring MongoDB to use the connection string inside the appsettings
            services.AddScoped(provider =>
            {
                var context = new MongoDBContext<InventoryItem>(connectionString, collectionName, databaseName);
                return context;
            });

            services.AddScoped<IMongoDBRepository<InventoryItem>, MongoDBRepository<InventoryItem>>();
            //services.AddScoped<IAddDataUseCase<Item>, AddDataUseCase<Item>>();
            services.AddScoped<IGetDataByIDUseCase<InventoryItem>, GetDataByIDUseCase<InventoryItem>>();
            //services.AddScoped<IGetAllDataUseCase<InventoryItem>, GetAllDataUseCase<InventoryItem>>();
            //services.AddScoped<IUpdateDataUseCase<Item>, UpdateDataUseCase<Item>>();
            //services.AddScoped<IDeleteDataUseCase, DeleteDataUseCase<Item>>();
        }
    }
}
