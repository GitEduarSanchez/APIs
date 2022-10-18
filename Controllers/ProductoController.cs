using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductoController : ControllerBase
{
    
    private readonly ProductoService _service;
    
    public ProductoController(ProductoService producto)
    {
        _service = producto;
    }
   
    [HttpGet]
    public async Task<IEnumerable<ProductoDTOOUT>> Get()
    {
        return await _service.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductoDTOOUT>> GetById(int id)
    {
        try
        {
            var producto = await _service.GetDtoById(id);
            if (producto is null)
                return ProductoNoFound(id);

            return producto;
        }
        catch (Exception)
        {
            throw;
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProductoDTOIN productoDTOIN)
    {
        try
        {
            var newProducto = new Producto();
            newProducto.Nombre = productoDTOIN.Nombre;
            newProducto.Descripcion = productoDTOIN.Descripcion;
            newProducto.Categoriaid = productoDTOIN.Categoriaid;
            newProducto.Img = productoDTOIN.Img;

            var producto = await _service.Create(newProducto);
            return Ok(new { Status = "ok", mesege ="Registro Guardado con exito" });
        }
        catch (Exception)
        {
            throw;
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ProductoDTOIN productoDTOIN)
    {
        try
        {
            if (id != productoDTOIN.Id)
                return BadRequest(new { Status = "Failed", message = $"El ID = {id} de la URL no coincide con el ID({productoDTOIN.Id})" });

            var ProductoToUpdate = await _service.GetDtoById(id);
            if (ProductoToUpdate is not null)
            {
                var UpdateProducto = new Producto();

                UpdateProducto.Nombre = productoDTOIN.Nombre;
                UpdateProducto.Descripcion = productoDTOIN.Descripcion;
                UpdateProducto.Categoriaid = productoDTOIN.Categoriaid;
                UpdateProducto.Img = productoDTOIN.Img;
                await _service.Update(id, UpdateProducto);
                return Ok(new { Status = "ok", mesege = "Registro Actualizado con exito " });
            }
            else
            {
                return ProductoNoFound(id);
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var exist = await _service.GetById(id);
            if (exist is not null)
            {
                await _service.Delete(id);
                return Ok(new { Status = "ok", mesege = "Registro Eliminado con exito " });
            }
            return ProductoNoFound(id);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public NotFoundObjectResult ProductoNoFound(int id)
    {
        try
        {
            return NotFound(new { message = $"El ID = {id} del producto no existe" });
        }
        catch (Exception)
        {
            throw;
        }
    }
}
