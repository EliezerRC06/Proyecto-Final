using System;
using System.Collections.Generic;
using System.Drawing;

namespace ProyectoLogin.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? NombreUsuario { get; set; }

    public string? Correo { get; set; }

    public string? Clave { get; set; }

    public string? Telefono { get; set; } 
    public string? Foto { get; set; } 
}
