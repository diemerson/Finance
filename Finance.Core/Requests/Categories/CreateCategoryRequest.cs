using System.ComponentModel.DataAnnotations;

namespace Finance.Core.Requests.Categories;

public class CreateCategoryRequest : Request
{
	//Data Annotations pra validações > no futuro irei mudar pra fluentValidation
	[Required(ErrorMessage = "Título inválido")]
	[MaxLength(80, ErrorMessage = "O título deve conter apenas 80 caracteres")]
	public string Title { get; set;} = string.Empty;

	[Required(ErrorMessage = "Descrição inválida")]
	public string Description { get; set; } = string.Empty;
}
