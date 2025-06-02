using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;


namespace AgendaPersonal.Models;
using SQLite;



public class Contacto
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string? Telefono { get; set; }
    public string? CorreoElectronico { get; set; }
    public string? Direccion { get; set; }
    public bool Activo { get; set; } = true;
}
