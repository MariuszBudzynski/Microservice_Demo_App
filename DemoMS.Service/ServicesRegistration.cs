namespace DemoMS.Service
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
                var context = new MongoDBContext<Item>(connectionString, collectionName, databaseName);
                return context;
            });

            services.AddScoped<Response>();
            services.AddScoped<IMongoDBRepository<Item>,MongoDBRepository<Item>>();
            services.AddScoped<IAddDataUseCase<Item>, AddDataUseCase<Item>>();
            services.AddScoped<IGetDataByIDUseCase<Item>, GetDataByIDUseCase<Item>>();
            services.AddScoped<IGetAllDataUseCase<Item>, GetAllDataUseCase<Item>>();
            services.AddScoped<IUpdateDataUseCase<Item>, UpdateDataUseCase<Item>>();
            services.AddScoped<IDeleteDataUseCase<Item>, DeleteDataUseCase<Item>>();

        }
    }
}
