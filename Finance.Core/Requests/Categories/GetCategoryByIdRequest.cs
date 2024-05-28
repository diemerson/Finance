using System.ComponentModel.DataAnnotations;

namespace Finance.Core.Requests.Categories;

public class GetCategoryByIdRequest : Request
{
	[Required(ErrorMessage = "Id deve ser informado")]
	public long Id { get; set; }
}
