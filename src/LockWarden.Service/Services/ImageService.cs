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
				var entity = new Image(DateTime.Now, imageViewModel.Name, CiphredStringImage, IdentitySingelton.GetInstance().UserId);
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

		public async Task<(List<ImageViewModel> images, string Message)> GetAllAsync(int userid, string userpassword)
		{
            try
            {
                var imagesviewmodels = new List<ImageViewModel>();
                var images = await _repository.Images.GetAllAsync();
                var userimages = images.Where(x => x.Id == IdentitySingelton.GetInstance().UserId);
                foreach (var image in userimages)
                {
                    var clearContent = Crypter.Ciphr(image.Content, Helper.ToSeed(userpassword), Crypt.Decrypt);
                    ImageViewModel imageViewModel = new ImageViewModel(image.Content, clearContent);
                    imageViewModel.Id = image.Id;
                    var name = DB_Constants.DB_Path_Directory + $"\\{image.Id}.png";
                    Helper.StringToImage(clearContent, name);
                }
                return (imagesviewmodels, "Success");
            }
            catch (Exception ex)
            {
                return (null, ex.Message);
            }
        }

		public async Task<(ImageViewModel image, string Message)> GetAsync(int id, string userpassword)
		{
            try
            {
                var img = await _repository.Images.GetAsync(id);
                var clearContent = Crypter.Ciphr(img.Content, Helper.ToSeed(userpassword), Crypt.Decrypt);
                ImageViewModel imageViewModel = new ImageViewModel(img.Content, clearContent);
                imageViewModel.Id = img.Id;
                var name = DB_Constants.DB_Path_Directory + $"\\{img.Id}.png";
                Helper.StringToImage(clearContent, name);
                return (imageViewModel, "Success");
            }
            catch (Exception ex)
            {
                return (null, ex.Message);
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
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
	}
}
