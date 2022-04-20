namespace Domain.Product
{
  public class Category : AuditableWithBaseEntity<int>
  {
    public string Name { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public int DisplayOrder { get; set; }
  }
}