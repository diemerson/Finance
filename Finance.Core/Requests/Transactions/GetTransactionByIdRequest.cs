using System.ComponentModel.DataAnnotations;

namespace Finance.Core.Requests.Transactions;

public class GetTransactionByIdRequest : Request
{
	[Required(ErrorMessage = "Id deve ser informado")]
	public long Id { get; set; }
}
