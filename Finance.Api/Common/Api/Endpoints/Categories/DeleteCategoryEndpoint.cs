﻿using Finance.Core.Handlers;
using Finance.Core.Models;
using Finance.Core.Requests.Categories;
using Finance.Core.Responses;

namespace Finance.Api.Common.Api.Endpoints.Categories;

public class DeleteCategoryEndpoint : IEndpoint
{
	public static void Map(IEndpointRouteBuilder app)
	=> app.MapDelete("/{id}", HandleAsync)
		.WithName("Categories: Delete")
		.WithSummary("Exclui uma categoria")
		.WithDescription("Exclui uma categoria")
		.WithOrder(3)
		.Produces<Response<Category?>>();

	private static async Task<IResult> HandleAsync(
		ICategoryHandler handler,
		long id)
	{
		var request = new DeleteCategoryRequest
		{
			UserId = ApiConfiguration.UserId,
			Id = id
		};

		var result = await handler.DeleteAsync(request);
		return result.IsSuccess
			? TypedResults.Ok(result)
			: TypedResults.BadRequest(result);
	}
}
