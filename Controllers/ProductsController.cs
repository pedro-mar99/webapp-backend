using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapp_backend.Data;
using webapp_backend.Entities;

namespace webapp_backend.Controllers
{
    // MODEL VIEW CONTROLLER: en este caso creamos el controlador

    // LE AGREGAMOS ATRIBUTOS AL CONTROLADOR []
    [ApiController]
    // La ruta a la que el cliente le tiene que pegar
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly DataContext _context;
        // Le pasamos como parametro la clase DataContext para que adentro de la clase
        // podamos acceder a la base de datos gracias a la variable context
        public ProductsController(DataContext context)
        {
            _context = context;
        }

        //Creamos los END POINTS a mano
        [HttpGet]
        // Retornamos un ActionResult, entre <> especificamos el tipo que retornamos al cliente
        // En este caso, una lista de productos / usamos IEnumerable del tipo Producto / tmb se puede usar List
        // Le ponemos de nombre GetProducts()

        // Hacemos los endpoints ASINCRONOS para mejor rendimiento y poder realizar requests simultaneas
        // Para eso envolvemos (wrap) en una Task entre '<>'
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            // Traeamos la tabla Products y la pasamos a una lista.
            return await _context.Products.ToListAsync();
        }

        [HttpGet("{id}")] // LE PEGA A: api/products/{id}

        // Ahora no usamos el IEnumerable, solo traemos el objeto Product
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        [HttpPost("register")]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            try
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return product;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error creating new product record");
            }
        }
    }
}