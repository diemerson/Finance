﻿using Finance.Core.Handlers;
using Finance.Core.Models;
using Finance.Core.Requests.Categories;
using Finance.Core.Responses;

namespace Finance.Api.Common.Api.Endpoints.Categories;

public class GetCategoryByIdEndpoint : IEndpoint
{
	public static void Map(IEndpointRouteBuilder app)
	=> app.MapGet("/{id}", HandleAsync)
		.WithName("Categories: Get By Id")
		.WithSummary("Recupera uma categoria")
		.WithDescription("Recupera uma categoria")
		.WithOrder(4)
		.Produces<Response<Category?>>();

	private static async Task<IResult> HandleAsync(
		ICategoryHandler handler,
		long id)
	{
		var request = new GetCategoryByIdRequest
		{
			UserId = ApiConfiguration.UserId,
			Id = id
		};

		var result = await handler.GetByIdAsync(request);
		return result.IsSuccess
			? TypedResults.Ok(result)
			: TypedResults.BadRequest(result);
	}
}
