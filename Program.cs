using SentinelScan.Api.Interfaces;
using SentinelScan.Api.Services;

var builder = WebApplication.CreateBuilder(args);

//Register all scanneres
builder.Services.AddScoped<IScanner, SizeScanner>();
builder.Services.AddScoped<IScanner, SecurityScanner>();
builder.Services.AddScoped<IScanner, ExtensionScanner>();
builder.Services.AddScoped<IScanner, PromptInjectionScanner>();

//Register the orchestrator
builder.Services.AddScoped<ScannerOrchestrator>();


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//API infrastructure
builder.Services.AddControllers();//instructiunea asta cauta toate clasele ce mostenesc Contoller si au [APIController]
builder.Services.AddOpenApi();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
