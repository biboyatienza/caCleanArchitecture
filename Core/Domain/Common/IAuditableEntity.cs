namespace Domain.Common 
{
  public interface IAuditableEntity
  {
    bool IsDeleted { get; set; }
    DateTime CreatedAt { get; set; }
    long CreatedBy { get; set; }
    DateTime? UpdatedAt { get; set; }
    long UpdatedBy { get; set; }
  }
}