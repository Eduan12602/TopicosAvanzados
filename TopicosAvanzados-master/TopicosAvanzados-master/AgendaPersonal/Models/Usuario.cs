using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;

namespace AgendaPersonal.Models;

public class Usuario
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string NombreUsuario { get; set; }
    public string Contrasena { get; set; }
}
