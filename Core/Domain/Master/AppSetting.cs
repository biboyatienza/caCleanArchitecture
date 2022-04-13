global using Domain.Common;

namespace Domain.Master
{
  public class AppSetting : BaseEntity<int>
  {
    public string ReferenceKey { get; set; } = String.Empty;
    public string Value { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public string Type { get; set; } = String.Empty;
  }
}