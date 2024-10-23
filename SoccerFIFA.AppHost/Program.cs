var builder = DistributedApplication.CreateBuilder(args);

var envVar = builder.Configuration["TodayTalk"];

// var connstr = builder.AddConnectionString("DefaultConnection");

var sqlServerDb = builder.AddSqlServer("sqlServer")
    .AddDatabase("sqldata");

var api = builder.AddProject<Projects.WebApiFIFA>("backend")
    .WithEnvironment("Meeting", envVar)
    .WithReference(sqlServerDb);

builder.AddProject<Projects.BlazorFIFA>("frontend")
    .WithReference(api);

builder.Build().Run();
