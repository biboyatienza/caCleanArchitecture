using Domain.Master;

namespace Application.Master
{
  public interface IMasterServices
  {
    Task<List<AppSetting>> GetAppSettingsAsync();
    Task<AppSetting> GetAppSettingByIdAsync(int id);
    Task<AppSetting> UpsertAppSettingAsync(AppSetting appSetting);
    Task<bool> DeleteAppSettingAsync(int id);
  }

}