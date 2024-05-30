using Finance.Core.Handlers;
using Finance.Core.Models;
using Finance.Core.Requests.Categories;
using Finance.Core.Responses;
using System.Net.Http.Json;

namespace Finance.Web.Handlers;

public class CategoryHandler(IHttpClientFactory httpClientFactory) : ICategoryHandler
{
	private readonly HttpClient _httpClient = httpClientFactory.CreateClient(WebConfiguration.HttpClientName);

	public async Task<Response<Category?>> CreateAsync(CreateCategoryRequest request)
	{
		var result = await _httpClient.PostAsJsonAsync("v1/categories", request);

		// TODO ajustar com try catch pra tratar
		return await result.Content.ReadFromJsonAsync<Response<Category?>>()
			?? new Response<Category?>(null, 400, message: "Falha ao criar categoria");
	}

	public async Task<Response<Category?>> DeleteAsync(DeleteCategoryRequest request)
	{
		var result = await _httpClient.DeleteAsync($"v1/categories/{request.Id}");

		// TODO ajustar com try catch pra tratar
		return await result.Content.ReadFromJsonAsync<Response<Category?>>()
			?? new Response<Category?>(null, 400, message: "Falha ao excluir categoria");
	}

	//usando expression body
	public async Task<PagedResponse<List<Category>?>> GetAllAsync(GetAllCategoriesRequest request)
		=> await _httpClient.GetFromJsonAsync<PagedResponse<List<Category>?>>("v1/categories")
			?? new PagedResponse<List<Category>?>(null, 400, message: "Falha ao econtrar lista de categorias");

	//usando expression body
	public async Task<Response<Category?>> GetByIdAsync(GetCategoryByIdRequest request)
		=> await _httpClient.GetFromJsonAsync<Response<Category?>>($"v1/categories/{request.Id}")
			?? new Response<Category?>(null, 400, message: "Falha ao encontrar categoria");

	public async Task<Response<Category?>> UpdateAsync(UpdateCategoryRequest request)
	{
		var result = await _httpClient.PutAsJsonAsync($"v1/categories/{request.Id}", request);

		// TODO ajustar com try catch pra tratar
		return await result.Content.ReadFromJsonAsync<Response<Category?>>()
			?? new Response<Category?>(null, 400, message: "Falha ao editar categoria");
	}
}
