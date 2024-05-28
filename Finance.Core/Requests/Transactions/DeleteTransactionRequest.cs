using System.ComponentModel.DataAnnotations;

namespace Finance.Core.Requests.Transactions;

public class DeleteTransactionRequest : Request
{
	[Required(ErrorMessage = "Id deve ser informado")]
	public long Id { get; set; }
}
