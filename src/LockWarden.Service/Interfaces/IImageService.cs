using LockWarden.Domain.Models;
using LockWarden.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockWarden.Service.Interfaces
{
    public interface IImageService
    {
        Task<(bool IsSuccesful, string Message)> CreateAsync(ImageViewModel imageViewModel, string userpassword);
        Task<(bool IsSuccesful, string Message)> UpdateAsync(ImageViewModel imageViewModel,string userpassword);
        Task<(bool IsSuccesful, string Message)> GetAllAsync(int userid, string userpassword);
        Task<(bool IsSuccesful, string Message)> DeleteAsync(int imageid, string userpassword);
    }
}
