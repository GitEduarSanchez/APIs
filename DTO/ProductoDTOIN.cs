namespace WebAPI.DTO
{
    public class ProductoDTOIN
    {
        public int Id { get; set; } = 0;
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public int Categoriaid { get; set; }
        public string? Img { get; set; }
    }
}
