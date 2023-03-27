using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InventoryManagement.Models;
using System.Xml.Linq;

namespace InventoryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductItemsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductItemsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductItem>>> GetProductItems()
        {
            return await _context.ProductItems.ToListAsync();
        }

        [HttpGet("{productId}")]
        public object GetProductItemInfo(long productId)
        {
            var productItems = _context.ProductItems
                .Join(_context.Items,
                productItem => productItem.ItemId,
                item=>item.Id,
                (productItem,item) => new {productItem,item}
                )
                .Where(entry => entry.productItem.ProductId == productId);
            Console.WriteLine("Hurre!");
            Console.WriteLine(productItems);
            //Console.ReadLine();
            return productItems;
        }

        // PUT: api/ProductItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{productId}/{itemId}")]
        public async Task<IActionResult> PutProductItem(long productId,long itemId, ProductItem productItem)
        {
            if (productId != productItem.ProductId || itemId != productItem.ItemId)
            {
                return BadRequest();
            }

            _context.Entry(productItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!ProductItemExists(productId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ProductItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductItem>> PostProductItem(ProductItem productItem)
        {
            _context.ProductItems.Add(productItem);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductItemExists(productItem.ProductId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProductItem", new { id = productItem.ProductId }, productItem);
        }

        // DELETE: api/ProductItems/5
        [HttpDelete("{productId}/{itemId}")]
        public async Task<IActionResult> DeleteProductItem(long productId, long itemId)
        {
            //var organization = await _context.Organizations.FirstOrDefaultAsync(org => org.Name == name && org.Password == password);
            var productItem = await _context.ProductItems.FirstOrDefaultAsync(entry => entry.ItemId== itemId && entry.ProductId== productId);
            if (productItem == null)
            {
                return NotFound();
            }

            _context.ProductItems.Remove(productItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductItemExists(long id)
        {
            return _context.ProductItems.Any(e => e.ProductId == id);
        }
    }
}
