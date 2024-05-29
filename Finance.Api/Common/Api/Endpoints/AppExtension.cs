namespace Finance.Api.Common.Api.Endpoints;

public static class AppExtension
{
	//swagger somente para o ambiente de desenvolvimento
	public static void ConfigureDevEnvironment(this WebApplication app)
	{
		app.UseSwagger();
		app.UseSwaggerUI();
		//app.MapSwagger().RequireAuthorization();
	}
}
