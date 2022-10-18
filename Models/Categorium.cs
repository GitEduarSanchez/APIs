using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public partial class Categorium
    {
        public Categorium()
        {
            Productos = new HashSet<Producto>();
        }

        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "El nombre del producto acepta maximo 50 caracteres")]
        public string Categoria { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<Producto> Productos { get; set; }
    }
}
