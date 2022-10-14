using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Juguete
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength:50)]
        public string Nombre { get; set; }
        [StringLength(maximumLength: 100)]
        public string Descripcion { get; set; }
        public Nullable<int> RestriccionEdad { get; set; }
        [Required]
        [StringLength(maximumLength:50)]
        public string Compania { get; set; }
        [Required]
        public decimal Precio { get; set; }
        [StringLength(maximumLength:255)]
        public string Imagen { get; set; }
    }
}
