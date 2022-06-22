using corum_pharmacy.ControllerActions;
using corum_pharmacy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace corum_pharmacy.Controllers
{
    public class PharmacyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult PharmacyList()
        {
            
            List<Pharmacy> pha = ParsePharmacyJson.ParsePharmacy();
            //int phaId = pha.Select(x => x.ilce).FirstOrDefault();
            List<Town> towns = ParseTownJson.ParseTown();
            //var result = towns.Where(x=>x.ilce_id == pha.Where(y=>y.ilce))
            List<SelectListItem> value = (from x in towns.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.ilce_adi,
                                              Value = x.ilce_id.ToString(),
                                          }).ToList();
            ViewBag.value1 = value;
            return View(pha);
        }
        [HttpGet]
        public ActionResult Category()
        {
            List<Town> towns = ParseTownJson.ParseTown();
            List<SelectListItem> value = (from x in towns.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.ilce_adi,
                                              Value = x.ilce_id.ToString(),
                                          }).ToList();
            ViewBag.ilce_id = towns.Select(x => x.ilce_id).ToList();
            ViewBag.value1 = value;
            return View(towns);
        }
        
    }
}
