using Finance.Core.Handlers;
using Finance.Core.Requests.Transactions;
using Finance.Core.Responses;
using System.Transactions;

namespace Finance.Api.Common.Api.Endpoints.Transactions;

public class CreateTransactionEndpoint : IEndpoint
{
	public static void Map(IEndpointRouteBuilder app)
	=> app.MapPost("/", HandleAsync)
		.WithName("Transactions: Create")
		.WithSummary("Cria uma nova transação")
		.WithDescription("Cria uma nova transação")
		.WithOrder(1)
		.Produces<Response<Transaction?>>();

	private static async Task<IResult> HandleAsync(
		ITransactionHandler handler,
		CreateTransactionRequest request)
	{
		request.UserId = ApiConfiguration.UserId;
		var result = await handler.CreateAsync(request);
		return result.IsSuccess
			? TypedResults.Created($"/{result.Data?.Id}", result)
			: TypedResults.BadRequest(result.Data);
	}
}
