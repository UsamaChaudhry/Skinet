using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _context;
        public ProductsController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Getproducts()
        {
            var product = await _context.Product.ToListAsync();
            return Ok(product);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Getproduct(int id)
        {
            return await _context.Product.FindAsync(id);
        }
    }
}