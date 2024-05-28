namespace Finance.Core.Models;

public class Category
{
	// Guid + controle 128bits (2 ciclos pra processar)
	// se usar int tem + previsibilidade por ser sequencial
	// context.SaveChanges(); -> recuperar o ID

	public long Id { get; set; }
	public string Title { get; set; } = string.Empty;
	public string? Description { get; set; }
	public string UserId { get; set; } = string.Empty;
}
