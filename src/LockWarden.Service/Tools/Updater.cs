using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LockWarden.DataAccess.Repositories;
using LockWarden.Domain.Models;

namespace LockWarden.Service.Tools;

public class Updater
{
	Repository repository = new();
	public async Task<bool> UpdateByUser(int id, string oldPasw, string newPasw)
	{
		var logins = (await repository.Logins.GetAllAsync()).Where(x => x.UserId == id).Select(x => UpdateLogin(x, oldPasw, newPasw)).ToList();
		var cards = (await repository.Cards.GetAllAsync()).Where(x => x.UserId == id).Select(x => UpdateCard(x, oldPasw, newPasw)).ToList();
		var images = (await repository.Images.GetAllAsync()).Where(x => x.UserId == id).Select(x => UpdateImage(x, oldPasw, newPasw)).ToList();
		var notes = (await repository.Notes.GetAllAsync()).Where(x => x.UserId == id).Select(x => UpdateNote(x, oldPasw, newPasw)).ToList();
		await repository.Logins.DeleteAllAsync(id);
		await repository.Logins.AddAllAsync(logins);

		await repository.Cards.DeleteAllAsync(id);
		await repository.Cards.AddAllAsync(cards);

		await repository.Notes.DeleteAllAsync(id);
		await repository.Notes.AddAllAsync(notes);

		await repository.Images.DeleteAllAsync(id);
		await repository.Images.AddAllAsync(images);
		return false;
	}
	public Card UpdateCard(Card entity, string oldPasw, string newPasw)
	{
		int oldSeed = Helper.ToSeed(oldPasw), newSeed = Helper.ToSeed(newPasw);
		string number = Crypter.Ciphr(Crypter.Ciphr(entity.Number, oldSeed, Crypt.Decrypt), newSeed, Crypt.Encrypt);
		string pin = Crypter.Ciphr(Crypter.Ciphr(entity.Pin, oldSeed, Crypt.Decrypt), newSeed, Crypt.Encrypt);
		entity.Number = number;
		entity.Pin = pin;
		return entity;
	}
	public Login UpdateLogin(Login entity, string oldPasw, string newPasw)
	{
		int oldSeed = Helper.ToSeed(oldPasw), newSeed = Helper.ToSeed(newPasw);
		string username = Crypter.Ciphr(Crypter.Ciphr(entity.Username, oldSeed, Crypt.Decrypt), newSeed, Crypt.Encrypt);
		string passw = Crypter.Ciphr(Crypter.Ciphr(entity.Password, oldSeed, Crypt.Decrypt), newSeed, Crypt.Encrypt);
		entity.Username = username;
		entity.Password = passw;
		return entity;
	}
	public Image UpdateImage(Image entity, string oldPasw, string newPasw)
	{
		int oldSeed = Helper.ToSeed(oldPasw), newSeed = Helper.ToSeed(newPasw);
		string content = Crypter.Ciphr(Crypter.Ciphr(entity.Content, oldSeed, Crypt.Decrypt), newSeed, Crypt.Encrypt);
		entity.Content = content;
		return entity;
	}
	public Note UpdateNote(Note entity, string oldPasw, string newPasw)
	{
		int oldSeed = Helper.ToSeed(oldPasw), newSeed = Helper.ToSeed(newPasw);
		string content = Crypter.Ciphr(Crypter.Ciphr(entity.Content, oldSeed, Crypt.Decrypt), newSeed, Crypt.Encrypt);
		entity.Content = content;
		return entity;
	}
}
