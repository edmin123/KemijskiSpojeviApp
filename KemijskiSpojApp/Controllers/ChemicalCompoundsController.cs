using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KemijskiSpojApp.Models;
using System.Data.Entity;

namespace KemijskiSpojApp.Controllers
{
    public class ChemicalCompoundsController : Controller
    {
        public ApplicationDbContext _context;

        public ChemicalCompoundsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: ChemicalCompounds
        public ActionResult AllChemicallCompounds()
        {
            return View();
        }

        public ActionResult New()
        {
            var model = new ChemicalViewModel
            {
                ChemicalTypes = _context.ChemicalTypes.ToList(),
                ChemicalCompound = new ChemicalCompound()
            };
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var chemicalCompound = _context.ChemicalCompounds.SingleOrDefault(c => c.Id == id);
            var model = new ChemicalViewModel
            {
                ChemicalTypes = _context.ChemicalTypes.ToList(),
                ChemicalCompound = chemicalCompound
            };
            return View("New", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ChemicalCompound chemicalCompound)
        {
            if (!ModelState.IsValid)
            {
                var model = new ChemicalViewModel
                {
                    ChemicalTypes = _context.ChemicalTypes.ToList(),
                    ChemicalCompound = chemicalCompound
                };
                return View("New", model);
            }

            if (chemicalCompound.Id == 0)
            {               
                _context.ChemicalCompounds.Add(chemicalCompound);
            }
            else
            {
                var compoundInDb = _context.ChemicalCompounds.SingleOrDefault(c => c.Id == chemicalCompound.Id);
                compoundInDb.Name = chemicalCompound.Name;
                compoundInDb.ChemicalTypeId = chemicalCompound.ChemicalTypeId;
                compoundInDb.ChemicalSymbol = chemicalCompound.ChemicalSymbol;
            }
            _context.SaveChanges();
            return RedirectToAction("AllChemicallCompounds", "ChemicalCompounds");
        }

        public JsonResult GetAllChemicalCompounds()
        {
            var compounds = _context.ChemicalCompounds.Include(c=>c.ChemicalType).ToList();
            return Json(compounds, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeleteCompound(int id)
        {
            var compound = _context.ChemicalCompounds.SingleOrDefault(c => c.Id == id);
            _context.ChemicalCompounds.Remove(compound);
            _context.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

    }
}