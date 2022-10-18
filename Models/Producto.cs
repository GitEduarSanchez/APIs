using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebAPI.Models
{
    public partial class Producto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "El nombre del producto acepta maximo 50 caracteres")]
        public string Nombre { get; set; } = null!;
        [MaxLength(200, ErrorMessage = "La descripcion del producto acepta maximo 200 caracteres")]
        public string? Descripcion { get; set; }
        [Required]

        public int Categoriaid { get; set; }
        public string? Img { get; set; }
        [JsonIgnore]
        public virtual Categorium Categoria { get; set; } = null!;
    }
}
