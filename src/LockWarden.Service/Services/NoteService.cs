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
	public class NoteService : INoteService
	{
		private readonly Repository _repository;
		public NoteService()
		{
            _repository = new Repository();
        }

		public async Task<(bool IsSuccesful, string Message)> CreateAsync(NoteViewModel noteViewModel, string userpassword)
		{
			try
			{
				var CiphredContent = Crypter.Ciphr(noteViewModel.Content, Helper.ToSeed(userpassword), Crypt.Encrypt);
				var note = new Note(DateTime.Now, noteViewModel.Header, CiphredContent, IdentitySingelton.GetInstance().UserId);
				await _repository.Notes.CreateAsync(note);
				return (true, "Success");
			}
			catch(Exception ex)
			{
				return (false, ex.Message);
			}
		}

		public async Task<(bool IsSuccesful, string Message)> DeleteAsync(int noteid, string userpassword)
		{
            try
            {
                await _repository.Notes.DeleteAsync(noteid);
                return (true, "Successful");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

		public async Task<(List<NoteViewModel> notes, string Message)> GetAllAsync(int userid, string userpassword)
		{
            try
            {
				var noteviewmodels = new List<NoteViewModel>();
                var notes = await _repository.Notes.GetAllAsync();
				var usernotes = notes.Where(x => x.UserId == IdentitySingelton.GetInstance().UserId);
				foreach (var usernote in usernotes)
				{
					var content = (Crypter.Ciphr(usernote.Content, Helper.ToSeed(userpassword), Crypt.Decrypt));
					NoteViewModel noteViewModel = new NoteViewModel(usernote.Header, content);
					noteViewModel.Id = usernote.Id;
					noteviewmodels.Add(noteViewModel);
				}
                return (noteviewmodels, "Succesful");
            }
            catch (Exception ex)
            {
                return (null, ex.Message);
            }
        }

		public async Task<(NoteViewModel note, string Message)> GetAsync(int NoteId, string userpassword)
		{
            try
            {
                var note = await _repository.Notes.GetAsync(NoteId);
                var content = (Crypter.Ciphr(note.Content, Helper.ToSeed(userpassword), Crypt.Decrypt));
                NoteViewModel noteViewModel = new NoteViewModel(note.Header, content);
                noteViewModel.Id = note.Id;
                return (noteViewModel, "Succesful");
            }
            catch (Exception ex)
            {
                return (null, ex.Message);
            }
        }

		public async Task<(bool IsSuccesful, string Message)> UpdateAsync(NoteViewModel noteViewModel, string userpassword, int ImageId)
		{
			try
			{
				await _repository.Notes.DeleteAsync(ImageId);
				await CreateAsync(noteViewModel, userpassword);
				return (true, "Successful");
			}
			catch(Exception ex)
			{
				return (false, ex.Message);
			}
		}
	}
}
