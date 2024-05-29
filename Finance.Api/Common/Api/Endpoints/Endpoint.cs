﻿using Finance.Api.Common.Api;
using Finance.Api.Common.Api.Endpoints.Categories;
using Finance.Api.Common.Api.Endpoints.Transactions;

namespace Finance.Api.Common.Api.Endpoints;

public static class Endpoint
{
	public static void MapEndpoints(this WebApplication app)
	{
		var endpoints = app.MapGroup("");

		endpoints.MapGroup("/")
			.WithTags("Health Check")
			.MapGet("/", () => new { message = "OK" });

		endpoints.MapGroup("v1/categories")
			.WithTags("Categories")
			.MapEndpoint<CreateCategoryEndpoint>()
			.MapEndpoint<UpdateCategoryEndpoint>()
			.MapEndpoint<DeleteCategoryEndpoint>()
			.MapEndpoint<GetCategoryByIdEndpoint>()
			.MapEndpoint<GetAllCategoriesEndpoint>();

		endpoints.MapGroup("v1/transactions")
			.WithTags("Transactions")
			.RequireAuthorization()
			.MapEndpoint<CreateTransactionEndpoint>()
			.MapEndpoint<UpdateTransactionEndpoint>()
			.MapEndpoint<DeleteTransactionEndpoint>()
			.MapEndpoint<GetTransactionByIdEndpoint>()
			.MapEndpoint<GetTransactionsByPeriodEndpoint>();
	}

	private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
	where TEndpoint : IEndpoint
	{
		TEndpoint.Map(app);
		return app;
	}
}
