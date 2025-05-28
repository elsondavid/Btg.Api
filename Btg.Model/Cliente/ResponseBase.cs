namespace Doc.Model.Cliente;

public class ResponseBase
{
    public ResponseBase()
    { }

    public ResponseBase(string errorMessage)
    {
        Errors = [errorMessage];
    }

    public ResponseBase(IList<string> errors)
    {
        Errors = errors;
    }

    public Guid? Id { get; set; }
    public IList<string>? Errors { get; set; }
    public bool HasErrors => Errors != null && Errors.Any();
}