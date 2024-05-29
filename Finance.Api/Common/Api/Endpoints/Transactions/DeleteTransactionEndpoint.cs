using Finance.Core.Handlers;
using Finance.Core.Models;
using Finance.Core.Requests.Transactions;
using Finance.Core.Responses;

namespace Finance.Api.Common.Api.Endpoints.Transactions;

public class DeleteTransactionEndpoint : IEndpoint
{
	public static void Map(IEndpointRouteBuilder app)
	=> app.MapDelete("/{id}", HandleAsync)
		.WithName("Transactions: Delete")
		.WithSummary("Exclui uma transação")
		.WithDescription("Exclui uma transação")
		.WithOrder(3)
		.Produces<Response<Transaction?>>();

	private static async Task<IResult> HandleAsync(
		ITransactionHandler handler,
		long id)
	{
		var request = new DeleteTransactionRequest
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
