using DemoServer.Handler;

using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureHttpJsonOptions(Json.Configure);
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen(OpenAPIDoc.Configure);
builder.Services.AddOpenApi(options =>
{
    // options.AddScalarTransformers(); // Required for extensions to work
});

var app = builder.Build();
app.MapOpenApi();
app.MapScalarApiReference();
// app.MapSwagger();
// app.UseSwagger();
// app.UseSwaggerUI(c => c.SwaggerEndpoint("v1/swagger.json", "v1"));
app.AddAuthHandlers();
app.AddSecurityHandlers();
app.AddEmbeddingHandlers();
app.AddRetrievalHandlers();
app.AddDataSourceHandlers();
app.Run();