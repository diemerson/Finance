using Finance.Api;
using Finance.Api.Common.Api;
using Finance.Api.Common.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
builder.AddConfiguration();
builder.AddDataContexts();
builder.AddCrossOrigin();
builder.AddDocumentation();
builder.AddServices();

var app = builder.Build();
if (app.Environment.IsDevelopment())
	app.ConfigureDevEnvironment();

app.UseCors(ApiConfiguration.CorsPolicyName);
app.MapEndpoints();

app.Run();
