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
    public class ClientesController : Controller
    {
        private readonly ControleVendasContext _context;

        public ClientesController(ControleVendasContext context)
        {
            _context = context;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clientes.ToListAsync());
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteModel = await _context.Clientes
                .FirstOrDefaultAsync(m => m.ClienteModelId == id);
            if (clienteModel == null)
            {
                return NotFound();
            }

            return View(clienteModel);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClienteModelId,Nome,Endereco,Telefone,Cpf")] ClienteModel clienteModel)
        {
            try 
            {
                if(clienteModel.Cpf.Length != 11)
                {
                    ModelState.AddModelError("Cpf", "Cpf Inválido");
                }
                if (ModelState.IsValid)
                {
                    _context.Add(clienteModel);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                
            }
            catch(DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possível");
            }
            return View(clienteModel);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteModel = await _context.Clientes.FindAsync(id);
            if (clienteModel == null)
            {
                return NotFound();
            }
            return View(clienteModel);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("ClienteModelId,Nome,Endereco,Telefone,Cpf")] ClienteModel clienteModel)
        {
            if (id != clienteModel.ClienteModelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clienteModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteModelExists(clienteModel.ClienteModelId))
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
            return View(clienteModel);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteModel = await _context.Clientes
                .FirstOrDefaultAsync(m => m.ClienteModelId == id);
            if (clienteModel == null)
            {
                return NotFound();
            }

            return View(clienteModel);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var clienteModel = await _context.Clientes.FindAsync(id);
            _context.Clientes.Remove(clienteModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteModelExists(long? id)
        {
            return _context.Clientes.Any(e => e.ClienteModelId == id);
        }
    }
}
