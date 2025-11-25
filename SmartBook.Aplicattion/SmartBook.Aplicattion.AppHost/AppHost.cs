var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.SmartBook_Aplicattion_ApiService>("apiservice")
    .WithHttpHealthCheck("/health");

builder.AddProject<Projects.SmartBook_Aplicattion_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
