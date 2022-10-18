namespace WebAPI.DTO
{
    public class ProductoDTOOUT
    {

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public string? Categoria { get; set; }
        public string? Img { get; set; }
    }
}
