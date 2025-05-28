namespace Btg.Core.Entities;

public interface IEntityBase
{
    IList<string>? Errors { get; }
    bool HasErrors { get; }
    string? ErrorsAsString { get; }
}

public class EntityBase : IEntityBase
{
    public virtual IList<string>? Errors { get; private set; }
    public virtual bool HasErrors => Errors != null && Errors.Any();

    public virtual string? ErrorsAsString
    {
        get
        {
            if (Errors == null || !Errors.Any())
                return null;

            return string.Join(Environment.NewLine, Errors);
        }
    }

    public virtual EntityBase AddError(IEnumerable<string> errors)
    {
        if (errors != null && errors.Any())
        {
            foreach (var error in errors)
            {
                AddError(error);
            }
        }
        return this;
    }

    public virtual EntityBase AddError(string error)
    {
        Errors ??= new List<string>();

        Errors.Add(error);
        return this;
    }
}
