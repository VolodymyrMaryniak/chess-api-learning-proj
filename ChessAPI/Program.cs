using ChessAPI.Data.Conventions;
using ChessAPI.Data.Schema;
using ChessAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDatabaseAndRepositories(builder.Configuration);
builder.Services.AddServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

MongoDbConventions.RegisterMongoDbConventions();

var app = builder.Build();

await EnsureSchemaAppliedAsync(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
return;

async Task EnsureSchemaAppliedAsync(IHost host)
{
    await using var scope = host.Services.CreateAsyncScope();
    var schemaManager = scope.ServiceProvider.GetRequiredService<ChessDbSchemaManager>();
    await schemaManager.EnsureSchemaAppliedAsync();
}