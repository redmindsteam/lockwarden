﻿using LockWarden.DataAccess.Repositories;
using LockWarden.Domain.ViewModels;
using LockWarden.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockWarden.Service.Services
{
    public class ImageService:IImageService
    {
        private readonly Repository _repository;
        public ImageService()
        {
            _repository = new Repository();
        }

        public Task<(bool IsSuccesful, string Message)> CreateAsync(ImageViewModel imageViewModel, string userpassword)
        {
            throw new NotImplementedException();
        }

        public Task<(bool IsSuccesful, string Message)> DeleteAsync(int imageid, string userpassword)
        {
            throw new NotImplementedException();
        }

        public Task<(bool IsSuccesful, string Message)> GetAllAsync(int userid, string userpassword)
        {
            throw new NotImplementedException();
        }

        public Task<(bool IsSuccesful, string Message)> UpdateAsync(ImageViewModel imageViewModel, string userpassword)
        {
            throw new NotImplementedException();
        }
    }
}
