using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Examen.Web.Controllers
{
    public class AdmissionController : Controller
    {
        IServiceAdmission sa;
        IServiceChambre sch;
        IServicePatient sp;
        public AdmissionController(IServiceAdmission sa, IServiceChambre sch,IServicePatient sp)
        {
            this.sa = sa;
            this.sch = sch;
            this.sp = sp;
        }
        // GET: AdmissionController
        public ActionResult Index()
        {
            return View(sa.GetAll().OrderBy(a=>a.DateAdmission));
        }

        // GET: AdmissionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdmissionController/Create
        public ActionResult Create()
        {
            ViewBag.PatientFK =
                new SelectList(sp.GetAll(), "CIN", "CIN");
           
            ViewBag.ChambreFK =
                new SelectList(sch.GetAll(), "NumeroChambre", "NumeroChambre");
            
            return View();
        }

        // POST: AdmissionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Admission collection)
        {
            try
            {
                sa.Add(collection);
                sa.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdmissionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdmissionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdmissionController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdmissionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
