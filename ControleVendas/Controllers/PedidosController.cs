using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControleVendas.Data;
using ControleVendas.Models;

namespace ControleVendas.Controllers
{
    public class PedidosController : Controller
    {
        private readonly ControleVendasContext _context;

        public PedidosController(ControleVendasContext context)
        {
            _context = context;
        }


        // GET: Pedidos
        
        
        
        public async Task<IActionResult> Index()
        {
            var controleVendasContext = _context.Pedidos.Include(p => p.Cliente);
            return View(await controleVendasContext.ToListAsync());
        }

        // GET: Pedidos/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoModel = await _context.Pedidos
                .Include(p => p.Cliente)
                .FirstOrDefaultAsync(m => m.PedidoModelId == id);

            
            if (pedidoModel == null)
            {
                return NotFound();
            }

            return View(pedidoModel);
        }

        // GET: Pedidos/Create
        
        public IActionResult Create()
        {
            ViewData["ClienteModelId"] = new SelectList(_context.Clientes, "ClienteModelId", "Nome");
            //ViewData["ProdutoModelId"] = new MultiSelectList(_context.Produtos, "ProdutoModelId", "Nome");
            var produtos = _context.Produtos.OrderBy(i => i.ProdutoModelId).ToList();
            produtos.Insert(0, new ProdutoModel() { ProdutoModelId = 0, Nome = "[Selecione o Produto]" });
            ViewBag.Produtos = produtos;
            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PedidoModelId,Codigo,Data,Produtos,Valor,ClienteModelId")] PedidoModel pedidoModel)
        {
            
            if (ModelState.IsValid)
                    
            {
                _context.Add(pedidoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteModelId"] = new SelectList(_context.Clientes, "ClienteModelId", "Nome", pedidoModel.ClienteModelId);
            ViewData["ProdutoModelId"] = new MultiSelectList(_context.Produtos, "ProdutoModelId", "Nome");
            

            return View(pedidoModel);
        }

        // GET: Pedidos/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoModel = await _context.Pedidos.FindAsync(id);
            if (pedidoModel == null)
            {
                return NotFound();
            }
            ViewData["ClienteModelId"] = new SelectList(_context.Clientes, "ClienteModelId", "Nome", pedidoModel.ClienteModelId);
            var produtos = _context.Produtos.OrderBy(i => i.ProdutoModelId).ToList();
            produtos.Insert(0, new ProdutoModel() { ProdutoModelId = 0, Nome = "[Selecione o Produto]" });
            ViewBag.Produtos = produtos;
            return View(pedidoModel);
        }

        // POST: Pedidos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("PedidoModelId,Codigo,Data,Produtos,Valor,ClienteModelId")] PedidoModel pedidoModel)
        {
            if (id != pedidoModel.PedidoModelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedidoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoModelExists(pedidoModel.PedidoModelId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteModelId"] = new SelectList(_context.Clientes, "ClienteModelId", "Nome", pedidoModel.ClienteModelId);
            ViewBag.produtos = new MultiSelectList(_context.Produtos, "ProdutoModelId", "Nome");
            return View(pedidoModel);
        }

        // GET: Pedidos/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidoModel = await _context.Pedidos
                .Include(p => p.Cliente)
                .FirstOrDefaultAsync(m => m.PedidoModelId == id);
            if (pedidoModel == null)
            {
                return NotFound();
            }

            return View(pedidoModel);
        }

        // POST: Pedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var pedidoModel = await _context.Pedidos.FindAsync(id);
            _context.Pedidos.Remove(pedidoModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoModelExists(long? id)
        {
            return _context.Pedidos.Any(e => e.PedidoModelId == id);
        }
    }
}
