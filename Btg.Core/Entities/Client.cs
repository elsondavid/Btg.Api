namespace Btg.Core.Entities;
public partial class Client : EntityBase
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Age { get; set; }
    public string Andress { get; set; }
}