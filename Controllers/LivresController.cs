using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetBDLivres.Data;
using ProjetBDLivres.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetBDLivres.Controllers
{
    public class LivresController : Controller
    {
        private readonly LivresContext _context;

        public LivresController(LivresContext context)
        {
            _context = context;
        }
        //Methode permettant d'afficher la liste des livres
        public async Task<IActionResult> Index()
        {
            var livres = await _context.Livres.ToListAsync();
            return View(livres);
        }
        //Methode permettant de creer le formulaire d'ajout de livre
        public IActionResult Create()
        {
            return View();
        }

        //Methode permettant d'ajouter un nouvel livre dans la base de donnee
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Livres livre)
        {
            //ajouter le livre si la validation du model est correcte
            if (ModelState.IsValid)
            {
                _context.Livres.Add(livre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(livre);
        }

        //cette methode permet de trouver le livre en question a parti de son Id
        public async Task<IActionResult> Edit(int?  id)
        {
            if (id == null || id <= 0)
                return BadRequest(); // mauvaise requete si le id du livre est null ou inferieur ou egal a 0

            var livreinDb = await _context.Livres.FirstOrDefaultAsync(e => e.livreId  ==  id);

            if (livreinDb == null)
                return NotFound();

            return View(livreinDb);
        }

        //cette methode permet de modifier les informations sur un livre specifique
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Livres livre)
        {
            if (!ModelState.IsValid)
                return View(livre);

            _context.Livres.Update(livre);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id <= 0)
                return BadRequest(); // mauvaise requete si le id du livre est null ou inferieur ou egal a 0

            var livreinDb = await _context.Livres.FirstOrDefaultAsync(e => e.livreId == id);

            if (livreinDb == null)
                return NotFound();

            _context.Livres.Remove(livreinDb);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

    }

}
