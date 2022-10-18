using WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.DTO;

namespace WebAPI.Services;

    public class ProductoService
    {
    private readonly tiendaContext _context;

    public ProductoService(tiendaContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<ProductoDTOOUT>> GetAll()
    {
        return await _context.Productos.Select(p => new ProductoDTOOUT
        {
            Id = p.Id,
            Nombre = p.Nombre,
            Descripcion = p.Descripcion,
            Categoria = p.Categoria.Categoria,
            Img = p.Img
        }).OrderBy(c => c.Categoria).ToListAsync();
    }
    public async Task<Producto?> GetById(int id)
    {
       
        return await _context.Productos.FindAsync(id);

    }
    public async Task<ProductoDTOOUT?> GetDtoById(int id)
    {
        return await _context.Productos.Where(p => p.Id == id).Select(p => new ProductoDTOOUT
        {
            Id = p.Id,
            Nombre = p.Nombre,
            Descripcion = p.Descripcion,
            Categoria = p.Categoria.Categoria,
            Img = p.Img
        }).OrderBy(c => c.Categoria).SingleOrDefaultAsync();

    }
    public async Task<Producto> Create(Producto producto)
    {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
       
        return producto;
    }
    public async Task Update(int id, Producto producto)
    {
        var exist = await GetById(id);
        if (exist is not null)
        {
            exist.Nombre = producto.Nombre;
            exist.Descripcion = producto.Descripcion;
            exist.Categoriaid = producto.Categoriaid;
            exist.Img = producto.Img;

           await _context.SaveChangesAsync();
        }
    }
    public async Task Delete(int id)
    {
        var productodelete = await GetById(id);
        if (productodelete is not null)
        {
            _context.Productos.Remove(productodelete);
          await _context.SaveChangesAsync();
        }
    }
}

