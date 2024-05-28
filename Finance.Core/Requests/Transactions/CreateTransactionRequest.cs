using Finance.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Finance.Core.Requests.Transactions;

public class CreateTransactionRequest : Request
{
	//Data Annotations pra validações > no futuro irei mudar pra fluentValidation
	[Required(ErrorMessage = "Título inválido")]
	[MaxLength(80, ErrorMessage = "O título deve conter apenas 80 caracteres")]
	public string Title { get; set; } = string.Empty;

	[Required(ErrorMessage = "Tipo inválido")]
	public ETransactionType Type { get; set; } = ETransactionType.Withdraw;

	[Required(ErrorMessage = "Valor inválido")]
	public decimal Amount { get; set; }

	[Required(ErrorMessage = "Categoria inválida")]
	public long CategoryId { get; set; }

	[Required(ErrorMessage = "Descrição inválida")]
	public string Description { get; set; } = string.Empty;

	[Required(ErrorMessage = "Data inválida")]
	public DateTime? PaidOrReceivedAt { get; set; }
}
