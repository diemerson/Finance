using System.Text.Json.Serialization;

namespace Finance.Core.Responses;

public class PagedResponse<TData> : Response<TData>
{
    [JsonConstructor]
    public PagedResponse(
        TData? data,
        int totalCount,
        int currentPage = 1,
        int pageSize = Configuration.DefaultPageSize) 
            : base(data) //como herda do response ja posso utilizar aqui no construtor
    {
        Data = data;
        TotalCount = totalCount;
        CurrentPage = currentPage;
        PageSize = pageSize;
    }

    public PagedResponse(
        TData? data,
        int code = Configuration.DefaultStatusCode,
        string? message = null) 
            : base(data, code, message)
    {

    }

    public int CurrentPage { get; set; }

	//cast com um double pois pra divisao precisamos de um tipo com ponto flutuante
	//math ceiling irá arredondar pra cima
	public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);

	public int PageSize {  get; set; } = Configuration.DefaultPageSize;
	public int TotalCount { get; set; }
}
