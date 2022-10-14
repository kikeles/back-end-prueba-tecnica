using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Utilidades
{
    public class AlmacenadorImagenesLocal : IAlmacenadorImagenesLocal
    {
        private readonly IWebHostEnvironment _env;

        public AlmacenadorImagenesLocal(IWebHostEnvironment env)
        {
            this._env = env;
        }

        public async Task<string> SaveImage(string contenedor, IFormFile archivo)
        {
            var extension = Path.GetExtension(archivo.FileName);
            var nombreImagen = $"{Guid.NewGuid()}{extension}";
            string folder = Path.Combine(_env.ContentRootPath, contenedor);

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            string ruta = Path.Combine(folder, nombreImagen);

            using (var memoryStream = new MemoryStream())
            {
                //obtener la representación en bytes del archivo
                await archivo.CopyToAsync(memoryStream);
                var contenidoImagen = memoryStream.ToArray();
                //guadar el archivo en la ruta especificada
                await File.WriteAllBytesAsync(ruta, contenidoImagen);
            }

            return nombreImagen;
        }

        public async Task<string> EditImage(string contenedor, string imagenAnterior, IFormFile archivo)
        {
            await DeleteImage(contenedor, imagenAnterior);
            return await SaveImage(contenedor, archivo);
        }

        public Task DeleteImage(string contenedor, string nombreImagen)
        {
            if (string.IsNullOrEmpty(nombreImagen))
            {
                return Task.CompletedTask;
            }

            var directorioArchivo = Path.Combine(_env.ContentRootPath, contenedor, nombreImagen);

            if (File.Exists(directorioArchivo))
            {
                File.Delete(directorioArchivo);
            }

            return Task.CompletedTask;
        }
    }
}
