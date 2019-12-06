using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PFinal.Models;

namespace PFinal.Controllers
{
    public class SOCIOSController : Controller
    {
        private PROYECTOEntities db = new PROYECTOEntities();

        // GET: SOCIOS
        public ActionResult Index()
        {
            return View(db.SOCIOS.ToList());
        }

        // GET: SOCIOS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SOCIOS sOCIOS = db.SOCIOS.Find(id);
            if (sOCIOS == null)
            {
                return HttpNotFound();
            }
            return View(sOCIOS);
        }

        // GET: SOCIOS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SOCIOS/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NOMBRE,APELLIDOS,CEDULA,FOTO,DIRECCION,TELEFONO,SEXO,EDAD,FECHA_NACIMIENTO,DATOS_MEMBRESIA,LUGAR_TRABAJO,DIRECCION_OFICINA,TEL_OFICINA,ESTADO,FECHA_INGRESO,FECHA_SALIDA")] SOCIOS sOCIOS)
        {
            if (ModelState.IsValid)
            {
                db.SOCIOS.Add(sOCIOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sOCIOS);
        }

        // GET: SOCIOS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SOCIOS sOCIOS = db.SOCIOS.Find(id);
            if (sOCIOS == null)
            {
                return HttpNotFound();
            }
            return View(sOCIOS);
        }

        // POST: SOCIOS/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NOMBRE,APELLIDOS,CEDULA,FOTO,DIRECCION,TELEFONO,SEXO,EDAD,FECHA_NACIMIENTO,DATOS_MEMBRESIA,LUGAR_TRABAJO,DIRECCION_OFICINA,TEL_OFICINA,ESTADO,FECHA_INGRESO,FECHA_SALIDA")] SOCIOS sOCIOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sOCIOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sOCIOS);
        }

        // GET: SOCIOS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SOCIOS sOCIOS = db.SOCIOS.Find(id);
            if (sOCIOS == null)
            {
                return HttpNotFound();
            }
            return View(sOCIOS);
        }

        // POST: SOCIOS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SOCIOS sOCIOS = db.SOCIOS.Find(id);
            db.SOCIOS.Remove(sOCIOS);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
