namespace Diazzo.Domain.Base;

public class EntityBase
{
    [PrimaryKey]
    [NotNull]
    [AutoIncrement]
    public int Id { get; set; }
    public bool IsDeleted { get; set; }
}
