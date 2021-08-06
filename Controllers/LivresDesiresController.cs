using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetBDLivres.Data;
using ProjetBDLivres.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetBDLivres.Controllers
{
    public class LivresDesiresController : Controller
    {
        private readonly LivresContext _context;
        private readonly IWebHostEnvironment _hostEnvironnement;

        public LivresDesiresController(LivresContext context, IWebHostEnvironment hostEnvironnement)
        {
            _context = context;
            this._hostEnvironnement = hostEnvironnement;

        }

        public async Task<IActionResult> Index()
        {
            var livresDesires = await _context.LivresDesires.ToListAsync();
            return View(livresDesires);

        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LivresDesires livreDesire)
        {
            //ajouter le livre si la validation du model est correcte
            if (ModelState.IsValid)
            {
                //Enregistrer l'image dans le dossier wwwroot/image
                string wwwRootPath = _hostEnvironnement.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(livreDesire.ImageFile.FileName);
                string extension = Path.GetExtension(livreDesire.ImageFile.FileName);
                livreDesire.imageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/Image", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await livreDesire.ImageFile.CopyToAsync(fileStream);
                }

                //Enregistrer le livre dans la base de donnee
                _context.LivresDesires.Add(livreDesire);
               
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(livreDesire);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id <= 0)
                return BadRequest(); // mauvaise requete si le id du livre est null ou inferieur ou egal a 0

            var livreinDb = await _context.LivresDesires.FirstOrDefaultAsync(e => e.id == id);

            if (livreinDb == null)
                return NotFound();

            return View(livreinDb);
        }

        //cette methode permet de modifier les informations sur un livre specifique
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(LivresDesires livreDesire)
        {
            if (!ModelState.IsValid)
                return View(livreDesire);

            //Enregistrer la nouvelle image dans le dossier wwwroot/image
            string wwwRootPath = _hostEnvironnement.WebRootPath;
            
            string fileName = Path.GetFileNameWithoutExtension(livreDesire.ImageFile.FileName);
            string extension = Path.GetExtension(livreDesire.ImageFile.FileName);
            livreDesire.imageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(wwwRootPath + "/Image", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                livreDesire.ImageFile.CopyTo(fileStream);
            }

            _context.LivresDesires.Update(livreDesire);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id <= 0)
                return BadRequest(); // mauvaise requete si le id du livre est null ou inferieur ou egal a 0

            var livreinDb = await _context.LivresDesires.FirstOrDefaultAsync(e => e.id == id);

            if (livreinDb == null)
                return NotFound();

            //supprimer l'image dans le dossier wwwroot/image
            var imagePath = Path.Combine(_hostEnvironnement.WebRootPath, "image", livreinDb.imageName);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);

            //supprimer l'enregistrement du livre
            _context.LivresDesires.Remove(livreinDb);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }
    }
}
