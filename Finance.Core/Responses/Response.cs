using System.Text.Json.Serialization;

namespace Finance.Core.Responses;

public class Response<TData> //TData é o tipo dos dados pra evitar o genericos dynamic e object
{
	//Http Status Code
	private int _code = Configuration.DefaultStatusCode;

    // contrutor pra serealizar com status poadrao
    [JsonConstructor]
    public Response() 
        => _code = Configuration.DefaultStatusCode;

    // usando optinal paramenters
    public Response(
        TData? data,
        int code = Configuration.DefaultStatusCode,
        string? message = null)
    {
        Data = data;
        _code = code;
        Message = message;
    }

    // genericos evitar dynamic e object
    public TData? Data { get; set; }
	public string? Message { get; set; }

	[JsonIgnore]
	public bool IsSuccess => _code is >= 200 and <= 299;
}
