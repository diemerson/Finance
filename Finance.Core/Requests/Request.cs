namespace Finance.Core.Requests;

//padronização das requests
//não poderá ser instanceada (abstract) apenas herdada ou extendidada > se usar sealed nao poderá ser herdada

public abstract class Request
{
	public string UserId { get; set; } = string.Empty;

}
