using Domain.Master;
using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Master
{
  internal class MasterServices : IMasterServices
  {
    private readonly IUnitOfWork _unitOfWork;
    public MasterServices(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }
    public async Task<AppSetting> UpsertAppSettingAsync(AppSetting appSetting)
    {
      try
      {
        if(appSetting.Id > 0)
          _unitOfWork.AppSettingRepo.Update(appSetting);
        else
          _unitOfWork.AppSettingRepo.Add(appSetting);
        await _unitOfWork.SaveAsync();
        return appSetting;    
      }
      catch (System.Exception)
      {
        throw;
      }
    }
    public async Task<bool> DeleteAppSettingAsync(int id)
    {
      try
      {
        var isDeleted = await _unitOfWork.AppSettingRepo.Delete(id);
        await _unitOfWork.SaveAsync();
        return isDeleted;
      }
      catch (System.Exception)
      {
        throw;
      }
    }
    public async Task<List<AppSetting>> GetAppSettingsAsync()
    {
      try
      {
        var appSettings = await _unitOfWork.AppSettingRepo
          .TableNoTracking
          .OrderBy(t => t.ReferenceKey)
          .ToListAsync();  
        return appSettings;            
      }
      catch (System.Exception)
      {
        throw;
      }
    }
    public async Task<AppSetting> GetAppSettingByIdAsync(int id)
    {
      try
      {
        var appSetting = await _unitOfWork.AppSettingRepo.Get(id);
        return appSetting; 
      }
      catch (System.Exception)
      {
        throw;
      }
    }
 }
}