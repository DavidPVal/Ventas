using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Ventas.Common.Models;
using Ventas.Domain.Models;

namespace Ventas.API.Controllers
{
    public class ProductoController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Producto
        public IQueryable<Producto> GetProductoes()
        {
            return db.Productoes;
        }

        // GET: api/Producto/5
        [ResponseType(typeof(Producto))]
        public async Task<IHttpActionResult> GetProducto(int id)
        {
            Producto producto = await db.Productoes.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }

            return Ok(producto);
        }

        // PUT: api/Producto/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProducto(int id, Producto producto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != producto.IDProducto)
            {
                return BadRequest();
            }

            db.Entry(producto).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Producto
        [ResponseType(typeof(Producto))]
        public async Task<IHttpActionResult> PostProducto(Producto producto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Productoes.Add(producto);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = producto.IDProducto }, producto);
        }

        // DELETE: api/Producto/5
        [ResponseType(typeof(Producto))]
        public async Task<IHttpActionResult> DeleteProducto(int id)
        {
            Producto producto = await db.Productoes.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }

            db.Productoes.Remove(producto);
            await db.SaveChangesAsync();

            return Ok(producto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductoExists(int id)
        {
            return db.Productoes.Count(e => e.IDProducto == id) > 0;
        }
    }
}