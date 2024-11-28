var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.AspireTestApp_ApiService>("apiservice");
var redis = builder.AddRedis("cache");

builder.AddProject<Projects.AspireTestApp_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WithReference(redis)
    .WaitFor(apiService);

builder.Build().Run();
