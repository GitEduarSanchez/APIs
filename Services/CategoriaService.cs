using WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Services;

public class CategoriaService
{
    private readonly tiendaContext _context;
    public CategoriaService()
    {
     _context = new tiendaContext();
    }
    public CategoriaService(tiendaContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Categorium>> GetAll()
    {
        return await _context.Categoria.ToListAsync();
    }
    public async Task<Categorium?> GetById(int id)
    {
        return await _context.Categoria.FindAsync(id);
    }
}


