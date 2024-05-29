using Finance.Core.Handlers;
using Finance.Core.Models;
using Finance.Core.Requests.Categories;
using Finance.Core.Responses;

namespace Finance.Api.Common.Api.Endpoints.Categories;

public class UpdateCategoryEndpoint : IEndpoint
{
	public static void Map(IEndpointRouteBuilder app)
	=> app.MapPut("/{id}", HandleAsync)
		.WithName("Categories: Update")
		.WithSummary("Atualiza uma categoria")
		.WithDescription("Atualiza uma categoria")
		.WithOrder(2)
		.Produces<Response<Category?>>();

	private static async Task<IResult> HandleAsync(
		ICategoryHandler handler,
		UpdateCategoryRequest request,
		long id)
	{
		request.UserId = ApiConfiguration.UserId;
		request.Id = id;

		var result = await handler.UpdateAsync(request);
		return result.IsSuccess
			? TypedResults.Ok(result)
			: TypedResults.BadRequest(result);
	}
}
