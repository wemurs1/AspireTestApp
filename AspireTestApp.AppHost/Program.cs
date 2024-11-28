var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.AspireTestApp_ApiService>("apiservice");

builder.AddProject<Projects.AspireTestApp_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
