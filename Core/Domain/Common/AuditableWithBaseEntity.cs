namespace Domain.Common
{
  public abstract class AuditableWithBaseEntity<T> : BaseEntity<T>, IAuditableEntity
  {
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public long CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public long UpdatedBy { get; set; }
  }
}