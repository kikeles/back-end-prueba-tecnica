using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Utilidades
{
    public interface IAlmacenadorImagenesLocal
    {
        Task<string> SaveImage(string contenedor, IFormFile archivo);
        Task<string> EditImage(string contenedor, string imagenAnterior, IFormFile archivo);
        Task DeleteImage(string contenedor, string nombreImagen);
    }
}
