using SQLite;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AgendaPersonal.Models;


namespace AgendaPersonal.Data;

public class ContactoDatabase
{
    private readonly SQLiteAsyncConnection _db;

    public ContactoDatabase()
    {
        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "agenda.db");
        _db = new SQLiteAsyncConnection(dbPath);
        _db.CreateTableAsync<Contacto>().Wait();
    }

    public Task<List<Contacto>> ObtenerContactosAsync() => _db.Table<Contacto>().ToListAsync();
    public Task<int> GuardarContactoAsync(Contacto contacto) =>
        contacto.Id != 0 ? _db.UpdateAsync(contacto) : _db.InsertAsync(contacto);
    public Task<int> EliminarContactoAsync(Contacto contacto) => _db.DeleteAsync(contacto);
}

