using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.DTOs
{
    public class JugueteCrearDto
    {
        //validaciones con los DataAnnotations al usarse como modelo para Crear un juguete
        [Required(ErrorMessage = "El Nombre es equerido.")]
        [StringLength(maximumLength: 50, ErrorMessage ="El Nombre debe tener máximo 50 caracteres.")]
        public string Nombre { get; set; }
        [StringLength(maximumLength: 100, ErrorMessage = "La Descripción debe tener máximo 100 caracteres.")]
        public string Descripcion { get; set; }
        public Nullable<int> RestriccionEdad { get; set; }
        [Required(ErrorMessage ="La Compañia es requerida.")]
        [StringLength(maximumLength: 50, ErrorMessage = "La Compañia debe tener máximo 50 caracteres.")]
        public string Compania { get; set; }
        [Required(ErrorMessage = "El Precio es requerido.")]
        public decimal Precio { get; set; }
        public IFormFile Imagen { get; set; }
    }
}
