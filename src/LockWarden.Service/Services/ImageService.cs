using LockWarden.DataAccess.Constants;
using LockWarden.DataAccess.Repositories;
using LockWarden.Domain.Models;
using LockWarden.Domain.ViewModels;
using LockWarden.Service.Commons;
using LockWarden.Service.Interfaces;
using LockWarden.Service.Tools;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockWarden.Service.Services
{
	public class ImageService : IImageService
	{
		private readonly Repository _repository;
		public ImageService()
		{
			_repository = new Repository();
		}

		public async Task<(bool IsSuccesful, string Message)> CreateAsync(ImageViewModel imageViewModel, string userpassword)
		{
			try
			{
				var CiphredStringImage = Crypter.Ciphr(Helper.ImageToString(imageViewModel.Content), Helper.ToSeed(userpassword), Crypt.Encrypt);
				var entity = new Image(null, imageViewModel.Name, CiphredStringImage, IdentitySingelton.GetInstance().UserId);
				await _repository.Images.CreateAsync(entity);
				return (true, "Succesful");
			}
			catch(Exception ex)
			{
				return (false, ex.Message);
			}
		}

		public async Task<(bool IsSuccesful, string Message)> DeleteAsync(int imageid, string userpassword)
		{
			try
			{
				await _repository.Images.DeleteAsync(imageid);
				return (true, "Successful");
			}
			catch(Exception ex) { return (false, ex.Message); }
		}

		public async Task<(string Path, string Message)> GetAsync(int id, string userpassword)
		{
			try
			{
				var img = await _repository.Images.GetAsync(id);
				var clearContent = Crypter.Ciphr(img.Content, Helper.ToSeed(userpassword), Crypt.Decrypt);
				var name = DB_Constants.DB_Path_Directory + $"\\{img.Id}.png";
				Helper.StringToImage(clearContent, name);
				return (name, "Success");
			}
			catch(Exception ex)
			{
				return ("", ex.Message);
			}
		}

		public async Task<(bool IsSuccesful, string Message)> UpdateAsync(ImageViewModel imageViewModel, string userpassword, int ImageId)
		{
			try
			{
				await _repository.Images.DeleteAsync(ImageId);
				await CreateAsync(imageViewModel, userpassword);
				return (true, "Successful");
			}
			catch(Exception ex)
			{
				return (false, ex.Message);
			}
		}
	}
}
