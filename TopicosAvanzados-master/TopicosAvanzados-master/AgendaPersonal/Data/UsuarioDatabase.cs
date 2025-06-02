using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;
using AgendaPersonal.Models;


namespace AgendaPersonal.Data;

public class UsuarioDatabase
{
    private readonly SQLiteAsyncConnection _db;

    public UsuarioDatabase()
    {
        string path = Path.Combine(FileSystem.AppDataDirectory, "usuarios.db");
        _db = new SQLiteAsyncConnection(path);
        _db.CreateTableAsync<Usuario>().Wait();
    }

    public Task<Usuario> GetUsuarioAsync(string nombreUsuario)
    {
        return _db.Table<Usuario>().FirstOrDefaultAsync(u => u.NombreUsuario == nombreUsuario);
    }

    public Task<int> GuardarUsuarioAsync(Usuario usuario)
    {
        return _db.InsertAsync(usuario);
    }

    public Task<List<Usuario>> ObtenerUsuariosAsync()
    {
        return _db.Table<Usuario>().ToListAsync();
    }
}
